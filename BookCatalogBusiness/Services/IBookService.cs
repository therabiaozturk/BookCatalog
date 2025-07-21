using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogModel.Entities;

namespace BookCatalogBusiness.Services
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book? GetById(Guid id);
        void Create(Book book);
        void Update(Guid id, Book updatedBook);
        void Delete(Guid id);
    }
}
