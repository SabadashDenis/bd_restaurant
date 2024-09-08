using bd_restaurant.Scripts;
using bd_restaurant.Scripts.SQLTablesData;
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
        private List<FoodItem> _foodItemsInCart = new();
        public List<FoodItem> GetFoodInCart => _foodItemsInCart;

        public VisitorWindow()
        {
            InitializeComponent();

            SetDishesPage();
        }

        private void SetDishesPage()
        {
            var dishesPage = new Dishes();

            dishesPage.OnItemAddToCartClicked += AddFoodToCart;

            MainFrame.Content = dishesPage;

        }

        private void AddFoodToCart(FoodItem food)
        {
            _foodItemsInCart.Add(food);
        }

        private void OnPayClicked()
        {
            RestaurantSQLConnection.CreateNewOrder(UserData.UserID, _foodItemsInCart);
            _foodItemsInCart.Clear();
            SetOrderPage();
        }

        private void OnRemoveClicked(OrderDetail orderDetail)
        {
            var targetFood = _foodItemsInCart.FirstOrDefault(t => t.Name == orderDetail.FoodName);

            if (targetFood != null)
            {
                var index = _foodItemsInCart.IndexOf(targetFood);
                _foodItemsInCart.RemoveAt(index);
            }

            SetOrderPage();
        }

        private void SetOrderPage()
        {
            var orderPage = new Order(_foodItemsInCart);

            orderPage.OnPayClicked += OnPayClicked;
            orderPage.OnRemoveClicked += OnRemoveClicked;

            MainFrame.Content = orderPage;
        }

        private void SetProfilePage()
        {
            MainFrame.Content = new Profile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetDishesPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetOrderPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SetProfilePage();
        }
    }
}
