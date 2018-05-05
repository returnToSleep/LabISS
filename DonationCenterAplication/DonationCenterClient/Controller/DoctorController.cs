
using Common.Model;
using DonationCenterAplication.Remoting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller {
    /**
     * 
     */

    public class DoctorController
    {

        #region Fields
        public IService service;
        private Doctor doctor;
        #endregion

        #region Constructor
        public DoctorController(IService service, Doctor doctor)
        {
            this.service = service;
            this.doctor = doctor;
        }
        #endregion

        #region Blood Requesting

        public void makeRequest(Location val, int priority, string patientName, string requestString)
        {
            DoctorRequest req = new DoctorRequest(doctor.id, val.longitude.ToString() + ',' + val.latitude.ToString(), priority, patientName, requestString);
            this.service.AddToDatabase(req);
        }
        
        private void acceptBlood(DoctorRequest request)
        {
            string[] splitRequest = request.requestString.Split(',');

            BloodComponent bc = null;

            if (splitRequest[0].Equals("Plasma"))
            {
                bc = this.doctor.plasmaList
                    .First(x => x.antibody == splitRequest[1] && x.ammount == Double.Parse(splitRequest[2]));

            }

            if (splitRequest[1].Equals("Red"))
            {
                bc = this.doctor.redBloodCellList
                    .First(x => x.antigen == splitRequest[1] && x.rh == bool.Parse(splitRequest[2]) && x.ammount == Double.Parse(splitRequest[3]));

            }

            if (splitRequest[1].Equals("Tromb"))
            {
                bc = this.doctor.redBloodCellList
                    .First(x =>  x.ammount == Double.Parse(splitRequest[1]));

            }

            this.service.DeleteFromDatabase(bc);
            this.service.DeleteFromDatabase(request);

            //TODO notify donor
        }


        public void refuseBlood<T>(T bloodComponent) where T : BloodComponent
        {
            bloodComponent.doctor_id = null;
            this.service.UpdateOneFromDatabase(bloodComponent);
        }
        
        /**
         * @return
         */
        public void notifyDonor()
        {
            // TODO implement here
            return;
        }
        #endregion

        #region Stock Investing
        /**
         * Location is the location of a donation center, selected from the map
         */
        public Tuple<IList<Plasma>, IList<Trombocyte>, IList<RedBloodCell>> reviewBloodStocks(Location val)
        {
            DonationCenter dc = this.service.GetOneFromDatabase<DonationCenter>(val.longitude.ToString() + ',' + val.latitude.ToString());
            return Tuple.Create(dc.plasmaList, dc.trombocyteList, dc.redBloodCellList);
        }
        #endregion
    }

}