using bd_restaurant.Scripts;
using bd_restaurant.Scripts.SQLTablesData;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bd_restaurant.View.Visitor.Pages
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        private List<OrderDetail> _orderDetails = new();

        public Order()
        {
            InitializeComponent();
            SetupTableData();
        }

        private void SetupTableData()
        {
            _orderDetails = RestaurantSQLConnection.GetLastOrderInfo(UserData.UserID);
            orderDataGrid.ItemsSource = _orderDetails;
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if (((Button)sender).DataContext is OrderDetail order)
                {
                    _orderDetails.Remove(order);
                    RestaurantSQLConnection.DeleteOrderItem(order.OrderItemId);
                }
            }

            SetupTableData();
        }
    }
}
