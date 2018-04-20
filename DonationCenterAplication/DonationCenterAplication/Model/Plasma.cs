using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * This class derives from the BloodComponent class.  It has one specific variable named type to it.
     */
    public class Plasma : BloodComponent {
        /**
         * This class derives from the BloodComponent class.  It has one specific variable named type to it.
         */
        public Plasma(DateTime donationDate, float amount, string donorEmail, string status, string type) : base(donationDate, amount, donorEmail, status) {
            this.type = type;
        }

        /**
         * The type variable is a String and represents the type of the plasma component.
         */
        private string type;


        /**
         * Returns the expiration date of this component. It does this by calculating the lifespan of the component and the date in witch it was taken.
         * @return
         */
        public override DateTime getExpirationDate() {
            return donationDate.AddMonths(3);
        }

        /**
         * Returns the value of the type variable.
         * @return
         */
        public string getType() {
            return this.type;
        }

        /**
         * Sets the type variable to newType.
         * @param newType
         */
        public void setType(string newType) {
            this.type = newType;
        }

        public override string ToString()
        {
            return "Plasma:\nType: " + type + "\n" + base.ToString();
        }
    }
}