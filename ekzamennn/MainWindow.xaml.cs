using ekzamennn.AppDataFile;
using ekzamennn.Pages;
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

namespace ekzamennn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectOdb.conObj = new BeautyShopEntities();
            FrameObj.FrameMain = frmMain;
            frmMain.Navigate(new Auto());
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void btnBack_Click_1(object sender, RoutedEventArgs e)
        {
            FrameObj.FrameMain.GoBack();
        }
    }
}
