using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogModel.Entities;

namespace BookCatalogBusiness.Services
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author? GetById(Guid id);
        void Create(Author author);
        void Update(Guid id, Author updatedAuthor);
        void Delete(Guid id);
    }
}