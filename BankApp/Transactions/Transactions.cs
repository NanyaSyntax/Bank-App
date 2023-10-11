using BankApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp
{
    internal class Transactions : Logged
    {
        
        static List<KeyValuePair<string, string[]>> statements = AccountStatement.statements;
        static Dictionary<string, Customer> customerList = ListOfCustomers.customerList;

        public static void Deposit(double amount)
        {
            if (amount > 0)
            {   //loops through saved users to get the particular user
                foreach (var item in customerList)
                {
                    if (item.Key == loggedAccount)
                    {
                        Customer customer = item.Value;
                        double balance = customer.GetBalance();
                        double currentBalance = balance + amount;
                        customer.SetBalance(currentBalance);

                        string[] value = { customer.GetFullname(), amount.ToString(), loggedAccount, customer.GetAccountType(), currentBalance.ToString(), "CREDIT" };

                        //Adds to statement of account
                        statements.Add(new KeyValuePair<string, string[]>(loggedAccount, value));

                        break;
                    }
                }
                Console.Clear();
                Logger.Log($"{amount} has been credited to your account. ");
            }
            else
            {
                Console.Clear();
                Logger.Log("Transaction failed. Invalid amount");
            }
        }


        public static void Withdraw(double amount)
        {

            if (amount > 0)
            {
                double bal = CheckBalance();
                string accountType = GetAccountType();

                if (accountType == "SAVINGS")
                {
                    if ((bal - 1000) >= amount)
                    {
                        Withdrawnow(amount);
                        Logger.Log("Withdrawal successfull");
                    }
                    else
                    {
                        Logger.Log("Insufficient Funds");
                    }
                }
                else if (accountType == "CURRENT")
                {
                    if (bal >= amount)
                    {
                        Withdrawnow(amount);
                        Console.Clear();
                        Logger.Log("Withdrawal successfull");
                    }
                    else
                    {
                        Logger.Log("Insufficient Funds");
                    }
                }
            }
            else
            {
                Console.Clear();
                Logger.Log("Invalid withdrawal amount.");
            }
        }

        public static void Withdrawnow(double amount)
        {
            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    Customer customer = item.Value;
                    double balance = customer.GetBalance();
                    double currentBalance = balance - amount;
                    customer.SetBalance(currentBalance);

                    string[] values = { customer.GetFullname(), amount.ToString(), loggedAccount, customer.GetAccountType(), currentBalance.ToString(), "DEBIT" };

                    statements.Add(new KeyValuePair<string, string[]>(loggedAccount, values));
                    break;
                }
            }
        }

        public static void Transfer(double amount)
        {
            if (amount < 0)
            {
                Logger.Log("Invalid transfer amount.");
            }
            else
            {
                Logger.Log("Input beneficiary account number");
                string beneficiaryAcc = Console.ReadLine();
                if (beneficiaryAcc == loggedAccount)
                {
                    Logger.Log("You cannot transfer to your account.");
                }
                else
                {
                    double balance = loggedCustomer.GetBalance();
                    if (loggedCustomer.GetAccountType() == "SAVINGS")
                    {
                        if ((balance - 1000) < amount)
                        {
                            Console.Clear();
                            Logger.Log("Insufficient funds");
                            return;
                        }
                    }


                    if (balance >= amount)
                    {
                        bool found = false;
                        foreach (var regUsers in customerList)
                        {
                            if (regUsers.Key == beneficiaryAcc)
                            {
                                double currentBalance = balance - amount;
                                loggedCustomer.SetBalance(currentBalance);

                                double beneBalance = regUsers.Value.GetBalance() + amount;
                                regUsers.Value.SetBalance(beneBalance);

                                string[] values = { regUsers.Value.GetFullname(), amount.ToString(), loggedAccount, regUsers.Value.GetAccountType(), currentBalance.ToString(), "CREDIT" };
                                statements.Add(new KeyValuePair<string, string[]>(loggedAccount, values));

                                string[] value = { loggedCustomer.GetFullname(), amount.ToString(), beneficiaryAcc, loggedAccount, loggedCustomer.GetAccountType(), loggedCustomer.GetBalance().ToString(), "DEBIT" };
                                statements.Add(new KeyValuePair<string, string[]>(loggedAccount, values));

                                found = true;
                                break;
                            }
                        }
                        if (found)
                        {
                            Logger.Log("Transfer successful");
                        }
                        else
                        {
                            Logger.Log("Invalid recepient account");
                        }
                    }
                    else
                    {
                        Logger.Log("Insufficient balance");
                    }
                }
            }
        }
        public static double CheckBalance()
        {
            double bal = 0;
            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    Customer customer = item.Value;
                    bal = customer.GetBalance();

                    break;
                }
            }
            return bal;
        }

        public static string GetAccountType()
        {
            string accountType = "";
            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    Customer customer = item.Value;
                    accountType = customer.GetAccountType();

                    break;
                }
            }
            return accountType;
        }
    }
}

