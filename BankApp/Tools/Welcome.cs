using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp
{
    internal class Welcome
    {
        public void WelcomeUser()
        {
            Console.WriteLine("WELCOME TO .NET BANK APP");
            Console.WriteLine(" ");
            Console.WriteLine("Press 1 to create account\nPress 2 to login");
            
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateAccount.CreateCustomerAccount();
                    break;

                case "2":
                    Login.LoginUser();
                    break;

            }

        }
        public static void Options()
        {
            Console.WriteLine("WELCOME TO .NET BANK APP");
            Console.WriteLine("Press 1 to deposit\nPress 2 to withdraw");
            Console.WriteLine("Press 3 to transfer\nPress 4 to print account statement");
            Console.WriteLine("Press 5 to check balance \nPress 6 to create another account");
            Console.WriteLine("Press 7 to log in to another account\nPress 8 to exit");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Logger.Log("Input amount to deposit");
                    string inputAmount = Console.ReadLine();

                    double amount = Convert.ToDouble(inputAmount);
                    
                    Transactions.Deposit(amount);
                    Options();
                    break;

                case "2":
                    Logger.Log("Input amount to withdraw");
                    string inputWithdrawAmount = Console.ReadLine();
                    double amountToWithdraw = Convert.ToDouble(inputWithdrawAmount);

                    Transactions.Withdraw(amountToWithdraw);
                    Options();
                    break;

                case "3":
                    Logger.Log("Input amount to Transfer");
                    double transferAmount = double.Parse(Console.ReadLine());
                    Transactions.Transfer(transferAmount);
                    Options();
                    break;

                case "4":
                    AccountStatement.PrintAccountStatement();
                    Options();
                    break;

                case "5":
                    double bal = Transactions.CheckBalance();
                    Console.Clear();
                    Logger.Log($"Your current balance is {bal}");
                    Options();
                    break;

                case "6":
                    CreateAccount.CreateCustomerAccount();
                    break;

                case "7":
                    Login.LoginUser();
                    break;
                    

            }

        }
    }
}