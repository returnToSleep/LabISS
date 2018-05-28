
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Common.Model;
using DonationCenterAplication.Remoting;
using Common.Exceptions;

namespace Controller{
    /**
     * 
     */
    public class DonorController {


        public Donor donor { get; set; }
        public IService service { get; set; }

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
        *       returns a string used in the GUI that informes the donor if or when they can donate again
        * 
        */
        public string isDonorFit()
        {

           

            if (donor.isPending == true)
            {
                return "Momentan nu avem rezultatele analizelor";
            }

            DateTime lastDonationDate;

            try
            {
                lastDonationDate = donor.getLastDonation();
            }
            catch
            {
                lastDonationDate = new DateTime(1, 1, 1); 
            }

            if (lastDonationDate.AddMonths(2).CompareTo(DateTime.Today) > 0)
            {
                return "Puteti dona din nou incepand din " + lastDonationDate.AddMonths(2).Date.ToString();
            }
            

            return "Puteti dona!";

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
            donor.donationCenter_id = donationCenter_id;

            try
            {
                service.UpdateOneFromDatabase(donor);
            }catch (RemotingException rmE)
            {
                throw new ControllerException("A aparut o problema!", rmE);
            }
        }
        #endregion


   
        //Region for the donation history
        #region Donation History
        public IList<Donation> getDonationHistory()
        {
            return this.donor.donationHistory;
        }
        #endregion


        #region Utils

        public void refresh()
        {
            try
            {
                donor = service.GetOneFromDatabase<Donor>(donor.cnp);
            }catch (RemotingException rmE){
                throw new ControllerException("A aparut o problema!", rmE);
            }
        }


        #endregion
    }
}