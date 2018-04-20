
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * The BloodComponent is an abstract class from witch all components like Plasma, Trombocytes and RedBloodCells derive from. It has three protected values: donationDate, amount and donorEmail.
     */
    public abstract class BloodComponent : Plasma {

        /**
         * The BloodComponent is an abstract class from witch all components like Plasma, Trombocytes and RedBloodCells derive from. It has three protected values: donationDate, amount and donorEmail.
         */
        public BloodComponent() {
        }

        /**
         * The donationDate variable stores inside the date in wich the given component was extracted from the donor.
         */
        protected DateTime donationDate;

        /**
         * The amount variable refers to the quantity of the component stored in the data base.
         */
        protected float amount;

        /**
         * The donorEmail String stores inside the email of the donor from witch this component was taken.
         */
        protected String donorEmail;

        /**
         * 
         */
        protected String status;



        /**
         * Returns the value of donationDate.
         * @return
         */
        public DateTime getDonationDate() {
            // TODO implement here
            return null;
        }

        /**
         * Sets the value of donationDate to val.
         * @param val 
         * @return
         */
        public void setDonationDate(Date val) {
            // TODO implement here
            return;
        }

        /**
         * Returns the value of the amount variable.
         * @return
         */
        public float getAmount() {
            // TODO implement here
            return 0.0f;
        }

        /**
         * Sets the value of the amount variable to val.
         * @param val Float 
         * @return
         */
        public void setAmount(float val) {
            // TODO implement here
            return;
        }

        /**
         * This method is abstract, in this class it should not have any implementation.
         * @return
         */
        protected abstract DateTime getExpirationDate();

        /**
         * Returns the value of the donorEmail variable.
         */
        public void getDonorEmail() { 
            // TODO implement here
        }

        /**
         * Sets the value of donorEmail to email.
         */
        public void setDonorEmail(String email){
            // TODO implement here
        }

    }
}