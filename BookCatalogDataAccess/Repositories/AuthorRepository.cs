using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalog.Model.Entities;
using BookCatalog.Model.Interfaces;

namespace BookCatalog.DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author? GetById(Guid id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Guid id, Author updatedAuthor)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                author.FirstName = updatedAuthor.FirstName;
                author.LastName = updatedAuthor.LastName;
                author.BirthDate = updatedAuthor.BirthDate;
                author.Biography = updatedAuthor.Biography;
                author.CreatedAt = updatedAuthor.CreatedAt;
                _context.SaveChanges();
            }
        }
    }
}
