
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * The Donor class has all the information needet related to a donor such as: Name, CNP, birthday, address, residence, blood, donationDate, email.
     */
    public class Donor {

        /**
         * The Donor class has all the information needet related to a donor such as: Name, CNP, birthday, address, residence, blood, donationDate, email.
         */
        public Donor(string name, string cnp, DateTime birthdate, Location address, Location residence, Blood blood, string email) {
            this.name = name;
            this.cnp = cnp;
            this.birthdate = birthdate;
            this.address = address;
            this.residence = residence;
            this.blood = blood;
            this.email = email;
        }

        /**
         * The name variable stores the name of the donor.
         */
        private string name;

        /**
         * The cnp variable stores the CNP of the donor as a string
         */
        private string cnp;

        /**
         * The birthdate variable stores the date in which the donor was born.
         */
        private DateTime birthdate;

        /**
         * The address variable stores the current address of the donor.
         */
        private Location address;

        /**
         * The residence variable stores the residence location of the donor.
         */
        private Location residence;

        /**
         * The blood component is the Blood given by the donor.
         */
        private Blood blood;

        /**
         * The donationDate variable stores the date in which the blood was donated.
         */
        private DateTime donationDate;

        /**
         * The email variable stores the email address of the donor.
         */
        private string email;




        /**
         * Returns the value of the name variable.
         * @return
         */
        public string getName() {
            return this.name;
        }

        /**
         * Sets the value of the name variable to newVal.
         * @param newVal 
         * @return
         */
        public void setName(string name) {
            this.name = name;
        }

        /**
         * Returns the value of the cnp variable.
         * @return
         */
        public string getCnp() {
            return cnp;
        }

        /**
         * Sets the value of the cnp variable to newVal.
         * @param newVal 
         * @return
         */
        public void setCnp(string cnp) {
            this.cnp = cnp;
        }

        /**
         * Returns the value of the birthdate variable.
         * @return
         */
        public DateTime getBirthday() {
            return this.birthdate;
        }

        /**
         * Sets the value of the birthdate variable to newVal.
         * @param newVal 
         * @return
         */
        public void setBirthday(DateTime newVal) {
            this.birthdate = newVal;
        }

        /**
         * Returns the value of the address variable.
         * @return
         */
        public Location getAddress() {
            return this.address;
        }

        /**
         * Sets the value of the address variable to newVal.
         * @param newVal 
         * @return
         */
        public void setAddress(Location newVal) {
            this.address = newVal;
        }

        /**
         * Returns the value of the residence variable.
         * @return
         */
        public Location getResidence() {
            return this.residence;
        }

        /**
         * Sets the value of the residence variable to newVal.
         * @param newVal 
         * @return
         */
        public void setResidence(Location newVal) {
            this.residence = newVal;
        }

        /**
         * Returns the value of the blood variable.
         * @return
         */
        public Blood getBlood() {
            return this.blood;
        }

        /**
         * Sets the value of the blood variable to newVal.
         * @param newVal 
         * @return
         */
        public void setBlood(Blood blood) {
            this.blood = blood;
        }

        /**
         * Returns the value of the donationDate variable.
         * @return
         */
        public DateTime getDonationDate() {
            return donationDate;
        }

        /**
         * Sets the value of the donationDate variable to newVal.
         * @param newVal 
         * @return
         */
        public void setDonationDate(DateTime donationDate) {
            this.donationDate = donationDate;
        }

        /**
         * Returns the value of the email variable.
         * @return
         */
        public string getEmail() {
            return email;
        }

        /**
         * Sets the value of the email variable to newVal.
         * @param email 
         * @return
         */
        public void setEmail(string email) {
            this.email = email;
        }

        public override string ToString()
        {
            return "Donor:\nName: " + name + "\t--\tCNP: " + cnp + "\nAge: " + DateTime.Now.Subtract(birthdate) + "\nAddress: " + address
                + "\nResidence: " + residence + "\nEmail: " + email + "\n" + blood;
        }
    }
}