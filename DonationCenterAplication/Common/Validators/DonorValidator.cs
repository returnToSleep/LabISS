using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Validators
{
    public static class DonorValidator
    {

        //specifier -cnp / -data de nastere

        public static string validateDate(int year, int month, int day, string specifier)
        {
            string err = "";

            err += month > 12 ? "Date of birth " + specifier + "is not valid/n" : "";

            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                err += day > 31 ? "Date of birth " + specifier + "is not valid/n" : "";
            }

            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                err += day > 30 ? "Date of birth " + specifier + "is invalid/n" : "";
            }

            if (month == 2 && year % 4 == 0)
            {
                err += day > 29 ? "Date of birth " + specifier + "is invalid/n" : "";
            }

            if (month == 2 && year % 4 != 0)
            {
                err += day > 28 ? "Date of birth " + specifier + "is invalid/n" : "";
            }


            return err;
        }

        public static string validateCNP(string cnp) {

            string err = "";

            var regexItem = new Regex("^[0-9\\s]*$");
            err += regexItem.IsMatch(cnp) ? "The CNP can not contail letters\n" : "";

            err += cnp[0] != '1' && cnp[0] != '2' ? "The first digit of the CNP should be 1 or 2" : "";

            string[] splitCnp = cnp.Split(' ');

            string cnpDate = splitCnp[1];

            int year = cnpDate[0] * 10 + cnpDate[1];

            if (year > DateTime.Today.Year)
            {
                year += 1900;
            }
            else
            {
                year += 2000;
            }

            int month = cnpDate[2] * 10 + cnpDate[3];
            int day = cnpDate[4] * 10 + cnpDate[5];

            return err + validateDate(year, month, day, "CNP");
        }

        //Donor validation + birthdate

        public static string validate(Donor donor)
        {
            string err = "";

            err += donor.name == "" ? "The name field must be filled in\n" : "";
            err += donor.cnp == "         " ? "The CNP filed must be filled in\n" : "";
            err += donor.email == "" ? "The e-mail filed must be filled in\n" : "";

            var regexItem = new Regex("^[a-zA-Z\\s]*$");
            err += regexItem.IsMatch(donor.name) ? "" : "Names can contain only letters\n";

           
            err += donor.email.Contains("@") && donor.email.Contains(".") ? "": "The e-mail is invalid\n";

            err += validateDate(donor.birthdate.Year, donor.birthdate.Month, donor.birthdate.Day, "Date of birth fields");
            return err;
        }
    }
}
