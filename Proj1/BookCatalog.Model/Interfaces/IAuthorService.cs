using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Model.Entities;

namespace BookCatalog.Model.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAll();
        Task<Author> GetById(string id);
        Task<string> Create(Author author);
        Task Update(Author author);
        Task Delete(string id);
        Task<Author> UpdateAuthorCreatedAtNow(string id);
    }
}
