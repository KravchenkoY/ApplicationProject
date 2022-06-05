using Microsoft.EntityFrameworkCore;
using ProductManager.Extensions;
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
    /// Interaction logic for AddOrderProductWindow.xaml
    /// </summary>
    public partial class AddOrderProductWindow : Window
    {
        public AddOrderProductWindow()
        {
            InitializeComponent();
            using var context = new ProductManagerContext();
            var products = context.Products.Include(x => x.Partner).ToList();
            addOrderDataGrid.ItemsSource = products.ToViewModelList();
        }
        internal ProductViewModel SelectedProduct { get; set; }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var product = (ProductViewModel)addOrderDataGrid.SelectedItem;
            product.Quantity = 1;
            SelectedProduct = product;

            Window.GetWindow(this).DialogResult = true;
            Window.GetWindow(this).Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).DialogResult = false;
            Window.GetWindow(this).Close();
        }
    }
}
