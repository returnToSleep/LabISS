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
        public virtual int doctor_Id { get; set; }
        public virtual int donationCenter_Id { get; set; }
        public virtual int priority { get; set; }
        public virtual String patientName { get; set; }
        public virtual String requestString { get; set; }
    }
}
