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
        public static readonly string Divider = "---------------------------------------";

        public static readonly string ConnectionString = "Server=DESKTOP-J846AH2;Database=restaurant;Trusted_Connection=True;TrustServerCertificate=True";

        public static readonly string SelectCustomers = "SELECT * FROM Customer";

        private static SqlConnection connection = new(ConnectionString);

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

            SqlCommand command = new SqlCommand(SelectCustomers, connection);

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
    }
}
