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

        public List<Author> GetAll() => _context.Authors.ToList();

        public Author? GetById(Guid id) => _context.Authors.Find(id);

        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Guid id, Author author)
        {
            var existing = _context.Authors.Find(id);
            if (existing == null) return;

            existing.FirstName = author.FirstName;
            existing.LastName = author.LastName;
            existing.BirthDate = author.BirthDate;
            existing.Biography = author.Biography;
            existing.CreatedAt = author.CreatedAt;

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var author = _context.Authors.Find(id);
            if (author == null) return;

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}