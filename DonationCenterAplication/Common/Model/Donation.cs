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
        public virtual int age { get; set; }
        public virtual int weight { get; set; }
        public virtual int pulse { get; set; }
        public virtual int bloodPressure { get; set; }
        public virtual DateTime donationDate { get; set; }

        public Donation() { }

        public Donation(string donorCnp, int age, int weight, int pulse, int bloodPressure, DateTime donationDate)
        {
            this.donor_Cnp = donorCnp;
            this.age = age;
            this.weight = weight;
            this.pulse = pulse;
            this.bloodPressure = bloodPressure;
            this.donationDate = donationDate;
        }

    }



}
