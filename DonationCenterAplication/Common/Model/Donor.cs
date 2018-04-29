
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /**
     * The Donor class has all the information needet related to a donor such as: Name, CNP, birthday, address, residence, blood, donationDate, email.
     */
    public class Donor {
        
        public virtual string name { get; set; }
        public virtual string cnp { get; set; }
        public virtual DateTime birthdate { get; set; }
        public virtual string address{ get; set; }
        public virtual Location location{ get; set; }
        public virtual DateTime donationDate{ get; set; }
        public virtual string email { get; set; }
        
        //Status of donor, either pending or donated 
        public virtual bool isPending { get; set; }
        public virtual string donationCenter_id { get; set; }

        public Donor() { }

        public Donor(string cnp, string donationCenter_id, string name,  DateTime birthdate, string address, Location location, string email) {
            this.name = name;
            this.cnp = cnp;
            this.birthdate = birthdate;
            this.address = address;
            this.location = location;
            this.email = email;
            this.isPending = true;
            this.donationCenter_id = donationCenter_id;
        }


        public override string ToString()
        {

            return "Donor:\nName: " + name + "\t--\tCNP: " + cnp + "\nAge: " + DateTime.Now.Subtract(birthdate) + "\nAddress: " + address
                + "\nResidence: " + location + "\nEmail: " + email + "\n";
        }
    }
}