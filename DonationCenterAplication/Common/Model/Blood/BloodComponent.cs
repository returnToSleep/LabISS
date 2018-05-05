using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class BloodComponent
    {
        public virtual string donationCenter_id { get; set; }
        public virtual string donor_cnp { get; set; }
        public virtual float ammount { get; set; }
        public virtual int id { get; set; }
        public virtual DateTime donationDate { get; set; }
        
        //int? - nullable int
        public virtual int? doctor_id { get; set; }

        protected BloodComponent() { }

        public BloodComponent(string donationCenter_id, string donor_cnp, float ammount, DateTime donationDate)
        {
            this.donationCenter_id = donationCenter_id;
            this.donor_cnp = donor_cnp;
            this.ammount = ammount;
            this.donationDate = donationDate;
            this.doctor_id = null;
  
        }

        public virtual DateTime getExpirationDate()
        {
            return this.donationDate;
        }

        public override string ToString()
        {
            return "\n" + this.id + "\n" + this.donationCenter_id + "\n" + this.donor_cnp + "\n" + this.ammount + "\n" + this.donationDate.ToString();
        }

    }
}
