using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common.Model;

namespace Model
{
    [Serializable]
    public class RedBloodCell : BloodComponent
    {

        public virtual string antigen { get; set; }
        public virtual bool rh { get; set; }
       
        public RedBloodCell() { }

        public RedBloodCell(string antigen, bool rh, string donationCenter_id, string donor_cnp, float ammount, DateTime donationDate, string email) : base (donationCenter_id, donor_cnp, ammount, donationDate, email)
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

            string r;

            r = (rh) ? "positiv" : "negativ";

            return "Antigen: " + antigen + "\nRh: " + r + "\nExpires at: " + getExpirationDate().Date.ToString() + "\nQuantity: " + ammount + base.ToString();
        }
    }
}
