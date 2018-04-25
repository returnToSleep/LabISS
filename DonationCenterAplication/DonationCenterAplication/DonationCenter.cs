using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DonationCenterAplication
{
    public class MyService : MarshalByRefObject
    {

        public RepositoryBase repo;

        public MyService()
        {
            this.repo = new RepositoryBase();
        }

        public T GetFromDatabase<T>(object objId)
        {
            return this.repo.FindOne<T>(objId);
        }

        public List<T> GetAllFromDatabase<T>()
        {
            return this.repo.FindAll<T>();
        }

        public void RemoveFromDatabase<T>(object objId)
        {
            this.repo.Delete<T>(objId);
        }

        public void AddToDatabase(object obj)
        {
            this.repo.Save(obj);
        }

    }
}
