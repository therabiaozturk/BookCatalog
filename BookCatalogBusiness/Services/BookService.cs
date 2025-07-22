using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogModel.Entities;
using BookCatalogDataAccess;
using BookCatalogModel.Entities;
using BookCatalogModel.Interfaces;

namespace BookCatalogModel.Interfaces
{
    public class BookService : IBookService    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book? GetById(Guid id)
        {
            return _context.Books.Find(id);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            var existingBook = _context.Books.Find(book.Id);
            if (existingBook == null) return;

            existingBook.Title = book.Title;
            existingBook.AuthorId = book.AuthorId;
            existingBook.CategoryId = book.CategoryId;
            existingBook.Publisher = book.Publisher;
            existingBook.ISBN = book.ISBN;
            existingBook.Description = book.Description;
            existingBook.CreatedAt = book.CreatedAt;

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return;

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
