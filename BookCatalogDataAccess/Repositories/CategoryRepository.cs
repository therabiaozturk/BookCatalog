using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Model.Entities;
using BookCatalog.Model.Interfaces;

namespace BookCatalog.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return [.. _context.Categories];
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

        public void Update(Guid id, Category category)
        {
            var existing = _context.Categories.Find(id);
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
