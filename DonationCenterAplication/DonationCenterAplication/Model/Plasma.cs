
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
        public Plasma() {
        }

        /**
         * The type variable is a String and represents the type of the plasma component.
         */
        private String type;



        /**
         * Returns the expiration date of this component. It does this by calculating the lifespan of the component and the date in witch it was taken.
         * @return
         */
        public DateTime getExpirationDate() {
            // TODO implement here
            return null;
        }

        /**
         * Returns the value of the type variable.
         * @return
         */
        public String getType() {
            // TODO implement here
            return null;
        }

        /**
         * Sets the type variable to newType.
         * @param newType
         */
        public void setType(String newType) {
            // TODO implement here
        }

    }
}