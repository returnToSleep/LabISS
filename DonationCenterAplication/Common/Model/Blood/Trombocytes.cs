
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * This class derives from the BloodComponent class.  It has no specific values to it.
     */
    [Serializable]
    public class Trombocyte : BloodComponent {

        /**
         * This class derives from the BloodComponent class.  It has no specific values to it.
         */
        public Trombocyte(string donationCenter_id, string donor_cnp, float ammount, DateTime donationDate, string email) : base(donationCenter_id, donor_cnp, ammount, donationDate, email) {}

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
            return "Data expirarii: " + getExpirationDate() + "\nCantitate: " + ammount;

        }
    }
}