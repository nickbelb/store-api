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
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
    }
    public  class CategoryService:ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> unitOfWork)
        {
            _repository = unitOfWork;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _repository.GetAll(); ;
        }
    }
}
