using Microsoft.EntityFrameworkCore;
using ProductManager.Repository;
using ProductManager.Repository.Models;
using ProductManager.ViewModels;
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
    /// Interaction logic for OverviewWindow.xaml
    /// </summary>
    public partial class OverviewWindow : Window
    {
        public OverviewWindow()
        {
            InitializeComponent();
            using var context = new ProductManagerContext();
            var users = context.Users
                .Include(x=>x.OrderHeaders)
                .Where(u => u.UserRoleId != (int)UserRoleEnum.WarehouseWorker)
                .ToList();
            var result = users.Select(x=> new SellerRatingViewModel { Name= $"{x.Name} {x.LastName}",OrderCount = x.OrderHeaders.Count }).ToList();
            dataGrigSellerRating.ItemsSource = result;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            Hide();
        }
    }
}
