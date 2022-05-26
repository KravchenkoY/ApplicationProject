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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void btnSubmitProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = new Product 
            { 
                Name = txtBoxName.Text,
                Price = Convert.ToDouble(txtBoxPrice.Text),
                Quantity = Convert.ToInt32(txtBoxQuantity.Text),
                Brand = txtBoxBrand.Text,
                ProductType = txtBoxProductType.Text,
            };
            using var context = new ProductManagerContext();
            context.Products.Add(product);
            context.SaveChanges();

        }
    }
}
