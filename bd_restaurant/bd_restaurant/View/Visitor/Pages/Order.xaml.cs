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

        public event Action OnPayClicked = delegate { };

        public event Action<OrderDetail> OnRemoveClicked = delegate { };

        public Order(List<FoodItem> foodItemsInCart)
        {
            InitializeComponent();
            SetupTableData(foodItemsInCart);
        }

        private void SetupTableData(List<FoodItem> foodItemsInCart)
        {
            _orderDetails.Clear();

            foreach(var foodItem in foodItemsInCart)
            {
                if (_orderDetails.Any(t => t.FoodName == foodItem.Name))
                {
                    _orderDetails.First(t => t.FoodName == foodItem.Name).Quantity++;
                }
                else
                {
                    _orderDetails.Add(new OrderDetail(foodItem.Name, 1, foodItem.Price)); //добавляем новый OrderDetail
                }
            }

            orderDataGrid.ItemsSource = _orderDetails;
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if (((Button)sender).DataContext is OrderDetail orderDetail)
                {
                    OnRemoveClicked.Invoke(orderDetail);
                }
            }
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            OnPayClicked.Invoke();
            Trace.WriteLine($"[Order Page] Оплата заказа");
        }
    }
}
