
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Controller{
    /**
     * 
     */
    public class DonorController {

        /**
         * 
         */
        public DonorController() {
        }

        /**
         * 
         */
        private Donor donor;


        /**
         * @return
         */
        public Donor getDonor() {
            // TODO implement here
            return null;
        }

        /**
         * @param newVal 
         * @return
         */
        public void setDonor(Donor newVal) {
            // TODO implement here
            return;
        }

        /**
         * @param name 
         * @param cnp 
         * @param birtdhDate 
         * @param address 
         * @param residence 
         * @param blood 
         * @param donationDate 
         * @param email 
         * @return
         */
        public void setDonor(String name, String cnp, DateTime birtdhDate, Location address, Location residence, Blood blood, DateTime donationDate, String email) {
            // TODO implement here
            return;
        }

        /**
         * Sends donor info to server
         * @return
         */
        public void makeDonationDonationRequest() {
            // TODO implement here
            return;
        }

        /**
         * @return
         */
        public Location getBloodLocation() {
            // TODO implement here
            return null;
        }

    }
}