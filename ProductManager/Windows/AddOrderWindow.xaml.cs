using ProductManager.Repository;
using ProductManager.Repository.Models;
using ProductManager.ViewModels;
using System;
using System.Collections;
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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
            using var context = new ProductManagerContext();
            var customers = context.Partners
                .Where(x=>x .PartnerTypeId == (int)PartnerTypeEnum.Customer)
                .Select(x => new {x.Id, Name =$"{x.Name} {x.LastName}"})
                .ToList();
            comboBoxCustomer.ItemsSource = customers;
            orderGrid.ItemsSource = new List<ProductViewModel>();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.Show();
            Hide();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddOrderProductWindow addOrderProductWindow = new AddOrderProductWindow();
            var result = addOrderProductWindow.ShowDialog();
            if (result == true)
            {
                var list = (IList)orderGrid.ItemsSource;

                list.Add(addOrderProductWindow.SelectedProduct);
                orderGrid.Items.Refresh();
            }
            //Hide();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var orderLineProducts = orderGrid.Items.OfType<ProductViewModel>()
                .Select(x => new { x.Id, x.Quantity })
                .ToList();
            var orderlines = new List<OrderLine>();
            foreach (var product in orderLineProducts)
            {
                orderlines.Add(new OrderLine
                {
                    ProductId = product.Id,
                    Quantity = product.Quantity,
                });
            }

            using var context = new ProductManagerContext();
            var order = new OrderHeader
            {
                Date = orderDatePicker.SelectedDate.Value,
                PartnerId = (int)comboBoxCustomer.SelectedValue,
                OrderLines = orderlines
            };
            context.OrderHeaders.Add(order);


            var ids = orderLineProducts.Select(v => v.Id).ToList();

            var productsToUpdate = context.Products.Where(x => ids.Contains(x.Id)).ToList();
            foreach(var toUpdate in productsToUpdate)
            {
                var orderLine = orderLineProducts.FirstOrDefault(x => x.Id == toUpdate.Id);
                toUpdate.Quantity -= orderLine.Quantity;
            }

            context.Products.UpdateRange(productsToUpdate);
            context.SaveChanges();
        }
    }
}
