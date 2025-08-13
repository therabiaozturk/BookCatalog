
using BookCatalog.Model.Entities;

namespace BookCatalog.Model.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author> GetById(string id);
        Task<string> Create(Author author);
        Task Update(string id, Author author);
        Task Delete(string id);
    }
}
