using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Model.Entities;

namespace BookCatalog.Model.Interfaces
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author? GetById(Guid id);
        void Create(Author author);
        void Update(Author author);
        void Delete(Guid id);
    }
}
