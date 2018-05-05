using DonationCenterAplication.ORM;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    [Serializable]
    public class RepositoryBase : IRepository
    {
        public RepositoryBase() { }
   
        #region IRepository Members

        public virtual void Save(object obj)
        {

            using (ISession session = DataBaseHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(obj);
                    session.Flush();
                    transaction.Commit();
                }
            }

        }

        public virtual void Update(object obj)
        {
            using (ISession session = DataBaseHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(obj);
                    session.Flush();
                    transaction.Commit();
                }
            }

        }

        public virtual void Delete(object obj)
        {
            
            
            using (ISession session = DataBaseHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(obj);
                    session.Flush();
                    transaction.Commit();
                }
            }


        }

        public virtual T FindOne<T>(object objId)
        {
            using (ISession session = DataBaseHelper.OpenSession())
            {
                 return (T)session.Load(typeof(T), objId);
            }
         
        }

        public virtual void Refresh(object obj)
        {
            using (ISession session = DataBaseHelper.OpenSession())
            {
                session.Refresh(obj);
            }
        }


        public virtual IList<T> FindAll<T>() where T : class
        {
            using (ISession session = DataBaseHelper.OpenSession())
            {
                return session.QueryOver<T>().List();
            }
        }

        #endregion


    }
}

