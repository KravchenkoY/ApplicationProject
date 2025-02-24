﻿using System;
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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void btnManagement_Click(object sender, RoutedEventArgs e)
        {
            ManagementWindow managementWindow = new ManagementWindow();
            managementWindow.Show();
            Hide();
        }

        private void btnOverview_Click(object sender, RoutedEventArgs e)
        {
            OverviewWindow overviewWindow = new OverviewWindow();
            overviewWindow.Show();
            Hide();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.Show();
            Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MemoryCache.Default.Remove("userId");
            MemoryCache.Default.Remove("userRoleId");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
