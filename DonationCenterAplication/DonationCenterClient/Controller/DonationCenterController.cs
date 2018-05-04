using Common.Model;
using DonationCenterAplication.Remoting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Client.Controller
{

    public class DonationCenterController
    {


        IService service;
        private DonationCenter dc;
        /**
         * Donation center constructor with args
         */
        public DonationCenterController(IService serv, DonationCenter dc)
        {
            this.service = serv;
            this.dc = dc;
        }

        /**
   * Eliminates from the bloodcomponent lists the components that have expired. ( ExpirationDate > DateTime.Now )   
   * 
   */
        public void refreshBloodStock()
        {
            dc.redBloodCellList.RemoveAll(item => item.getExpirationDate() > DateTime.Now);
            dc.trombocyteList.RemoveAll(item => item.getExpirationDate() > DateTime.Now);
            dc.plasmaList.RemoveAll(item => item.getExpirationDate() > DateTime.Now);
            this.service.UpdateOneFromDatabase(dc);
            this.service.Refresh(dc);
        }

        /**
         * Adds a certain blood component to the stock, the donation center id of the component is set to this center's id
         * bc is the blood component ( plasma/ red cells / trobocytes) 
         */
        public void addBloodToStock<T>(T bc) where T : BloodComponent
        {
            bc.donationCenter_id = dc.id;
            this.service.AddToDatabase(bc);
            this.service.Refresh(bc);
        }

        public void evaluateDonor(bool b, Donor d)
        {
            if (b)
            {
                d.isPending = false;
                this.service.UpdateOneFromDatabase(dc);
                this.service.Refresh(dc);
                //TO DO : send mail
            }
            else
            {
                dc.donors.Remove(d);
                this.service.UpdateOneFromDatabase(dc);
                this.service.Refresh(dc);
                //TO DO : send mail
            }

        }


    }
}
