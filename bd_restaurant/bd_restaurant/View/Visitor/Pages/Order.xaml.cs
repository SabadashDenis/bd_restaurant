using bd_restaurant.Scripts;
using bd_restaurant.Scripts.SQLTablesData;
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

            _orderDetails = RestaurantSQLConnection.GetLastOrderInfo(1);
            orderDataGrid.ItemsSource = _orderDetails;
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            // Получаем кнопку, на которую нажали
            Button button = sender as Button;
            if (button != null)
            {
                // Получаем данные о строке
                var order = button.DataContext as OrderDetail; // Замените YourDataType на ваш тип данных
                if (order != null)
                {
                    // Здесь вы можете обработать удаление
                    // Например, вызовите метод для удаления элемента из коллекции
                    _orderDetails.Remove(order);
                }
            }
        }
    }
}
