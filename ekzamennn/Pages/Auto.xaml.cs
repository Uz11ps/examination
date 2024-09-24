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
using System.Data.SqlClient;
using ekzamennn;
using ekzamennn.AppDataFile;
using ekzamennn.Pages;


namespace ekzamennn.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        public Auto()
        {
          InitializeComponent();
          ComboLogin.ItemsSource = AppData.Context.Clients.ToList();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ComboLogin.SelectedItem is Client currentUser)
            {
                if (PBoxPassword.Password == currentUser.Password)
                {
                    AppData.CurrentUser = currentUser; 
                    FrameObj.FrameMain.Navigate(new PageMain()); 
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void ComboLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}


