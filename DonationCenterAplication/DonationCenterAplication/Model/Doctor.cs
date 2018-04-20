
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * The Doctor class holds the name, speciality, hospital, request list of a doctor.
     */
    public class Doctor {

        /**
         * The Doctor class holds the name, speciality, hospital, request list of a doctor.
         */
        public Doctor(string name, string speciality, string hospital, Location location) {
            this.name = name;
            this.speciality = speciality;
            this.hospital = hospital;
            this.location = location;
        }

        /**
         * The name of the doctor.
         */
        private string name;

        /**
         * The speciality of a doctor.
         */
        private string speciality;

        /**
         * The hospital at which the doctor works at.
         */
        private string hospital;

        /**
         * The location of a doctor.
         */
        private Location location;


        /**
         * Returns the name of a doctor.
         * @return
         */
        public string getName() {
            return this.name;
        }

        /**
         * Sets a new name to a doctor.
         * @param val 
         * @return
         */
        public void setName(string val) {
            this.name = val;
        }

        /**
         * Returns the specialty of a doctor.
         * @return
         */
        public string getSpeciality() {
            return this.speciality;
        }

        /**
         * Sets a new specialty to a doctor.
         * @param val
         */
        public void setSpeciality(string val) {
            this.speciality = val;
        }

        /**
         * Returns the hospital at which the doctor works at.
         * @return
         */
        public string getHospital() {
            return this.hospital;
        }

        /**
         * Sets a new hospital to a doctor.
         * @param val
         */
        public void setHospital(string val) {
            this.hospital = val;
        }

        public override string ToString()
        {
            return "Doctor: " + name + "\nSpeciality: " + speciality + "\nWorking at: " + hospital + "\nLocation: " + location;
        }
    }
}