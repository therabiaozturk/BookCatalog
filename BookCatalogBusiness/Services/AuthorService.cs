using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalogDataAccess;
using BookCatalogModel.Entities;

namespace BookCatalogBusiness.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author? GetById(Guid id)
        {
            return _context.Authors.Find(id);
        }

        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Guid id, Author updatedAuthor)
        {
            var author = _context.Authors.Find(id);
            if (author == null) return;

            author.FirstName = updatedAuthor.FirstName;
            author.LastName = updatedAuthor.LastName;
            author.BirthDate = updatedAuthor.BirthDate;
            author.Biography = updatedAuthor.Biography;
            author.CreatedAt = updatedAuthor.CreatedAt;

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