using BookCatalog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Model.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? GetById(Guid id);
        void Create(Book book);
    }
}
