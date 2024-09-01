using bd_restaurant.Scripts;
using bd_restaurant.View.Visitor.Pages;
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

namespace bd_restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для VisitorWindow.xaml
    /// </summary>
    public partial class VisitorWindow : Window
    {
        public VisitorWindow()
        {
            InitializeComponent();

            MainFrame.Content = new Dishes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Dishes();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var orderPage = new Order();

            MainFrame.Content = orderPage;
            var customers = RestaurantSQLConnection.GetCustomers();
            orderPage.orderDataGrid.ItemsSource = customers;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Profile();
        }
    }
}
