using BookCatalog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Model.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category? GetById(Guid id);
        void Create(Category category);
        void Update(Guid id, Category category);
        void Delete(Guid id);
    }
}
