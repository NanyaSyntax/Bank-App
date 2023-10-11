using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Login : Logged
    {
        public static void LoginUser()
        {
            Console.WriteLine("Enter your account number");
            string accountNo = Console.ReadLine();

            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            if (accountNo == null || password == null)
            {
                Console.WriteLine("All fields are required.Try again");
                LoginUser();

            }
            else
            {
                Customer foundCustomer = null;

                var customerList = ListOfCustomers.customerList;
                bool found = false;
                foreach (var item in customerList)
                {
                    if (item.Key == accountNo)
                    {
                        foundCustomer = item.Value;
                        string passwd = foundCustomer.GetPassword();

                        if (password == passwd)
                        {
                            found = true;
                        }
                    }
                }
                if (found)
                {
                    loggedAccount = accountNo;
                    loggedCustomer = foundCustomer;
                    Console.WriteLine("Login Successful!!!");
                    Welcome.Options();
                }
                else
                {
                    Console.WriteLine("Invalid login Details. Try again");
                    LoginUser();
                }
            }
        }
    }
}
