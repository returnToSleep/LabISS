using Model;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationCenterServer.ORM
{
    
    [Serializable]
    public class DoctorMap : ClassMapping<Doctor>
    {
        public DoctorMap()
        {
            Id(x => x.id);
            Property(x => x.name);
            Property(x => x.speciality);
            Property(x => x.hospital);
         }
    }
}
