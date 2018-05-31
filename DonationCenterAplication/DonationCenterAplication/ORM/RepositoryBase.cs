using Common.Exceptions;
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
                    try
                    {
                        session.Save(obj);
                        session.Flush();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw new DataBaseException("The repository caught an exception", e);
                    }
                 }
            }

        }

        public virtual void Update(object obj)
        {
            using (ISession session = DataBaseHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(obj);
                        session.Flush();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw new DataBaseException("The repository caught an exception", e);
                    }
                }
            }

        }

        public virtual void Delete(object obj)
        {
            
            
            using (ISession session = DataBaseHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(obj);
                        session.Flush();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        throw new DataBaseException("The repository caught an exception", e);
                    }
                }
            }


        }

        public virtual T FindOne<T>(object objId)
        {
            using (ISession session = DataBaseHelper.OpenSession())
            {
                try
                {
                    return (T)session.Load(typeof(T), objId);
                }
                catch (Exception e)
                {
                    throw new DataBaseException("The repository caught an exception", e);
                }
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
                try
                {
                    return session.QueryOver<T>().List();
                }
                catch (Exception e)
                {
                    throw new DataBaseException("The repository caught an exception", e);
                }
            }
        }

        #endregion


    }
}

