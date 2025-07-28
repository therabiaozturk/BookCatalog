using BookCatalog.Model.Entities;
using BookCatalog.DataAccess.Repositories;
using BookCatalog.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.DataAccess.Repositories
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context) => _context = context;

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book? GetById(Guid id)
        {
            return _context.Books.Find(id);
        }
        //id döceks 
        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Guid id, Book updatedBook)
        {
            var existingBook = _context.Books.Find(id);
            if (existingBook == null) return;

            existingBook.Title = updatedBook.Title;
            existingBook.AuthorId = updatedBook.AuthorId;
            existingBook.CategoryId = updatedBook.CategoryId;
            existingBook.Publisher = updatedBook.Publisher;
            existingBook.Isbn = updatedBook.Isbn;
            existingBook.Description = updatedBook.Description;
            existingBook.CreatedAt = updatedBook.CreatedAt;

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