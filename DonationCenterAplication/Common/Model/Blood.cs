
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Model{
    /**
     * The Blood class is formed from the three blood components, Plasma, Trombocytes and RedBloodCells. It also has the type and rH for these components.
     */
    public class Blood {

        /**
         * The Blood class is formed from the three blood components, Plasma, Trombocytes and RedBloodCells. It also has the type and rH for these components.
         */
        public Blood(float amount, bool rH, string type, string donorEmail) {
            this.rH = rH;
            this.type = type;
            this.redBloodCells = new RedBloodCells(DateTime.Now, 44.5f * amount / 100, donorEmail, "WHAT THE HELL IS STATUS FOR?!", type, rH);
            this.plasma = new Plasma(DateTime.Now, 54.5f * amount / 100, donorEmail, "REALLY NOW, WHAT IS STATUS?", type);
            this.trombocytes = new Trombocytes(DateTime.Now, amount / 100, donorEmail, "I GIVE UP");
        }

        /**
         * The rH variable stores the type of rH, positive or negative. It must be the same as in the RedBloodCells component.
         */
        private bool rH;

        /**
         * The type variable is a string and represents the type of the plasma component. It must be the same as in the RedBloodCells and Plasma components.
         */
        private string type;

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
        private string donateTo;



        /**
         * Returns the value of the rH variable.
         * @return
         */
        public bool getRh() {
            return this.rH;
        }

        /**
         * Sets the value of the rH variable to val.
         * @param val 
         * @return
         */
        public void setRh(bool val) {
            this.rH = val;
        }

        /**
         * Returns the value of the type variable.
         * @return
         */
        public string getType() {
            return this.type;
        }

        /**
         * Sets the value of the rH variable to val.
         * @param val 
         * @return
         */
        public void setType(string val) {
            this.type = val;
        }

        public override string ToString()
        {
            return redBloodCells + "\n" + plasma + "\n" + trombocytes;
        }
    }
}