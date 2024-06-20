using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    public interface IUnitOfWork<T> where T : class
    {
        Repository<T> repository { get; }
        void CreateTransaction();
        void Commit();
        void Save();
        void Rollback();
    }
    public class UnitOfWorks<T> : DbContext, IUnitOfWork<T> where T : class
    {
        private readonly FakeStoreApiContext _storeContext;
        private IDbContextTransaction _dbTransaction;
        public Repository<T> repository { get; set; }

        public UnitOfWorks()
        {
            _storeContext =new FakeStoreApiContext();
            repository = new Repository<T>(_storeContext);
        }


        public void Commit()
        {
            _dbTransaction.Commit();
        }

        public void CreateTransaction()
        {
            _dbTransaction = _storeContext.Database.BeginTransaction();
        }

        public void Rollback()
        {
           _dbTransaction.Rollback();
            _dbTransaction.Dispose();
        }

        public void Save()
        {
            _storeContext.SaveChanges();
        }
    }
}
