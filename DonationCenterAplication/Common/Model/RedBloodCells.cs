using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class RedBloodCells : BloodComponent
    {
        public RedBloodCells(DateTime donationDate, float amount, string donorEmail, string status, string type, bool rH) : base(donationDate, amount, donorEmail, status)
        {
            this.type = type;
            this.rH = rH;
        }

        protected string type;
        protected bool rH;

        public string getType() { return this.type; }
        public bool getRH() { return this.rH; }
        public void setType(string type) { this.type = type; }
        public void setRH(bool rH) { this.rH = rH; }

        public override DateTime getExpirationDate()
        {
            return donationDate.AddDays(42);
        }

        public override string ToString()
        {
            return "Red Blood Cells:\nType: " + type + "\nrH: " + rH + "\n" + base.ToString();
        }
    }
}
