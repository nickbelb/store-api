using Entities.Context;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductByCategory(int categoryId);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly IFakeStoreApiContext _fakeStoreApiContext;

        public ProductRepository(IFakeStoreApiContext fakeStoreApiContext)
        {
            _fakeStoreApiContext = fakeStoreApiContext;
        }

        public async Task<List<Product>> GetProductByCategory(int categoryId)
        {
            var products = await _fakeStoreApiContext.Product
                .Where(prod => prod.CategoryId == categoryId)
                .ToListAsync();
            return products;
        }
    }
}
