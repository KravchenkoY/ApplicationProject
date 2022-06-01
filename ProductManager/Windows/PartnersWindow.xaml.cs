using Microsoft.EntityFrameworkCore;
using ProductManager.Extensions;
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
    /// Interaction logic for PartnersWindow.xaml
    /// </summary>
    public partial class PartnersWindow : Window
    {
        public PartnersWindow()
        {
            InitializeComponent();
            using var context = new ProductManagerContext();
            var partners = context.Partners.Include(x=>x.PartnerType).ToList();
            partnerGrid.ItemsSource = partners.ToViewModelList();
        }

        private void btnAddPartner_Click(object sender, RoutedEventArgs e)
        {
            AddPartnerWindow addPartnerWindow = new AddPartnerWindow();
            addPartnerWindow.Show();
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
