using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogModel.Interfaces;
using BookCatalogModel.Entities;

namespace BookCatalogModel.Interfaces
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