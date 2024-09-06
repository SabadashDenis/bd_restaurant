using bd_restaurant.Scripts.SQLTablesData;
using bd_restaurant.Scripts;
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
using System.Diagnostics;

namespace bd_restaurant.View.Visitor.Pages
{
    /// <summary>
    /// Логика взаимодействия для Dishes.xaml
    /// </summary>
    public partial class Dishes : Page
    {
        private List<FoodItem> _foodItems = new();

        public Dishes()
        {
            InitializeComponent();
            SetupTableData();
        }

        private void SetupTableData()
        {
            _foodItems = RestaurantSQLConnection.GetAllFoodItems();
            FoodItemsControl.ItemsSource = _foodItems;
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            FoodItem selectedItem = button.DataContext as FoodItem;

            if (selectedItem != null)
            {
                var lastOrder = RestaurantSQLConnection.GetLastOrderInfo(1).First();
                RestaurantSQLConnection.AddFoodToOrder(lastOrder.OrderId, selectedItem.FoodItemId, 1);
            }
        }
    }
}
