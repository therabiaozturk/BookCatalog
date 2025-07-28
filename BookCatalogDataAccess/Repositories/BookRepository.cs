using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Model.Entities;
using BookCatalog.Model.Interfaces;

namespace BookCatalog.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) => _context = context;

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book? GetById(Guid id)
        {
            return _context.Books.Find(id);
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Guid id, Book updatedBook)
        {
            var existing = _context.Books.Find(id);
            if (existing == null) return;

            existing.Title = updatedBook.Title;
            existing.AuthorId = updatedBook.AuthorId;
            existing.CategoryId = updatedBook.CategoryId;
            existing.Publisher = updatedBook.Publisher;
            existing.Isbn = updatedBook.Isbn;
            existing.Description = updatedBook.Description;
            existing.CreatedAt = updatedBook.CreatedAt;

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
