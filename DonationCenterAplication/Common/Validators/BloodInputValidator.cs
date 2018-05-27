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
                err += "Cantitatea de plasma este invalida\n";
            }
            try
            {
                float.Parse(trombQ);
            }
            catch
            {
                err += "Cantitatea de trombotire este invalida\n";
            }
            try
            {
                float.Parse(redQ);
            }
            catch
            {
                err += "Cantitatea de celule rosii este invalida\n";
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
                    err += "Cantitatea totala de sange nu poate sa depaseasca 500ml";
                }
                if (sum < 450)
                {
                    err += "Cantitate totala de sange nu poate fii mai mica de 450ml";
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
                err += "Pulsul este invalid\n";
            }
            try
            {
                int.Parse(pressure);
            }
            catch
            {
                err += "Presiunea este invalida\n";
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
                    err += "Presiunea sistolica este prea mica pentru ca donatorul sa fie apt\n";
                }

                if (pressInt > 180)
                {
                    err += "Presiunea sistolica este prea mare pentru ca donatorul sa fie apt\n";
                }

                if (pulseInt > 160)
                {
                    err += "Pulsul este prea mare ptrnu ca donatorul sa fie apt\n";
                }

                if (pulseInt < 0)
                {
                    err += "Donatorun nu are puls!\n";
                }

                return err;
            }
            return err;
        }

    }
}
