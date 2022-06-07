using Microsoft.EntityFrameworkCore;
using ProductManager.Repository;
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
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();
            using var context = new ProductManagerContext();
            var orders = context.OrderHeaders
                .Include(x => x.Partner)
                .Include(x => x.OrderLines)
                .ThenInclude(x => x.Product)
                .ToList();
            var list = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                IEnumerable<string>? productList = order.OrderLines.Select(x => $"{x.Product.Name} - {x.Quantity}");
                var products = string.Join(", ", productList);
                list.Add(new OrderViewModel
                {
                    Id = order.Id,
                    CustomerName = $"{order.Partner.Name} {order.Partner.LastName}",
                    Date = order.Date,
                    Products = products
                });
            }

            ordersListGrid.ItemsSource = list;
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow();
            addOrderWindow.Show();
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
