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
    /// Interaction logic for AddPartnerWindow.xaml
    /// </summary>
    public partial class AddPartnerWindow : Window
    {
        public AddPartnerWindow()
        {
            InitializeComponent();
            using var context = new ProductManagerContext();
            var types = context.PartnerTypes.ToList();
            comboBoxPartnerType.DataContext = types;
        }

        private void btnSubmitProduct_Click(object sender, RoutedEventArgs e)
        {
            var partner = new Partner
            {
                Name = txtBoxName.Text,
                LastName = txtBoxLastName.Text,
                Phone = txtBoxPhone.Text,
                Address = txtBoxAddress.Text,
                City = txtBoxCity.Text,
                PostalCode = txtBoxPostalCode.Text,
                Country = txtBoxCountry.Text,
                PartnerTypeId = (int)comboBoxPartnerType.SelectedValue
            };
            using var context = new ProductManagerContext();
            context.Partners.Add(partner);
            context.SaveChanges();
            MessageBox.Show("Partner has been added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            GoBack();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
        private void GoBack()
        {
            PartnersWindow partnersWindow = new PartnersWindow();
            partnersWindow.Show();
            Hide();
        }
    }
}
