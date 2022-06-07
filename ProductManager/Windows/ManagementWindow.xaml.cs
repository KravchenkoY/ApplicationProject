using ProductManager.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
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
    /// Interaction logic for ManagementWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        public ManagementWindow()
        {
            InitializeComponent();
            var userRoleId = (int)MemoryCache.Default["userRoleId"];
            btnProducts.Visibility =  userRoleId == (int)UserRoleEnum.Administrator || userRoleId == (int)UserRoleEnum.WarehouseWorker 
                ? Visibility.Visible
                : Visibility.Hidden;
            btnPartners.Visibility = userRoleId == (int)UserRoleEnum.Administrator || userRoleId == (int)UserRoleEnum.SalesWorker
                ? Visibility.Visible
                : Visibility.Hidden;
            btnUsers.Visibility = userRoleId == (int)UserRoleEnum.Administrator
                ? Visibility.Visible
                : Visibility.Hidden;
        }

        public int UserRoleId { get; }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
            Hide();
        }

        private void btnPartners_Click(object sender, RoutedEventArgs e)
        {
            PartnersWindow partnersWindow = new PartnersWindow();
            partnersWindow.Show();
            Hide();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            UsersWindow usersWindow = new UsersWindow();
            usersWindow.Show();
            Hide();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            Hide();
        }
    }
}
