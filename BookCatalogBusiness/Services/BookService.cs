using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalogModel.Entities;
using BookCatalogDataAccess;
using BookCatalogModel.Interfaces;

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
            return _context.Books.Find(id);
        }

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
            existingBook.ISBN = updatedBook.ISBN;
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
