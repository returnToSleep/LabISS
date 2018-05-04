
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller{
    /**
     * The DonationCenterDonors class extends DonationCenter.
     * 
     * It keeps track of all approved donors in the donorList.
     * It also stores would-be-donors in the donorBuffer along with their request sheets.
     */
    public class DonationCenterDonors : DonationCenter {

        /**
         * The DonationCenterDonors class extends DonationCenter.
         * 
         * It keeps track of all approved donors in the donorList.
         * It also stores would-be-donors in the donorBuffer along with their request sheets.
         */
        public DonationCenterDonors() {
        }

        /**
         * The request forms of the pending donors.
         */
        private HashSet<String> pendingDonorRequests;



        /**
         * Retrieves the list of all approved donors.
         * @return
         */
        public HashSet<Donor> getDonorsList() {
            // TODO implement here
            return null;
        }

        /**
         * Private method.
         * Checks whether the form was filled correctly.
         * @param val 
         * @return
         */
        private Boolean validateForm(Donor val) {
            // TODO implement here
            return null;
        }

        /**
         * After a donor has been manually approved by an assistant, he/she should be added to the donorList.
         * @param val 
         * @return
         */
        public void addDonorToDonorList(Donor val) {
            // TODO implement here
            return null;
        }

        /**
         * Private method.
         * Donors that have not been active (have not donated) within the last X months should be classified as Idle and should be deleted from the donorList.
         * @return
         */
        private void deleteIdleDonors() {
            // TODO implement here
            return null;
        }

        /**
         * Private method.
         * Whenever a donor's blood is used he/she should be notified.
         * @param val 
         * @return
         */
        private void notifyDonor(Donor val) {
            // TODO implement here
            return null;
        }

        /**
         * Retrieves a list of donors sorted by how close they are to the donation center.
         * @return
         */
        public HashSet<Donor> searchNearestDonors() {
            // TODO implement here
            return null;
        }

        /**
         * Retrieves a list of all Donors that have applied and have not yet been processed.
         * @return
         */
        public HashSet<Donor> getPendingDonors() {
            // TODO implement here
            return null;
        }

        /**
         * Assigns a Blood type item to a certain donor specified by his CNP.
         * @param cnp 
         * @param blood
         */
        public void setDonorBlood(String cnp, Blood blood) {
            // TODO implement here
        }

    }
}