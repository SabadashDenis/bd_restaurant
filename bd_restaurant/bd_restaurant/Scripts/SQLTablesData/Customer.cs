using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_restaurant.Scripts.SQLTablesData
{
    public class Customer
    {
        public static readonly string SQL_CustomerId = "CustomerID";
        public static readonly string SQL_Name = "Name";
        public static readonly string SQL_Phone = "Phone";

        private int customerId;
        private string name;
        private string phone;

        public int CustomerId => customerId;
        public string Name => name;
        public string Phone => phone;

        public Customer(int customerId, string name, string phone)
        {
            this.customerId = customerId;
            this.name = name;
            this.phone = phone;
        }

        public override string ToString()
        {
            return $"CustomerID: {customerId}\nName: {name}\nPhone: {phone}";
        }
    }
}
