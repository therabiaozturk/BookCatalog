using BookCatalog.Business.Services;
using BookCatalog.Model.Entities;
using BookCatalog.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAll();
            return Ok(authors);
        }

        // GET: api/Authors/{id}
        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var author = _authorService.GetById(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        // POST: api/Authors
        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            _authorService.Create(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        // PUT: api/Authors/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(Guid id, Author updatedAuthor)
        {
            var existingAuthor = _authorService.GetById(id);
            if (existingAuthor == null)
                return NotFound();

            updatedAuthor.Id = id;
            _authorService.Update(updatedAuthor);
            return NoContent();
        }

        // DELETE: api/Authors/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            var existingAuthor = _authorService.GetById(id);
            if (existingAuthor == null)
                return NotFound();

            _authorService.Delete(id);
            return NoContent();
        }
    }
}
