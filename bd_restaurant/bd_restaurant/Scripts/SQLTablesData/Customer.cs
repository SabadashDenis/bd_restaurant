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
        public static readonly string SQL_Login = "Login";

        private int customerId;
        private string name;
        private string phone;
        private string login;

        public int CustomerId => customerId;
        public string Name => name;
        public string Phone => phone;
        public string Login => login;

        public Customer(int customerId, string name, string phone, string login)
        {
            this.customerId = customerId;
            this.name = name;
            this.phone = phone;
            this.login = login;
        }

        public override string ToString()
        {
            return $"CustomerID: {customerId}\nName: {name}\nPhone: {phone}\nLogin: {login}\n";
        }
    }
}
