using bd_restaurant.Scripts.SQLTablesData;
using bd_restaurant.Scripts;
using bd_restaurant.View.Visitor.Pages;
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
    /// Логика взаимодействия для StaffOrdersPage.xaml
    /// </summary>
    public partial class StaffOrdersPage : Page
    {
        public ObservableCollection<OrderContainer> Orders { get; set; }

        public StaffOrdersPage()
        {
            InitializeComponent();
            DataContext = this;
            SetupStaffOrders();
        }

        private void SetupStaffOrders()
        {
            Orders = new ObservableCollection<OrderContainer>();

            var orders = RestaurantSQLConnection.GetStaffOrders(UserData.UserID);

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

                orderContainer.ReadyFoodChanged += CheckReadyOrders;
            }

            Trace.WriteLine($"[Staff Orders Page] Orders count: {Orders.Count}");
        }

        private void CheckReadyOrders()
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                var isReady = true;

                foreach (var detail in Orders[i].OrderDetails)
                {
                    if (!detail.IsSelected)
                        isReady = false;
                }

                if (isReady)
                {
                    RestaurantSQLConnection.SetOrderReady(Orders[i].OrderID);
                    Orders.Remove(Orders[i]);
                }

            }
        }
    }
}
