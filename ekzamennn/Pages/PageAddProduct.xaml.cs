using ekzamennn.AppDataFile;
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
    /// Логика взаимодействия для PageAddProduct.xaml
    /// </summary>
    public partial class PageAddProduct : Page
    {
        bool LogicRb = false;
        Product product = new Product();

        public PageAddProduct()
        {
            InitializeComponent();
            CmbxOwner.SelectedValuePath = "ID";
            CmbxOwner.DisplayMemberPath = "Name";
            CmbxOwner.ItemsSource = ConnectOdb.conObj.Manufacturers.ToList();

            product.ID = product.ID;

            TxtTitle.Text = product.Title;
            TxtCost.Text = Convert.ToString(product.Cost);
            //TxtImage.Text = product.MainimagePath;
            TxtDescpription.Text = product.Description;

            if (product.IsActive != false)
            {
                LogicRb = true;
            }
            else
            {
                LogicRb = false;
            }

            if (RbNotActive.IsChecked != false)
            {
                LogicRb = true;
            }
            else
            {
                LogicRb = true;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProduct = new Product()
                {
                    Title = TxtTitle.Text,
                    Cost = Convert.ToDecimal(TxtCost.Text),
                    Description = TxtDescpription.Text,
                   // MainimagePath = TxtImage.Text,
                    IsActive = LogicRb,
                    Manufacturer = CmbxOwner.SelectedItem as Manufacturer
                };

                ConnectOdb.conObj.Products.Add(newProduct);
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
