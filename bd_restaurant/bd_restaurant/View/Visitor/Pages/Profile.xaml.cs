using bd_restaurant.Scripts;
using bd_restaurant.Scripts.SQLTablesData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public ObservableCollection<OrderContainer> Orders { get; set; }

        public Profile()
        {
            InitializeComponent();
            SetupOrdersHistory();
            DataContext = this;
            SetupProfile();
        }

        private void SetupOrdersHistory()
        {
            Orders = new ObservableCollection<OrderContainer>();

            var orders = RestaurantSQLConnection.GetOrdersHistory(UserData.UserID);

            var groupedOrders = orders.GroupBy(order => order.OrderId);

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
        }

        public void SetupProfile()
        {
            var customer = RestaurantSQLConnection.GetUserInfo();
            ProfileData.DataContext = customer;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (scrollViewer != null)
            {
                if (e.Delta > 0)
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - 20); // Прокрутка вверх
                else
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + 20); // Прокрутка вниз

                e.Handled = true; // Отменяем дальнейшую обработку события
            }
        }
    }
}
