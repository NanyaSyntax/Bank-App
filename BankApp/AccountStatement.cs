using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class AccountStatement : Logged
    {
       public static List<KeyValuePair<string, string[]>> statements = new List<KeyValuePair<string, string[]>>();


        static void PrintTable()
        {
            Console.Clear();
            Logger.Log("---------------------------------- ACCOUNT STATEMENT -----------------------------------");


            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}",
                          "Customer Name", "   Amount", "Account Number", "Account Type", "Balance", "Remarks");
            Logger.Log("----------------------------------------------------------------------------------------");
        }
        public static void PrintAccountStatement()
        {
            PrintTable();



            foreach (var item in statements)
            {
                if (item.Key == loggedAccount)
                {
                    string[] value = item.Value;
                    Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", $"{value[0]} ", $"{value[1]} ",
                          $"{value[2]} ", $"{value[3]} ", $"{value[4]} ", $"{value[5]}");
                    // Logger.Log(value[0]+ "   |   " + value[1] + "   |   " + value[2] + "   |   " + value[3] + "   |   " + value[4] + "   |   " + value[5]);
                }
            }
        }
    }
}
