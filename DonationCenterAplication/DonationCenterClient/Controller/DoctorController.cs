
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Remoting;

namespace Controller{
    /**
     * 
     */
    
    public class DoctorController {

        /**
         * 
         */

        private ServerService service;

        public DoctorController() {
            this.service = new ServerService();
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
            DoctorRequest req = new DoctorRequest(doctor.id, donationCeter_id, priority, patientName, requestString);
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
        public Tuple<IList<Plasma>, IList<Trombocytes>, IList<RedBloodCells>> reviewBloodStocks(Location val) {
            var tuple = Tuple.Create(IList < Plasma > this.service.GetAllFromDatabase<Plasma>(),
                IList < Trombocytes > this.service.GetAllFromDatabase<Trombocytes>(),
                IList < RedBloodCells > this.service.GetAllFromDatabase<RedBloodCells>());
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