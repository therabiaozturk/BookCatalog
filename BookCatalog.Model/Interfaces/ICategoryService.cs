using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Model.Entities;

namespace BookCatalog.Model.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category? GetById(Guid id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Guid id);
    }
}
