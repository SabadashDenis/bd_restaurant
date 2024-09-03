using bd_restaurant.Scripts.SQLTablesData;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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

        private static readonly string ValidateUser = "SELECT dbo.CheckUserCredentials(@Login, @Password)";

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
            catch(SqlException ex)
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
            using (SqlCommand command = new SqlCommand(ValidateUser, connection))
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
    }
}
