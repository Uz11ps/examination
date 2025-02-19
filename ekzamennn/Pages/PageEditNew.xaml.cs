﻿using ekzamennn.AppDataFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ekzamennn.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditNew.xaml
    /// </summary>
    public partial class PageEditNew : Page
    {

        bool logicRb = false;
        public PageEditNew(Product product)
        {
            InitializeComponent();
            CmbxOwner.SelectedIndex = (int)product.ManufacturerID - 1;
            CmbxOwner.SelectedValuePath = "ID";
            CmbxOwner.DisplayMemberPath = "Name";
            CmbxOwner.ItemsSource = ConnectOdb.conObj.Manufacturers.ToList();

            ProductObj.Id = product.ID;

            TxtTitle.Text = product.Title;
            TxtCost.Text = Convert.ToString(product.Cost);
            //TxtImage.Text = product.MainimagePath;
            TxtDescpription.Text = product.Description;

            if (product.IsActive != false)
            {
                RbActive.IsChecked = true;
                logicRb = true;
            }
            else
            {
                RbNotActive.IsChecked = true;
                logicRb = false;
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> products = ConnectOdb.conObj.Products.Where(x => x.ID == ProductObj.Id).AsEnumerable()
                 .Select(x =>
                 {
                     x.Title = TxtTitle.Text;
                     x.Cost = Convert.ToDecimal(TxtCost.Text);
                     if (string.IsNullOrWhiteSpace(TxtDescpription.Text))
                     {
                         x.Description = "";
                     }
                     else
                     {
                         x.Description = TxtDescpription.Text;
                     }
                     if (string.IsNullOrWhiteSpace(TxtImage.Text))
                     {
                         x.MainImagePath = "";
                     }
                     else
                     {
                         x.MainImagePath = TxtImage.Text;
                     }
                     x.IsActive = logicRb;
                     x.ManufacturerID = (int)CmbxOwner.SelectedValue;
                     return x;
                 });
            foreach (Product prdct in products)
            {
                ConnectOdb.conObj.Entry(prdct).State = System.Data.Entity.EntityState.Modified;
            }
            ConnectOdb.conObj.SaveChanges();
            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
