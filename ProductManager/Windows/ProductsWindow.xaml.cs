using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ProductManager.CsvModels;
using ProductManager.Extensions;
using ProductManager.Repository;
using ProductManager.Repository.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public ProductsWindow()
        {
            InitializeComponent();
            using var context = new ProductManagerContext();
            var products = context.Products.Include(x=>x.Partner).ToList();
            productGrid.ItemsSource = products.ToViewModelList();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.Show();
            Hide();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ManagementWindow managementWindow = new ManagementWindow();
            managementWindow.Show();
            Hide();
        }

        private void btnImportTemplate_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Comma-separated string file (*.csv)|*.csv";
            List<ProductCsvModel> csvrecords = new();
            if (openFileDialog.ShowDialog() == true)
            {
                using (var reader = new StreamReader(openFileDialog.FileName))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                   var records  = csv.GetRecords<ProductCsvModel>();
                    csvrecords = records.ToList();
                }
            }
            List<Product> products = new List<Product>();
            foreach (var csvItem in csvrecords)
            {
                var product = new Product
                {
                    Name = csvItem.Name,
                    Brand = csvItem.Brand,
                    Price = csvItem.Price,
                    Quantity = csvItem.Quantity,
                    ProductType = csvItem.ProductType,
                    PartnerId = csvItem.PartnerId,
                };
                products.Add(product);  
            }

            using var context = new ProductManagerContext();
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Comma-separated string file (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                var records = new List<ProductCsvModel>();

                using (var writer = new StreamWriter(saveFileDialog.FileName))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }
            }
        }
    }
}
