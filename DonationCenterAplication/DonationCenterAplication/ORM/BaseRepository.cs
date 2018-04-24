using DonationCenterAplication.ORM;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

public class RepositoryBase : IRepository, IDisposable
{
    protected ISession _session = null;
    protected ITransaction _transaction = null;
    public RepositoryBase()
    {
        _session = DataBaseHelper.OpenSession();
    }
    public RepositoryBase(ISession session)
    {
        _session = session;
    }



    #region Transaction and Session Management Methods


    public void BeginTransaction()
    {
        _transaction = _session.BeginTransaction();
    }
    public void CommitTransaction()
    {
        // _transaction will be replaced with a new transaction            // by NHibernate, but we will close to keep a consistent state.
        _transaction.Commit();
        CloseTransaction();
    }
    public void RollbackTransaction()
    {
        // _session must be closed and disposed after a transaction            // rollback to keep a consistent state.
        _transaction.Rollback();
        CloseTransaction();
        CloseSession();
    }
    private void CloseTransaction()
    {
        _transaction.Dispose();
        _transaction = null;
    }
    private void CloseSession()
    {
        _session.Close();
        _session.Dispose();
        _session = null;
    }
    #endregion


    #region IRepository Members

    public virtual void Save(object obj)
    {
        _session.SaveOrUpdate(obj);
      
    }

    public virtual void Delete<T>(object objId)
    {
        var queryString = string.Format("delete {0} where id = :id",
                                        typeof(T));
        _session.CreateQuery(queryString)
               .SetParameter("id", objId)
               .ExecuteUpdate();

    }

    public virtual T FindOne<T>(object objId)
    {
        return (T)_session.Load(typeof(T), objId);
    }
    

    public List<object> getAll(Type objType)
    {
        string nameRaw = objType.ToString();
        string name = nameRaw.Split('.')[nameRaw.Split(' ').Length];

        return (List<object>)_session.CreateSQLQuery("select * from " + name)
            .AddEntity(objType)
            .List<object>();
    }


    public virtual List<T> FindAll<T>()
    {
        return this.getAll(typeof(T))
                .Select(i => (T)i)
                .ToList<T>();
        
    }

    #endregion


    #region IDisposable Members
    public void Dispose()
    {
        if (_transaction != null)
        {
            // Commit transaction by default, unless user explicitly rolls it back.
            // To rollback transaction by default, unless user explicitly commits,                // comment out the line below.
            CommitTransaction();
        }
        if (_session != null)
        {
            _session.Flush(); // commit session transactions
            CloseSession();
        }
    }
    #endregion
}
