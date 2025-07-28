using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Model.Entities;
using BookCatalog.Model.Interfaces;
using BookCatalog.DataAccess;

namespace BookCatalog.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category? GetById(Guid id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Create(Category category)
        {
            _categoryRepository.Create(category);
        }

        public void Update(Guid id, Category category)
        {
            _categoryRepository.Update(id, category);
        }

        public void Delete(Guid id)
        {
            _categoryRepository.Delete(id);
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}