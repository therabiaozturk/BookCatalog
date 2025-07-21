using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogModel.Entities;
using BookCatalogDataAccess;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogBusiness.Services
{
    public class BookService : IBookService
    {
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
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Guid id, Book updatedBook)
        {
            var book = _context.Books.Find(id);
            if (book == null) return;

            book.Title = updatedBook.Title;
            book.AuthorId = updatedBook.AuthorId;
            book.CategoryId = updatedBook.CategoryId;
            book.Publisher = updatedBook.Publisher;
            book.Isbn = updatedBook.Isbn;
            book.Description = updatedBook.Description;
            book.Status = updatedBook.Status;

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
