using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationCenterAplication.Remoting
{
    public interface IService
    {
        void AddToDatabase(object obj);

        void UpdateOneFromDatabase(object obj);

        void DeleteFromDatabase(object obj);

        IList<T> GetAllFromDatabase<T>() where T: class;

        T GetOneFromDatabase<T>(object objId);

        void Refresh(object obj);
    }
}
