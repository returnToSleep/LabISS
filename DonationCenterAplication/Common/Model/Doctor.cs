
using Common.Model;
using Model;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * The Doctor class holds the name, speciality, hospital, request list of a doctor.
     */
    [Serializable]
    public class Doctor {

        /**
         * The Doctor class holds the name, speciality, hospital, request list of a doctor.
         */

        //The id is in format latitude,logitude 
        public virtual string id { get; set; }
        public virtual string name { get; set; }
        public virtual string speciality { get; set; } 
        public virtual string hospital { get; set; }
        public virtual IList<DoctorRequest> requests { get; set; }


        public Doctor() { }

        public Doctor(string id, string name, string speciality, string hospital) {
            this.id = id;
            this.name = name;
            this.speciality = speciality;
            this.hospital = hospital;
        }


        public override string ToString()
        {
            return "Doctor: " + name + "\nSpeciality: " + speciality + "\nWorking at: " + hospital;
        }
    }
}


