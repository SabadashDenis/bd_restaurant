using bd_restaurant.Scripts;
using bd_restaurant.Scripts.SQLTablesData;
using bd_restaurant.View.Staff.Pages;
using bd_restaurant.View.Visitor.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace bd_restaurant.View.Staff
{
    /// <summary>
    /// Логика взаимодействия для StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
        {
            InitializeComponent();
            SetupMyOrdersPage();
        }

        private void AllOrders(object sender, RoutedEventArgs e)
        {
            var allOrdersPage = new OrdersPage();

            MainFrame.Content = allOrdersPage;
        }

        private void MyOrders(object sender, RoutedEventArgs e)
        {
            SetupMyOrdersPage();
        }

        private void SetupMyOrdersPage()
        {
            var staffOrdersPage = new StaffOrdersPage();

            MainFrame.Content = staffOrdersPage;
        }

        public void SetupAllOrdersPage()
        {
            var allOrdersPage = new OrdersPage();

            MainFrame.Content = allOrdersPage;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            UserData.UserID = -1;
            UserData.UserName = String.Empty;

            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            Close();

            Trace.Write($"[App] Log out.");
        }
    }
}
