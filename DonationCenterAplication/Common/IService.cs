using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationCenterAplication.Remoting
{
    interface IService
    {
        void addToDatabase(object obj);

        void deleteFromDatabase<T>(object objId);

        List<T> getAllFromDatabase<T>();

        T getOneFromDatabase<T>(object objId);

    }
}
