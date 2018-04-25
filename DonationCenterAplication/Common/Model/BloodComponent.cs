
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * The BloodComponent is an abstract class from witch all components like Plasma, Trombocytes and RedBloodCells derive from. It has three protected values: donationDate, amount and donorEmail.
     */
    public abstract class BloodComponent{
        public BloodComponent(DateTime donationDate, float amount, string donorEmail, string status)
        {
            this.donationDate = donationDate;
            this.amount = amount;
            this.donorEmail = donorEmail;
            this.status = status;
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
         * The donorEmail string stores inside the email of the donor from witch this component was taken.
         */
        protected string donorEmail;

        /**
         * 
         */
        protected string status;



        /**
         * Returns the value of donationDate.
         * @return
         */
        public DateTime getDonationDate() {
            return this.donationDate;
        }

        /**
         * Sets the value of donationDate to val.
         * @param val 
         * @return
         */
        public void setDonationDate(DateTime val) {
            this.donationDate = val;
        }

        /**
         * Returns the value of the amount variable.
         * @return
         */
        public float getAmount() {
            return this.amount;
        }

        /**
         * Sets the value of the amount variable to val.
         * @param val Float 
         * @return
         */
        public void setAmount(float val) {
            this.amount = val;
        }

        /**
         * This method is abstract, in this class it should not have any implementation.
         * @return
         */
        public abstract DateTime getExpirationDate();

        /**
         * Returns the value of the donorEmail variable.
         */
        public string getDonorEmail() {
            return this.donorEmail;
        }

        /**
         * Sets the value of donorEmail to email.
         */
        public void setDonorEmail(string email){
            this.donorEmail = email;
        }

        public override string ToString()
        {
            return "Donated on:\t" + donationDate + "\nAmount:\t" + amount + "\nDonor Email:\t" + donorEmail;
        }
    }
}