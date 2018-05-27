using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Common.Exceptions;

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
            try
            {
                this.repo.Save(obj);
            }catch (DataBaseException dbE)
            {
                throw new RemotingException("Serverul a intampinat o eroare", dbE);
            }
        }

        public void UpdateOneFromDatabase(object obj)
        {
            try
            {
                this.repo.Update(obj);
            }
            catch (DataBaseException dbE)
            {
                throw new RemotingException("Serverul a intampinat o eroare", dbE);
            }

        }

        public void DeleteFromDatabase(object obj)
        {
            try
            {
                this.repo.Delete(obj);
            }
            catch (DataBaseException dbE)
            {
                throw new RemotingException("Serverul a intampinat o eroare", dbE);
            }
        }

        public IList<T> GetAllFromDatabase<T>() where T: class 
        {
            try
            {
                return this.repo.FindAll<T>();
            }
            catch (DataBaseException dbE)
            {
                throw new RemotingException("Serverul a intampinat o eroare", dbE);
            }
        }

        public T GetOneFromDatabase<T>(object objId)
        {
            try
            {
                return this.repo.FindOne<T>(objId);
            }
            catch (DataBaseException dbE)
            {
                throw new RemotingException("Serverul a intampinat o eroare", dbE);
            }
        }

        public void Refresh(object obj)
        {
            try
            {
                this.repo.Refresh(obj);
            }
            catch (DataBaseException dbE)
            {
                throw new RemotingException("Serverul a intampinat o eroare", dbE);
            }
        }

    }
}
