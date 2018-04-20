
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI{
    /**
     * A Graphical user interface that is used  by assistants to oversee the donation center.
     */
    public class DonationCenterGUI : GUI {

        /**
         * A Graphical user interface that is used  by assistants to oversee the donation center.
         */
        public DonationCenterGUI() {
        }

        /**
         * An instance of DonationCenterDoctors
         */
        private DonationCenterDoctors donationCenterDoc;

        /**
         * An instance of DonationCenterDonors
         */
        private DonationCenterDonors donationCenterDon;




        /**
         * Returns all the Blood in the storage so that the user may inspect the items.
         * @return
         */
        private HashSet<Blood> getBloodStorage() {
            // TODO implement here
            return null;
        }

        /**
         * Retrieves the list of active donors so that the user may inspect it.
         * @return
         */
        private HashSet<Donor> getDonorsList() {
            // TODO implement here
            return null;
        }

        /**
         * Retrieves all donors that are waiting to be approved.
         * @return
         */
        private HashSet<Donor> getPendingDonors() {
            // TODO implement here
            return null;
        }

        /**
         * Retrieves the list of Doctors that have filed a request for Blood.
         * @return
         */
        private HashSet<Doctor> getPendingDoctors() {
            // TODO implement here
            return null;
        }

        /**
         * Accepts or rejects donors
         * @param val 
         * @return
         */
        private void addDonorToDonorList(Donor val) {
            // TODO implement here
            return null;
        }

        /**
         * This method triggers the execution of the GUI and the start of the program.
         * @return
         */
        public void run() {
            // TODO implement here
            return null;
        }

    }
}