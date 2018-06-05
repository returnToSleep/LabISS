using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Validators
{
    public sealed class BloodInputValidator
    {

        private static string validateQuantities(string plasmaQ, string trombQ, string redQ)
        {

            string err = "";

            try
            {
                float.Parse(plasmaQ);
            }
            catch
            {
                err += "The plasma quantity is invalid\n";
            }
            try
            {
                float.Parse(trombQ);
            }
            catch
            {
                err += "The trombocyte quantity is invalid\n";
            }
            try
            {
                float.Parse(redQ);
            }
            catch
            {
                err += "The red cells quantity is invalid\n";
            }

            return err;
        }

        public static string validateBlood(string plasmaQ, string trombQ, string redQ)
        {

            string err = validateQuantities(plasmaQ, trombQ, redQ);

            if (err == "")
            {
                float sum = float.Parse(plasmaQ) + float.Parse(trombQ) + float.Parse(redQ);

                if (sum > 500)
                {
                    err += "The combined quantities must not exceed 500ml";
                }
                if (sum < 450)
                {
                    err += "The combined quantities must not be below 450ml";
                }

                return err;
            }
            return err;
        }

        private static string validateInts(string pulse, string pressure)
        {

            string err = "";

            try
            {
                int.Parse(pulse);
            }
            catch
            {
                err += "The pulse is invalid\n";
            }
            try
            {
                int.Parse(pressure);
            }
            catch
            {
                err += "The pressure is invalid\n";
            }

            return err;
        }


        public static string validatePulsePressure(string pulse, string pressure)
        {
            string err = validateInts(pulse, pressure);

            if (err == "")
            {

                int pressInt = int.Parse(pressure);
                int pulseInt = int.Parse(pulse);

                if (pressInt < 100)
                {
                    err += "The sistolic pressure is too low for the donor to be fit\n";
                }

                if (pressInt > 180)
                {
                    err += "The sistolic pressure is to high for the donor to be fit\n";
                }

                if (pulseInt > 160)
                {
                    err += "The pulse is to high for the donor to be apt\n";
                }

                if (pulseInt < 0)
                {
                    err += "The donor does not have a pulse!\n";
                }

                return err;
            }
            return err;
        }

    }
}
