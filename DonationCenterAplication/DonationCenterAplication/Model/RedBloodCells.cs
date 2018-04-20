
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * This class derives from the BloodComponent class.  It has two variables special to it: type: String and rH: Boolean.
     */
    public class RedBloodCells : BloodComponent {

        /**
         * This class derives from the BloodComponent class.  It has two variables special to it: type: String and rH: Boolean.
         */
        public RedBloodCells() {
        }

        /**
         * The type variable is a String and represents the type of the plasma component.
         */
        private String type;

        /**
         * The rH variable stores the type of rH, positive or negative.
         */
        private Boolean rH;


        /**
         * Returns the expiration date of this component. It does this by calculating the lifespan of the component and the date in witch it was taken.
         * @return
         */
        public DateTime getExpirationDate() {
            // TODO implement here
            return null;
        }

        /**
         * Returns the value of the rH variable.
         * @return
         */
        public Boolean getRH() {
            // TODO implement here
            return null;
        }

        /**
         * Sets the value of the rH variable to newRH.
         * @param newRh
         */
        public void setRH(Boolean newRh) {
            // TODO implement here
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
         * Sets the value of the type variable to newType.
         * @param newType
         */
        public void setType(String newType) {
            // TODO implement here
        }

    }
}