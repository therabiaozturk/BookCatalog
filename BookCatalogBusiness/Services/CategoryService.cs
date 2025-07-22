using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogModel.Entities;
using BookCatalogDataAccess;
using BookCatalogModel.Interfaces;

namespace BookCatalogBusiness.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            var existing = _context.Categories.Find(category.Id);
            if (existing == null) return;

            existing.Name = category.Name;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return;

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
