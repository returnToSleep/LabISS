
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using Model;

namespace Controller{
    /**
     * The DonationCenterDoctors class extends DonationCenter.
     * 
     * It keeps track of all authorised doctors and all requests submitted by them that have not yet been fulfilled.
     */
    public class DonationCenterDoctors : DonationCenter{

        /**
         * The DonationCenterDoctors class extends DonationCenter.
         * 
         * It keeps track of all authorised doctors and all requests submitted by them that have not yet been fulfilled.
         */
        public DonationCenterDoctors() {
        }




        /**
         * This method is called when an assistant fulfills a request. The BloodComponent is sent to the doctor along with a message(?)
         * @param Doctor 
         * @param String 
         * @param BloodComponent 
         * @return
         */
        public void sendBloodToDoctor(Doctor d, String request, BloodComponent b) {
            // TODO implement here
        }

        /**
         * After a manual review of the request by an assistant, that assistant should process it (i.e. send blood to the doctor)
         * @return
         */
        public void processDoctorsRequest() {
            // TODO implement here
        }

        /**
         * Retrieves the list of doctors that have submitted a request and have not yet been approved.
         * @return
         */
        public HashSet<Doctor> getPendingDoctorRequests() {
            // TODO implement here
            return null;
        }

        private PriorityQueue<DoctorRequest> sortRequests()
        {
            PriorityQueue<DoctorRequest> priorityQueueRequests = new PriorityQueue<DoctorRequest>();
            IList<DoctorRequest> doctorRequest = this.service.GetAllFromDatabase<DoctorRequest>();
            doctorRequest.ToList().ForEach(request => priorityQueueRequests.Enqueue(request));
            return priorityQueueRequests;
        }
        

    }
}