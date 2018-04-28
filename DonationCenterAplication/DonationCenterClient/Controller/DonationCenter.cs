
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller{
    /**
     * DonationCenter is an abstract class. It represents a physical location and keeps track of all the blood it has in storage.
     */
    public class DonationCenter {

        /**
         * DonationCenter is an abstract class. It represents a physical location and keeps track of all the blood it has in storage.
         */
        public DonationCenter() {
        }

        /**
         * The physical location in the world of the Donation Center.
         */
        private Location location;


        /**
         * Returns all the items in the bloodStorage field.
         * @return
         */
        public HashSet<Blood> getBloodStorage() {
            // TODO implement here
            return null;
        }

        /**
         * The addBlood method takes a variable of type Blood and appends it to the bloodStorage.
         * @param val 
         * @return
         */
        public void addBlood(Blood val) {
            // TODO implement here
            return null;
        }

        /**
         * After blood has been sent to the doctor it should be removed from the storage.
         * @param val 
         * @return
         */
        private void removeBloodFromStorage(String val) {
            // TODO implement here
            return null;
        }

    }
}