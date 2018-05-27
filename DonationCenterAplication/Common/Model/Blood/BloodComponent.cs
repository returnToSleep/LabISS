﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class BloodComponent
    {
        public virtual string donationCenter_id { get; set; }
        public virtual string donor_cnp { get; set; }
        public virtual double ammount { get; set; }
        public virtual int id { get; set; }
        public virtual DateTime donationDate { get; set; }
        public virtual string email { get; set; }
        public virtual bool isBeeingDelivered { get; set; }
        public virtual string donatedFor { get; set; }
        
        //int? - nullable int
        public virtual int? doctor_id { get; set; }

        protected BloodComponent() { }

        public BloodComponent(string donationCenter_id, string donor_cnp, float ammount, DateTime donationDate, string email)
        {
            this.donationCenter_id = donationCenter_id;
            this.donor_cnp = donor_cnp;
            this.ammount = ammount;
            this.donationDate = donationDate;
            this.doctor_id = null;
            this.email = email;
            isBeeingDelivered = false;
        }

        public virtual DateTime getExpirationDate()
        {
            return this.donationDate;
        }

        public override string ToString()
        {
            return donatedFor == null ? "" : "\nDonat pentru: " + donatedFor;
        }

    }
}
