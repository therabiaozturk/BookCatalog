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

        public List<Author> GetAll() => _authorRepository.GetAll();

        public Author? GetById(Guid id) => _authorRepository.GetById(id);

        public void Create(Author author) => _authorRepository.Create(author);

        public void Update(Author author) => _authorRepository.Update(author.Id, author);

        public void Delete(Guid id) => _authorRepository.Delete(id);
    }
}
