using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Server;
using DonationCenterAplication;
using Common.Model;

namespace Server{
    /**
     * The Server manages the information from the data base.  This class is incomplete.
     */
    public class ServerController {

        /**
         * The Server manages the information from the data base.  This class is incomplete.
         */
        public ServerController() {
        }

        /**
         * 
         */
        private Location donationCenterLocationIpMap;

        /**
         * 
         */
        private Location doctorLocationMap;

        /**
         * 
         */
      
        /**
         * 
         */
        //private Repository<DonationCenter> DonationCenterRepositorty;


        /**
         * @return
         */
        private bool validateForm() {
            // TODO implement here
            throw new NotImplementedException();
        }

        /**
         * @param donationCenterId int 
         * @return
         */
        private String getDoctorRequests(int donationCenterId) {
            // TODO implement here
            return null;
        }

        /**
         * @param donationCenterId 
         * @return
         */
      

        /**
         * @param donorId 
         * @param newVal 
         * @return
         */
        private void changeDonorStatus(int donorId, String newVal) {
            // TODO implement here
            throw new NotImplementedException();
        }

        /**
         * @param bloodId 
         * @param newVal 
         * @return
         */
        public void chamgeBloodStatus(int bloodId, String newVal) {
            // TODO implement here
            throw new NotImplementedException();
        }

    }
}