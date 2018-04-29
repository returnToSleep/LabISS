
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * This class derives from the BloodComponent class.  It has no specific values to it.
     */
    public class Trombocyte : BloodComponent {

        /**
         * This class derives from the BloodComponent class.  It has no specific values to it.
         */
        public Trombocyte(int id, string donationCenter_id, string donor_cnp, float ammount, DateTime donationDate) : base(id, donationCenter_id, donor_cnp, ammount, donationDate) {}

        public Trombocyte() { }
        
        /**
         * Returns the expiration date of this component. It does this by calculating the lifespan of the component and the date in witch it was taken.
         * @return
         */
        public override DateTime getExpirationDate()
        {
            return donationDate.AddDays(5);
        }

        public override string ToString()
        {
            return "Trombocytes:\n" + base.ToString();
        }
    }
}