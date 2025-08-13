using BookCatalog.Model.Entities;
using BookCatalog.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetById(string id)
        {
            Author existingAuthor = await _context.Authors.FindAsync(id) ?? throw new Exception("author not found");
            return existingAuthor;
        }

        public async Task<string> Create(Author author)
        {
            author.Id = Guid.NewGuid().ToString();
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }

        public async Task Update(string id, Author author)
        {
            Author existing = await GetById(id) ?? throw new Exception("author not found");

            existing.FirstName = author.FirstName;
            existing.LastName = author.LastName;
            existing.BirthDate = author.BirthDate;
            existing.Biography = author.Biography;
            existing.CreatedAt = author.CreatedAt;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Author existingAuthor = await _context.Authors.FindAsync(id) ?? throw new Exception("author not found");

            _context.Authors.Remove(existingAuthor);
            await _context.SaveChangesAsync();
        }
    }
}