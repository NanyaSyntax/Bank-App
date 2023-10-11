using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Customer
    {
        private string firstname { get; set; }

        private string lastname { get; set; }

        private string phoneNumber { get; set; }

        private string email { get; set; }

        private double balance { get; set; }
        public string accountType { get; set; }

        private string password { get; set; }

        private string BVN { get; set; }

        public Customer(string fname, string lname, string phone, string email, string accountType, string password, string bVN)
        {
            firstname = fname;
            lastname = lname;
            phoneNumber = phone;
            this.email = email;
            this.accountType = accountType;
            balance = 0;
            this.password = password;
            BVN = bVN;
        }

        public string GetFirstname()
        {
            return firstname;
        }

        public string GetLastname()
        {
            return lastname;
        }

        public string GetFullname()
        {
            return GetFirstname() + " " + GetLastname();
        }

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        public string Getemail()
        {
            return email;
        }

        public string GetAccountType()
        {
            return accountType;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetBalance(double amount)
        {
            balance = amount;
        }

        public double GetBalance()
        {
            return balance;
        }

        public string GetBVN()
        {
            return BVN;
        }

    }
}
