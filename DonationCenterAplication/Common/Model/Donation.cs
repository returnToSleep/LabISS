using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class Donation
    {
        public virtual int id { get; set; }
        public virtual string donor_Cnp { get; set; }
        //Total quantity (plasma + red + tromb)
        public virtual float quantity { get; set; }
        public virtual int pulse { get; set; }
        public virtual int bloodPressure { get; set; }
        public virtual DateTime donationDate { get; set; }
        public virtual float plasmaQuantity { get; set; }
        public virtual float trombQuantity { get; set; }
        public virtual float redQuantity { get; set; }

        public virtual string pacientName { get; set; }

        public Donation() { }

        public Donation(string donorCnp, float quantity, int pulse, int bloodPressure, DateTime donationDate, float plasmaQuantity, float redQuantity, float trombQuantity)
        {
            this.donor_Cnp = donorCnp;
            this.quantity = quantity;
            this.pulse = pulse;
            this.bloodPressure = bloodPressure;
            this.donationDate = donationDate;

            this.plasmaQuantity = plasmaQuantity;
            this.trombQuantity = trombQuantity;
            this.redQuantity = redQuantity;
        }

        public override string ToString()
        {

            string donatedFor = pacientName != null ? "\nDonat pentru: " + pacientName : "";

            return "Donatia din: " + donationDate.Date.ToString()
                + "\nCantitate recoltata: " + quantity.ToString() + " ml dintre care: \n"
                + "    Celule rosii: " + redQuantity.ToString() + " ml\n"
                + "    Trombocite: " + trombQuantity.ToString() + " ml\n"
                + "    Plasma: " + plasmaQuantity.ToString() + " ml\n"
                + "Presiunea sistolica: " + bloodPressure.ToString() + "mmHg\n"
                + "Puls: " + pulse.ToString() + "bpm"
                + donatedFor;
        }



    }



}
