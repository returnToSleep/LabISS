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


        public float getTrombQuantity()
        {
            return this.trombocyteList
                .Select(x => x.ammount)
                .Sum();
        }

        public float getPlasmaQuantity(string type)
        {
            return this.plasmaList
                .Where(x => x.antibody == type)
                .Select(x => x.ammount)
                .Sum();
        }

        public float getRedQuantity(string type, bool rh)
        {
            return this.redBloodCellList
                .Where(x => x.antigen == type && x.rh == rh)
                .Select(x => x.ammount)
                .Sum();
        }


    }
}
