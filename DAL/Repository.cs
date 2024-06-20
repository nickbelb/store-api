using Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
    public  class Repository<T> : IRepository<T> where T : class
    {
        private FakeStoreApiContext _storeContext;
        private DbSet<T> entity;


        public Repository()
        {
            _storeContext = new FakeStoreApiContext();
            entity = _storeContext.Set<T>();
        }
        public Repository(FakeStoreApiContext fakeStoreApiContext)
        {
            _storeContext = fakeStoreApiContext;
            entity = _storeContext.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return entity.ToList().Count > 0 ? await entity.ToListAsync() : null;
        }

        public async Task<T> GetById(int id)
        {
            T item = null;
            if (id != 0)
            {
                item = await entity.FindAsync(id);
            }
            return item;
        }
    }
}
