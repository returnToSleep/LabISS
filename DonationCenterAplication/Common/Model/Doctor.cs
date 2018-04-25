
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
        
        public Doctor() { }

        public Doctor(string name, string speciality, string hospital, Location location) {
            this.name = name;
            this.speciality = speciality;
            this.hospital = hospital;
            this.location = location;
        }

        public virtual int id { get; set; }

        /**
         * The name of the doctor.
         */
        public virtual string name { get; set; }

        /**
         * The speciality of a doctor.
         */
        public virtual string speciality { get; set; }

        /**
         * The hospital at which the doctor works at.
         */
        public virtual string hospital { get; set; }

        /**
         * The location of a doctor.
         */
        public virtual Location location { get; set; }

        

        public override string ToString()
        {
            return "Doctor: " + name + "\nSpeciality: " + speciality + "\nWorking at: " + hospital + "\nLocation: " + location;
        }
    }
}


