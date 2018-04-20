
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * The Blood class is formed from the three blood components, Plasma, Trombocytes and RedBloodCells. It also has the type and rH for these components.
     */
    public class Blood {

        /**
         * The Blood class is formed from the three blood components, Plasma, Trombocytes and RedBloodCells. It also has the type and rH for these components.
         */
        public Blood() {
        }

        /**
         * The rH variable stores the type of rH, positive or negative. It must be the same as in the RedBloodCells component.
         */
        private Boolean rH;

        /**
         * The type variable is a String and represents the type of the plasma component. It must be the same as in the RedBloodCells and Plasma components.
         */
        private String type;

        /**
         * This is the RedBloodCells component that this blood is made of.
         */
        private RedBloodCells redBloodCells;

        /**
         * This is the Trombocytes component that this blood is made of.
         */
        private Trombocytes trombocytes;

        /**
         * This is the Plasma component that this blood is made of.
         */
        private Plasma plasma;

        /**
         * If the donor decides to donate to someone, the cnp of that person can be stored here
         */
        private String donateTo;








        /**
         * Returns the value of the rH variable.
         * @return
         */
        public Boolean getRh() {
            // TODO implement here
            return null;
        }

        /**
         * Sets the value of the rH variable to val.
         * @param val 
         * @return
         */
        public void setRh(Boolean val) {
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
         * Sets the value of the rH variable to val.
         * @param val 
         * @return
         */
        public void setType(String val) {
            // TODO implement here
            return null;
        }

    }
}