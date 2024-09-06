using bd_restaurant.Scripts.SQLTablesData;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace bd_restaurant.Scripts
{
    public class RestaurantSQLConnection
    {
        #region SQL Connection

        public static readonly string ConnectionString = "Server=DESKTOP-J846AH2;Database=restaurant;Trusted_Connection=True;TrustServerCertificate=True";

        private static SqlConnection connection = new(ConnectionString);
        #endregion

        #region SQL Requests
        private static readonly string SelectCustomersRequest = "SELECT * FROM Customer";

        private static readonly string CustomerExistsRequest = "SELECT dbo.CheckCustomerExists(@Login)";

        private static readonly string StaffExistsRequest = "SELECT dbo.CheckStaffExists(@Login)";

        private static readonly string ValidateUserRequest = "SELECT dbo.CheckUserCredentials(@Login, @Password)";

        private static readonly string DeleteOrdeItemRequest = "DeleteOrderItem";

        private static readonly string CustomerLastOrderDetailsRequest = "SELECT * FROM dbo.GetLastOrderDetailsByCustomer(@CustomerID)";

        private static readonly string AddFoodToOrderRequest = "AddFoodToOrder";

        private static readonly string SelectFoodRequest = "SELECT * FROM FoodItem";
        #endregion

        private static readonly string Divider = "---------------------------------------";


        public static async Task ConnectDB()
        {
            try
            {
                await connection.OpenAsync();
                Trace.WriteLine($"[SQL] Connection opened! State: {connection.State}");
            }
            catch (SqlException ex)
            {
                Trace.WriteLine($"[SQL] Exception: {ex.Message}");
            }
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new();

            SqlCommand command = new SqlCommand(SelectCustomersRequest, connection);

            try
            {
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader != null)
                    {
                        Trace.WriteLine($"[SQL] Get customers\n{Divider}");

                        while (dataReader.Read())
                        {
                            int customerId = (int)dataReader[Customer.SQL_CustomerId];
                            string name = dataReader[Customer.SQL_Name].ToString() ?? String.Empty;
                            string phone = dataReader[Customer.SQL_Phone].ToString() ?? String.Empty;

                            var customer = new Customer(customerId, name, phone);

                            customers.Add(customer);

                            Trace.WriteLine($"{customer.ToString()}\n{Divider}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Trace.WriteLine($"[SQL] Exception: {ex.Message}");
            }


            return customers;
        }

        public static bool IsCustomer(string login)
        {
            using (SqlCommand command = new SqlCommand(CustomerExistsRequest, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Login", login);
                    var result = (bool)command.ExecuteScalar();

                    Trace.WriteLine($"[SQL] Is Customer Exists => {result}\n{Divider}");
                    return result;
                }
                catch (SqlException ex)
                {
                    Trace.WriteLine($"[SQL] Exception: {ex.Message}");
                }
            }

            return false;
        }

        public static bool IsStaff(string login)
        {
            using (SqlCommand command = new SqlCommand(StaffExistsRequest, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Login", login);
                    var result = (bool)command.ExecuteScalar();

                    Trace.WriteLine($"[SQL] Is Staff Exists => {result}\n{Divider}");
                    return result;
                }
                catch (SqlException ex)
                {
                    Trace.WriteLine($"[SQL] Exception: {ex.Message}");
                }
            }

            return false;
        }

        public static bool ValidateCredentials(string login, string password)
        {
            using (SqlCommand command = new SqlCommand(ValidateUserRequest, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    var result = (bool)command.ExecuteScalar();

                    Trace.WriteLine($"[SQL] Validate user credentials => {result}\n{Divider}");
                    return result;
                }
                catch (SqlException ex)
                {
                    Trace.WriteLine($"[SQL] Exception: {ex.Message}");
                }
            }

            return false;
        }

        public static List<OrderDetail> GetLastOrderInfo(int customerId)
        {
            List<OrderDetail> orderDetails = new();
            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand(CustomerLastOrderDetailsRequest, connection);
            command.Parameters.AddWithValue("@CustomerID", customerId);

            try
            {
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader != null)
                    {
                        Trace.WriteLine($"[SQL] Get last order details\n{Divider}");

                        while (dataReader.Read())
                        {
                            int id = (int)dataReader[OrderDetail.SQL_OrderItemID];
                            int orderId = (int)dataReader[OrderDetail.SQL_OrderID];
                            int foodId = (int)dataReader[OrderDetail.SQL_FoodID];
                            string foodName = dataReader[OrderDetail.SQL_FoodName].ToString() ?? String.Empty;
                            int quantity = (int)dataReader[OrderDetail.SQL_Quantity];
                            decimal itemPrice = (decimal)dataReader[OrderDetail.SQL_ItemPrice];
                            decimal totalPrice = (decimal)dataReader[OrderDetail.SQL_TotalPrice];

                            var orderDetail = new OrderDetail(id, orderId, foodId, foodName, quantity, (float)itemPrice, (float)totalPrice);

                            orderDetails.Add(orderDetail);

                            Trace.WriteLine($"{orderDetail.ToString()}\n{Divider}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Trace.WriteLine($"[SQL] Exception: {ex.Message}");
            }


            return orderDetails;
        }

        public static void DeleteOrderItem(int orderItemId)
        {
            using (SqlCommand command = new SqlCommand(DeleteOrdeItemRequest, connection))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderItemId", orderItemId);
                    command.ExecuteNonQuery();

                    Trace.WriteLine($"[SQL] Delete order item => ID[{orderItemId}]\n{Divider}");
                }
                catch (SqlException ex)
                {
                    Trace.WriteLine($"[SQL] Exception: {ex.Message}");
                }
            }
        }

        public static void AddFoodToOrder(int orderId, int foodId, int quantity)
        {
            using (SqlCommand command = new SqlCommand(AddFoodToOrderRequest, connection))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.Parameters.AddWithValue("@FoodID", foodId);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    command.ExecuteNonQuery();

                    Trace.WriteLine($"[SQL] Add food to order => FoodID[{foodId}] OrderID[{orderId}]\n{Divider}");
                }
                catch (SqlException ex)
                {
                    Trace.WriteLine($"[SQL] Exception: {ex.Message}");
                }
            }
        }

        public static List<FoodItem> GetAllFoodItems()
        {
            List<FoodItem> foodItems = new();

            SqlCommand command = new SqlCommand(SelectFoodRequest, connection);

            try
            {
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader != null)
                    {
                        Trace.WriteLine($"[SQL] Get food\n{Divider}");

                        while (dataReader.Read())
                        {
                            int foodItemId = (int)dataReader[FoodItem.SQL_FoodItemID];
                            string name = dataReader[FoodItem.SQL_Name].ToString() ?? String.Empty;
                            int countValue = (int)dataReader[FoodItem.SQL_CountValue];
                            string measure = dataReader[FoodItem.SQL_Measure].ToString() ?? String.Empty;
                            float price = (float)(decimal)dataReader[FoodItem.SQL_Price];

                            var foodItem = new FoodItem(foodItemId, name, countValue, measure, price);

                            foodItems.Add(foodItem);

                            Trace.WriteLine($"{foodItem.ToString()}\n{Divider}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Trace.WriteLine($"[SQL] Exception: {ex.Message}");
            }


            return foodItems;
        }
    }
}
