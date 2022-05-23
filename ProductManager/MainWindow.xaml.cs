using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductManager.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace ProductManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //con.Open();
            //com.Connection = con;
            //com.CommandText = 

            VerifyUser(txtUsername.Text, txtPassword.Password);
            
        }

        private void VerifyUser(string email, string password)
        {
            using var context = new ProductManagerContext();

            var user = context.Users.Where(x => x.Email == email).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("User doesn't exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (user.Password != password)
            {
                MessageBox.Show("Wrong password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Successful login", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Windows.MenuWindow menuWindow = new Windows.MenuWindow();
                menuWindow.Show();
                Hide();
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
