using bd_restaurant.Scripts;
using bd_restaurant.View;
using bd_restaurant.View.Staff;
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
            ValidateUser();
        }

        private void ValidateUser()
        {
            var userLogin = txtUser.Text;
            var userPassword = txtPass.Password;

            if (RestaurantSQLConnection.ValidateCredentials(txtUser.Text, txtPass.Password))
            {
                UserData.UserName = userLogin;

                if (RestaurantSQLConnection.IsCustomer(txtUser.Text))
                {
                    UserData.UserID = RestaurantSQLConnection.GetCustomers().First(t => t.Login == userLogin).CustomerId;

                    VisitorWindow visitorWindow = new VisitorWindow();
                    visitorWindow.Show();
                    Hide();
                }
                else if (RestaurantSQLConnection.IsStaff(txtUser.Text))
                {
                    UserData.UserID = RestaurantSQLConnection.GetStaffs().First(t => t.Login == userLogin).StaffId;

                    StaffWindow staffWindow = new StaffWindow();
                    staffWindow.Show();
                    Hide();
                }

                
               
            }
            else
            {
                txtPass.BorderBrush = Brushes.Red;
                txtUser.BorderBrush = Brushes.Red;

                txtPass.Password = String.Empty;
            }


        }
    }
}
