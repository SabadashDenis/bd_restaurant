using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_restaurant.Scripts.SQLTablesData
{
    public class Staff
    {
        public static readonly string SQL_StaffId = "StaffID";
        public static readonly string SQL_Name = "Name";
        public static readonly string SQL_JobTitle = "JobTitle";
        public static readonly string SQL_Login = "Login";
        public static readonly string SQL_Password = "Password";
        public static readonly string SQL_Phone = "Phone";
        public static readonly string SQL_Address = "Address";

        private int staffId;
        private string name;
        private string jobTitle;
        private string login;
        private string password;
        private string phone;
        private string address;

        public int StaffId => staffId;
        public string Name => name;
        public string JobTitle => jobTitle;
        public string Login => login;
        public string Password => password;
        public string Phone => phone;
        public string Address => address;

        public Staff(int staffId, string name, string jobTitle, string login, string password, string phone, string address)
        {
            this.staffId = staffId;
            this.name = name;
            this.jobTitle = jobTitle;
            this.login = login;
            this.password = password;
            this.phone = phone;
            this.address = address;
        }

        public override string ToString()
        {
            return $"StaffID: {staffId}\n" +
                $"Name: {name}\n" +
                $"JobTitle: {jobTitle}\n" +
                $"Login: {login}\n" +
                $"Password: {password}\n" +
                $"Phone: {phone}\n" +
                $"Address: {address}\n";
        }
    }
}
