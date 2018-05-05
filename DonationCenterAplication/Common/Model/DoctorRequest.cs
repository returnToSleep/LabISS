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
        public virtual string patientCnp { get; set; }
        public virtual string requestString { get; set; }
        public virtual string doctor_name { get; set; }
        public virtual string hospital { get; set; }

        public DoctorRequest() { }
        public DoctorRequest(int? doctor_id, string donationCeter_id, int priority, string patientCnp, string requestString)
        {
            this.doctor_id = doctor_id;
            this.donationCenter_id = donationCenter_id;
            this.priority = priority;
            this.patientCnp = patientCnp;
            this.requestString = requestString;
        }


        public override string ToString()
        {
            return "\nDoctor: " + doctor_name + "\nPatient cnp: " + patientCnp + "\n" + requestString + "\n" + hospital;

        }

        public virtual int CompareTo(DoctorRequest other)
        {
            if (this.priority < other.priority) return -1;
            else if (this.priority > other.priority) return 1;
            else return 0;
        }

    }
}
