using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class CreateAccount : ListOfCustomers
    {

        public static List<KeyValuePair<string, string[]>> statements = AccountStatement.statements;
        public static void CreateCustomerAccount()
        {
            Console.WriteLine("Input your BVN");
            string bvn = Console.ReadLine();
            bvn = Validation.ValidateBVN(bvn);

            Console.WriteLine("Input your firstname");
            string firstname = Console.ReadLine();
            firstname = Validation.ValidateName(firstname);


            Console.WriteLine("Input your lastname");
            string lastname = Console.ReadLine();
            lastname = Validation.ValidateName(lastname);

            Console.WriteLine("Input your phone number");
            string phoneNumber = Console.ReadLine();
            phoneNumber = Validation.ValidateNumber(phoneNumber);

            Console.WriteLine("Input your email");
            string email = Console.ReadLine();
            email = Validation.IsValidEmail(email);

            Console.WriteLine("Input your password");
            string password = Console.ReadLine();
            password = Validation.ValidatePassword(password);

            Console.WriteLine("What type of account do you want to create?\nPress S for savings and C for current account");
            string acctype = Console.ReadLine();
            Console.Clear();

            string accounttype = "";

            if (acctype == "S")
            {
                accounttype = "SAVINGS";
            }
            if (acctype == "C")
            {
                accounttype = "CURRENT";
            }
            //bool found = false;
            foreach (var registeredUsers in customerList)
            {
                Customer user = registeredUsers.Value;
                if(user.GetBVN() == bvn)
                {

                }
            }


            Customer customer = new Customer(firstname, lastname, phoneNumber, email, accounttype, password,bvn);
            string accountNumber = AccountNoGenerator.GenerateNewAccountNumber();

            AddCustomer(accountNumber, customer);


            string[] values = { firstname + " " + lastname,"0", accountNumber, accounttype, "0", "New Account" };
            statements.Add(new KeyValuePair<string, string[]>(accountNumber, values));
            
            Console.WriteLine("Account created successfully. Your account number is " + accountNumber);

            Login.LoginUser();
            Console.Clear();
        }
    }
}
