using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Validation
    {

        public static string ValidatePassword(string pass)
        {
            string bv = pass;
            string pattern = @"^(?=.*[a-zA-Z0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,}$";


            if (!Regex.IsMatch(bv, pattern))
            {
                Console.WriteLine("Password should be minimum 6 characters that include alphanumeric and at least one special characters");
                bv = Console.ReadLine();
                ValidatePassword(bv);
            }
            return bv;
        }

        public static string ValidateNumber(string bvn)
        {
            string bv = bvn;
            bool valid = Regex.IsMatch(bvn, @"^[0-9]+$");
            if (!valid)
            {
                Console.WriteLine("Phone number must contain only numbers");
                bv = Console.ReadLine();
                ValidateNumber(bv);
            }

            if (bv.Length != 11)
            {
                Console.WriteLine("Phone number must be at least 11 digits");
                bv = Console.ReadLine();
                ValidateNumber(bv);
            }

            return bv;
        }

        public static string ValidateBVN(string bvn)
        {
            string bv = bvn;
            bool valid = Regex.IsMatch(bvn, @"^[0-9]+$");
            if (!valid)
            {
                Console.WriteLine("BVN must contain only numbers");
                bv = Console.ReadLine();
                ValidateBVN(bv);
            }

            if (bv.Length != 11)
            {
                Console.WriteLine("BVN must be at least 11 digits");
                bv = Console.ReadLine();
                ValidateBVN(bv);
            }

            return bv;
        }

        public static string ValidateName(string name)
        {
            string nam = name;
            bool valid = Regex.IsMatch(name, @"^[A-Za-z]+$");
            if (!valid)
            {
                Console.WriteLine("Name can only contain letters. Try again");
                nam = Console.ReadLine();
                ValidateName(nam);
            }
            return char.ToUpper(nam[0]) + nam.Substring(1);
        }

        public static string IsValidEmail(string email)
        {
            string em = email;
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(em, pattern))
            {
                Console.WriteLine("Email should be written with the correct format");
                em = Console.ReadLine();
                IsValidEmail(em);
            }
            return em;
        }
    }
}
        
    


           
    

