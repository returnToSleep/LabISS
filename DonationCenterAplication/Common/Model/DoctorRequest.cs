using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
   
    [Serializable]
    public class DoctorRequest : IComparable<DoctorRequest>
    {
        public virtual int id { get; set; }
        public virtual int? doctor_id { get; set; }
        public virtual string donationCenter_id { get; set; }
        public virtual int priority { get; set; }
        public virtual string pacientName { get; set; }
        public virtual string requestString { get; set; }
        public virtual string doctor_name { get; set; }
        public virtual string hospital { get; set; }
        public virtual string donationCenterName { get; set; }
        //Is it beeing delivered?
        public virtual bool isBeeingDelivered { get; set; }

        public DoctorRequest() { }
        public DoctorRequest(int? doctor_id, string donationCeter_id, int priority, string pacientName, string requestString, string donationCenterName)
        {
            this.doctor_id = doctor_id;
            this.donationCenter_id = donationCeter_id;
            this.priority = priority;
            this.pacientName = pacientName;
            this.requestString = requestString;
            this.isBeeingDelivered = false;
            this.donationCenterName = donationCenterName;
        }


        public override string ToString()
        {

            string status = isBeeingDelivered ? "Is beeing delivered" : "Pending";

            return "Status: " + status +"\nPriority: " + priority + "\nDoctor: " + doctor_name + "\nPatient name: " + pacientName + "\n" + requestString + "\nHospital: " + hospital + "\nDonation Center: " + donationCenterName + "\nPacient: " + pacientName;

        }

        public virtual int CompareTo(DoctorRequest other)
        {
            if (this.priority < other.priority) return -1;
            else if (this.priority > other.priority) return 1;
            else return 0;
        }

    }
}
