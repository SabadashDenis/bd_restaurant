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
        public static readonly string SQL_Email = "Email";
        public static readonly string SQL_AvatarPath = "AvatarPath";

        private int customerId;
        private string name;
        private string phone;
        private string login;
        private string email;
        private string avatarPath;


        public string GetAvatarPath => $"E:\\Fork\\bd_restaurant\\bd_restaurant\\bd_restaurant\\Images\\{AvatarPath}.png";

        public int CustomerId => customerId;
        public string Name => name;
        public string Phone => phone;
        public string Login => login;
        public string Email => !String.IsNullOrEmpty(email) ? email : "Не указан";
        public string AvatarPath => !String.IsNullOrEmpty(avatarPath) ? avatarPath : "avatar";

        public Customer(int customerId, string name, string phone, string login, string email, string avatarPath)
        {
            this.customerId = customerId;
            this.name = name;
            this.phone = phone;
            this.login = login;
            this.email = email;
            this.avatarPath = avatarPath;
        }

        public override string ToString()
        {
            return $"CustomerID: {customerId}\nName: {name}\nPhone: {phone}\nLogin: {login}\nEmail: {email}\n";
        }
    }
}
