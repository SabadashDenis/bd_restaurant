using bd_restaurant.Scripts;
using bd_restaurant.View;
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

namespace bd_restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ConnectDB();
        }

        private async Task ConnectDB()
        {
            await RestaurantSQLConnection.ConnectDB();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            VisitorWindow visitorWindow = new VisitorWindow();
            visitorWindow.Show();
            Hide();
        }
    }
}
