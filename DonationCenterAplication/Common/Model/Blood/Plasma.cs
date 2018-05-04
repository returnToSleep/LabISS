using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * This class derives from the BloodComponent class.  It has one specific variable named type to it.
     */
    public class Plasma : BloodComponent{
        
     
        public virtual string antibody { get; set; }
      
        public Plasma() { }

        public Plasma(int id, string antibody, string donationCenter_id, string donor_cnp, float ammount, DateTime donationDate) : base(id, donationCenter_id, donor_cnp, ammount, donationDate)
        {
            this.antibody = antibody;
        }

     
        /**
         * Returns the expiration date of this component. It does this by calculating the lifespan of the component and the date in witch it was taken.
         * @return DateTime
         */
        public override DateTime getExpirationDate() {
            return donationDate.AddMonths(3);
        }

        public override string ToString()
        {
            return "Plasma:\nAntibody: " + antibody + "\nExpiration date: " + this.getExpirationDate().ToString() + base.ToString();
        }
    }
}