
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


        private Donor donor { get; set; }
        private IService service { get; set; }

        //Constructors
        #region Constructors
        public DonorController() { }
        
        /*
        * Constructor for when the donor has an account
        */
        public DonorController(IService service, Donor donor)
        {
            this.service = service;
            this.donor = donor;
        }

        /*
         * Constructor for new donors
         */

        public DonorController(IService service)
        {
            this.service = service;
        }
        #endregion

        //Region for the donation functionality
        #region Donation
        /*
        *
        * Donor GUI will have a list of checkboxes (ex "Ati suferit de: ... ") 
        * isFit will determine based on the checkboxes if the donor is fit 
        * 
        */
        private bool isDonorFit(Donor donor, Donation donation, bool isFit)
        {
           if (! isFit)
            {
                return false;
            }

            DateTime zeroTime = new DateTime(1, 1, 1);

            TimeSpan span = DateTime.Now - donor.birthdate;
            
            int age = (zeroTime + span).Year - 1;
            
            if ( age < 18 || age > 60)
            {
                return false;
            }
            

            return true;

        }
        
        /*
        * The donor chooses the donation center to which he/she wants to donate
        * A donor object is added to the database with the id of the selected donation center
        * The donor object field "isPending" is defaulted to 'true'
        * Once the donor is deemed fit to donate by a doctor, isPending is changed to 'false' 
        */
        public void selectDonationCenter(Location l)
        {
            string donationCenter_id = l.latitude.ToString() + ',' + l.longitude.ToString();
            this.donor.donationCenter_id = donationCenter_id;
            this.service.UpdateOneFromDatabase(donor); 
        }
        #endregion
        
        //Region for the blood tracking functionality
        #region Blood Tracking
        public IList<Trombocyte> getTrombocyteList()
        {
            return this.donor.trombocyteList;
        }

        public IList<RedBloodCell> getRedBloodCell()
        {
            return this.donor.redBloodCellList;
        }

        public IList<Plasma> getPlasmaList()
        {
            return this.donor.plasmaList;
        }
        #endregion

        //Region for the donation history
        #region Donation History
        public IList<Donation> getDonationHistory()
        {
            return this.donor.donationHistory;
        }
        #endregion

    }
}