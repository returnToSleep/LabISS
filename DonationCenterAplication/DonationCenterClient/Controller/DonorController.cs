
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common.Model;
using DonationCenterAplication.Remoting;

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
        private Donor donor { get; set; }
        private IService service { get; set; }

        public DonorController(IService service, Donor donor)
        {
            this.service = service;
            this.donor = donor;
        }

        public DonorController(IService service)
        {
            this.service = service;
        }

        
        private bool ValidateDonor()
        {
            return false;
        }  

            


    }
}