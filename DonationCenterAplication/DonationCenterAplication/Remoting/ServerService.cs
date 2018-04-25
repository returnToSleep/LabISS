using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationCenterAplication.Remoting
{
    [Serializable]
    class ServerService : MarshalByRefObject, IService
    {

        private RepositoryBase repo;

        public ServerService()
        {
            this.repo = new RepositoryBase();
        }

        public void addToDatabase(object obj)
        {
            
            this.repo.Save(obj);
        }

        public void deleteFromDatabase<T>(object objId)
        {
            this.repo.Delete<T>(objId);
        }

        public List<T> getAllFromDatabase<T>()
        {
            return this.repo.FindAll<T>();
        }

        public T getOneFromDatabase<T>(object objId)
        {
            return this.repo.FindOne<T>(objId);
        }
    }
}
