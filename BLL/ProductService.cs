using DAL;
using DAL.UOW;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);

        Task<List<Product>> GetProductByCategory(int categoryId);
    }

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IProductRepository _productRepository;

        public ProductService(IRepository<Product> repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Product>> GetProductByCategory(int categoryId)
        {
            return await _productRepository.GetProductByCategory(categoryId);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
