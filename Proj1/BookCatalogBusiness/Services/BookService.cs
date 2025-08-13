using BookCatalog.Model.Entities;
using BookCatalog.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Business.Services
{
    public class BookService : IBookService
    {    //vs önerdi implement ettirdi
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) => _bookRepository = bookRepository;

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book? GetById(Guid id)
        {
            return _bookRepository.GetById(id);
        }

        public void Create(Book book)
        {
            _bookRepository.Create(book);
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book.Id, book);
        }

        public void Delete(Guid id)
        {
            _bookRepository.Delete(id);
        }

        public void Update(Guid id, Book updatedBook)
        {
            throw new NotImplementedException();
        }
    }
}
