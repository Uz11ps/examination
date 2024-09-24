using ekzamennn.AppDataFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ekzamennn.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {  
        public PageProduct()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            gridListProduct.ItemsSource = ConnectOdb.conObj.Products.ToList();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, EventArgs e)
        {
            var HistoryProduct = ConnectOdb.conObj.Products.ToList();
            ListProduct.ItemsSource = HistoryProduct;
            ListProduct.ItemsSource = ConnectOdb.conObj.Products.Where(x => x.Title.StartsWith(TxtSearch.Text) || x.Description.StartsWith(TxtSearch.Text)).ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.FrameMain.Navigate(new PageEditNew((sender as Button).DataContext as Product));
         
        }

        private void BtnSaleHistory_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.FrameMain.Navigate(new PageSaleHistory((sender as Button).DataContext as Product));
        }

        private void RbUp_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            gridListProduct.ItemsSource = ConnectOdb.conObj.Products.OrderBy(x => x.Title).ToList();
        }

        private void RbDown_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            gridListProduct.ItemsSource = ConnectOdb.conObj.Products.OrderByDescending(x => x.Title).ToList();
        }

    }
}
