using ProductManager.Repository;
using ProductManager.Repository.Models;
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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();

            using var context = new ProductManagerContext();
            var roles = context.UserRoles.ToList();
            comboBoxUserRole.DataContext = roles;
        }

        private void btnSubmitProduct_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Name = txtBoxName.Text,
                LastName = txtBoxLastName.Text,
                Password = txtBoxPassword.Text,
                Email = txtBoxEmail.Text,
                UserRoleId = (int)comboBoxUserRole.SelectedValue
            };
            using var context = new ProductManagerContext();
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("User has been added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            GoBack();
        }

        private void GoBack()
        {
            ManagementWindow managementWindow = new ManagementWindow();
            managementWindow.Show();
            Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
    }
}
