using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

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

        public void AddToDatabase(object obj)
        {
            this.repo.Save(obj);
        }

        public void UpdateOneFromDatabase(object obj)
        {
            this.repo.Update(obj);
        }

        public void DeleteFromDatabase(object obj)
        {
            this.repo.Delete(obj);
        }

        public IList<T> GetAllFromDatabase<T>() where T: class 
        {
            return this.repo.FindAll<T>();
        }

        public T GetOneFromDatabase<T>(object objId)
        {
            return this.repo.FindOne<T>(objId);
        }

        public void Refresh(object obj)
        {
            this.repo.Refresh(obj);
        }

    }
}
