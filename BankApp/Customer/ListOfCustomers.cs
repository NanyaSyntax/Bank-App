using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class ListOfCustomers
    {
        public static Dictionary<string, Customer> customerList = new Dictionary<string, Customer>();
        public static void AddCustomer(string accountNo, Customer customer)
        {
            customerList.Add(accountNo, customer);
        }
    }
}
