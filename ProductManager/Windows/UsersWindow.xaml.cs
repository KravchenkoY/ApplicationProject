using ProductManager.Repository;
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
using System.Windows.Shapes;

namespace ProductManager.Windows
{
    /// <summary>
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
            using var context = new ProductManagerContext();
            var users = context.Users.ToList();
            userGrid.ItemsSource = users;
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.Show();
            Hide();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ManagementWindow managementWindow = new ManagementWindow();
            managementWindow.Show();
            Hide();
        }
    }
}
