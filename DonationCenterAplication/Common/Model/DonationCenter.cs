using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class DonationCenter
    {
        //the id is in latitude,logitude format
        public virtual string id { get; set; }
        public virtual string name { get; set; }

        public double lat { get; set; }
        public double lon { get; set; }

        public virtual IList<DoctorRequest> requests { get; set; }
        public virtual IList<Donor> donors { get; set; }
        public virtual IList<RedBloodCell> redBloodCellList { get; set; }
        public virtual IList<Trombocyte> trombocyteList { get; set; }
        public virtual IList<Plasma> plasmaList { get; set; }

        public DonationCenter() {}
        public DonationCenter(string id, string name)
        {
            this.id = id;
            this.name = name;

        }

        public void setLatLon()
        { 
            lat = double.Parse(id.Split(',')[0]);
            lon = double.Parse(id.Split(',')[1]);
        }


        public double getTrombQuantity()
        {
            return trombocyteList
                .Select(x => x.ammount)
                .Sum();
        }

        public double getPlasmaQuantity(string type)
        {
            return plasmaList
                .Where(x => x.antibody == type)
                .Select(x => x.ammount)
                .Sum();
        }

        public double getRedQuantity(string type, bool rh)
        {
            return redBloodCellList
                .Where(x => x.antigen == type && x.rh == rh)
                .Select(x => x.ammount)
                .Sum();
        }

        public override string ToString()
        {
            return name;
        }
        
    }
}
