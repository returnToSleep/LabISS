
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

namespace Controller{
    /**
     * 
     */
    
    public class DoctorController {

        /**
         * 
         */
        public IService service;
        

        public DoctorController() {
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            service = (IService)(Activator.GetObject(typeof(IService),
                "tcp://localhost:9999/IService"
                ));
        }

        /**
         * 
         */
        private Doctor doctor;


        /**
         * @param val 
         * @return
         */
        public void makeRequest(Location val, int priority, string patientName, string requestString) {
            //get donation center id from location TODO
            DoctorRequest req = new DoctorRequest(doctor.id, val.longitude.ToString() + ',' + val.latitude.ToString(), priority, patientName, requestString);
            this.service.AddToDatabase(req);
        }

        /**
         * @return
         */
        public void notifyDonors() {
            // TODO implement here
            return;
        }

        /**
         * @param val 
         * @return
         */
        public Tuple<IList<Plasma>, IList<Trombocyte>, IList<RedBloodCell>> reviewBloodStocks(Location val) {
            DonationCenter dc = this.service.GetOneFromDatabase<DonationCenter>(val.longitude.ToString() + ',' + val.latitude.ToString());
            var tuple = Tuple.Create(dc.plasmalist),
                this.service.GetOneFromDatabase<Trombocyte>(val.longitude.ToString() + ',' + val.latitude.ToString()),
                this.service.GetOneFromDatabase<RedBloodCell>(val.longitude.ToString() + ',' + val.latitude.ToString()));
            return tuple;
        }

        /**
         * @param name
         */
        public void setDoctorName(String name) {
            doctor.name = name;
        }

        /**
         * @param newVal
         */
        public void setDoctorSpeciality(String newVal) {
            doctor.speciality = newVal;
        }

        /**
         * @param newVal
         */
        public void setHospita(String newVal) {
            doctor.hospital = newVal;
        }

    }
}