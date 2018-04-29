using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
   
    [Serializable]
    public class DoctorRequest
    {
        public virtual int id { get; set; }
        public virtual string doctor_id { get; set; }
        public virtual string donationCenter_id { get; set; }
        public virtual int priority { get; set; }
        public virtual string patientName { get; set; }
        public virtual string requestString { get; set; }

        public DoctorRequest() { }
        public DoctorRequest(string doctor_id, string donationCeter_id, int priority, string patientName, string requestString)
        {
            this.doctor_id = doctor_id;
            this.donationCenter_id = donationCenter_id;
            this.priority = priority;
            this.patientName = patientName;
            this.requestString = requestString;
        }


        public override string ToString()
        {
            return "\nDoctor id: " + doctor_id + "\nDonation center id: " + donationCenter_id + "\nPriority: " + priority + "\nPatient: " + patientName + "\n" + requestString;
        }

    }
}
