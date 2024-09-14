using bd_restaurant.Scripts;
using bd_restaurant.Scripts.SQLTablesData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace bd_restaurant.View.Staff.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public ObservableCollection<OrderContainer> Orders { get; set; }

        public OrdersPage()
        {
            InitializeComponent();
            DataContext = this;
            SetupOrders();
        }

        private void SetupOrders()
        {
            Orders = new ObservableCollection<OrderContainer>();

            var orders = RestaurantSQLConnection.GetFreeOrders();

            var groupedOrders = orders.GroupBy(order => order.OrderDate);

            foreach (var group in groupedOrders)
            {
                var orderContainer = new OrderContainer(group.First().OrderId);

                var sortedOrderDetails = group.OrderBy(orderDetail => orderDetail.FoodName);

                foreach (var orderDetail in sortedOrderDetails)
                {
                    orderContainer.AddDetail(orderDetail);
                    orderContainer.TotalPrice += orderDetail.ItemPrice;
                }

                Orders.Add(orderContainer);
            }

            Trace.WriteLine($"[Orders Page] Orders count: {Orders.Count}");
        }

        private void AddOrderToStaff(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            OrderContainer selectedItem = button.DataContext as OrderContainer;

            if (selectedItem != null)
            {
                RestaurantSQLConnection.SetupStaffForOrder(selectedItem.OrderID, UserData.UserID);
                Orders.Remove(selectedItem);
            }
        }
    }
}
