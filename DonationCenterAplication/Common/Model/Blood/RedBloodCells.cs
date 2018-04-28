using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common.Model;

namespace Model
{
    public class RedBloodCell : BloodComponent
    {

        public virtual string antigen { get; set; }
        public virtual bool rh { get; set; }
       
        public RedBloodCell() { }

        public RedBloodCell(int id, string antiget, bool rh, int donationCenter_id, string donor_cnp, float ammount, DateTime donationDate) : base (id ,donationCenter_id, donor_cnp, ammount, donationDate)
        {
            this.antigen = antigen;
            this.rh = rh;

        }


        public override DateTime getExpirationDate()
        {
            return donationDate.AddDays(42);
        }

        public override string ToString()
        {
            return "Red Blood Cells:\nAntigen: " + antigen + "\nrH: " + rh + "\nExpirationDate: " + this.getExpirationDate().ToString() + base.ToString();
        }
    }
}
