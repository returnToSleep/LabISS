using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Validators
{
    public static class RequestValidator
    {


        private static string validateQuantity(string quantity)
        {

            string err = "";

            try
            {
                float.Parse(quantity);
            }
            catch {
                err += "Invalid quantity\n";
            }
            return err;
        } 

        private static string validateName(string name)
        {
            string err = "";
            var regexItem = new Regex("^[a-zA-Z\\s]*$");
            err += regexItem.IsMatch(name) ? "" : "Names can only contain letters\n";

            return err;
        }

        public static string validateNameQuantity(string name, string quantity)
        {
            return validateName(name) + validateQuantity(quantity);
        } 


    }
}


