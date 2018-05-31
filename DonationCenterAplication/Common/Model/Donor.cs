
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model{
    /**
     * The Donor class has all the information needet related to a donor such as: Name, CNP, birthday, address, residence, blood, donationDate, email.
     */
     [Serializable]
    public class Donor {
        
        public virtual string name { get; set; }
        public virtual string cnp { get; set; }
        public virtual DateTime birthdate { get; set; }
        public virtual Location location{ get; set; }
        public virtual IList<Donation> donationHistory { get; set; }
        public virtual string email { get; set; }
        public virtual string address { get; set; }

        //Status of donor, either pending or donated 
        public virtual bool isPending { get; set; }
        public virtual string donationCenter_id { get; set; }
        public virtual string bloodType { get; set; }
        public virtual bool rh { get; set; }
        public virtual string donatedFor { get; set; }

        public Donor() { }

        public Donor(string cnp, string donationCenter_id, string name,  DateTime birthdate, string address, Location location, string email) {
            this.name = name;
            this.cnp = cnp;
            this.birthdate = birthdate;
            this.location = location;
            this.email = email;
            this.isPending = true;
            this.donationCenter_id = donationCenter_id;
            
        }


        //Constructor for creataing a donor accout 
        public Donor(string cnp, string name, DateTime birthdate, string address, Location location, string email)
        {
            this.name = name;
            this.cnp = cnp;
            this.birthdate = birthdate;
            this.address = address;
            this.location = location;
            this.email = email;
            this.isPending = true;
        }

        public virtual DateTime getLastDonation()
        {
            try
            {
                return donationHistory
                    .Select(x => x.donationDate)
                    .Max();
            }
            catch
            {
                return new DateTime(1, 1, 1);
            }
        }

        public override string ToString()
        {
            string bt = (bloodType == null) ? "?" : bloodType;
            string rhStr = (rh) ? " pozitiv" : " negativ";
            string donatesFor = donatedFor == null && ! isPending ? "" : "Doneaza pentru: " + donatedFor;

            return "Name: " + name + "\nCNP: " + cnp + "\nBlood type: " + bt + rhStr + "\nBirthdate: " + birthdate.Date.ToString()
                + "\nE-mail: " + email + "\n";
        }
    }
}