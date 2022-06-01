using ProductManager.Repository;
using System.Linq;
using System.Windows;

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
