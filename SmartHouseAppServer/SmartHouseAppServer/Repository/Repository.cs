using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using System.Linq.Expressions;

namespace SmartHouseAppServer.Repository
{
    public class Repository<T> : IDisposable where T : class
    {
        private static ISessionFactory _sessionFactory;
        protected ISession _session = null;
        protected ITransaction _transaction = null;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly("SmartHouseAppServer");
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        private void OpenSession()
        {
            _session = SessionFactory.OpenSession();
        }

        public Repository()
        {
            OpenSession();
        }
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
        
        public virtual void Save(T obj)
        {
            _session.SaveOrUpdate(obj);
        }

        public virtual void Delete(T obj)
        {
            _session.Delete(obj);
        }

        public virtual object GetById(int objId)
        {
            return _session.Load<T>(objId);
        }

        public virtual IList<T> Where(Expression<Func<T, bool>> exp)
        {
            return _session.QueryOver<T>().Where(exp).List();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                // Commit transaction by default, unless user explicitly rolls it back.
                // To rollback transaction by default, unless user explicitly commits,                // comment out the line below.
                RollbackTransaction();
            }
            if (_session != null)
            {
                _session.Flush(); // commit session transactions
                CloseSession();
            }
        }
    }
}