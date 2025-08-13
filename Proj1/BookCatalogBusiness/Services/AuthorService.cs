using BookCatalog.DataAccess;
using BookCatalog.Model.Entities;
using BookCatalog.Model.Interfaces;

namespace BookCatalog.Business.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorDTO>> GetAll() => await _authorRepository.GetAll();

        public async Task<Author> GetById(string id)
        {
            return await _authorRepository.GetById(id);
        }
        public async Task<Author> UpdateAuthorCreatedAtNow(string id)
        {
            var author = await GetById(id);
            if (author == null) return null; 

            author.CreatedAt = DateTime.UtcNow;
            await _authorRepository.Update(author.Id, author);
            return author;
        }

        public async Task<string> Create(AuthorDTO author)
        {

            return await _authorRepository.Create(mapper.map<Author>(author));
        }

        public async Task Update(Author author)
        {
            await _authorRepository.Update(author.Id, author);
        }

        public async Task Delete(string id)
        {
            await _authorRepository.Delete(id);
        }
    }
}
