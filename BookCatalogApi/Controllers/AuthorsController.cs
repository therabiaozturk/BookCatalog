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

        // GET: api/authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAll();
            return Ok(authors);
        }

        // GET: api/authors/{id}
        [HttpGet("{id:guid}")]
        public IActionResult GetAuthor(Guid id)
        {
            var author = _authorService.GetById(id);
            return author is null ? NotFound() : Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            _authorService.Create(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        // PUT: api/authors/{id}
        [HttpPut("{id:guid}")]
        public IActionResult UpdateAuthor(Guid id, [FromBody] Author updatedAuthor)
        {
            var existing = _authorService.GetById(id);
            if (existing is null) return NotFound();

            updatedAuthor.Id = id;     // route id öncelikli
            _authorService.Update(updatedAuthor);
            return NoContent();
        }

        // PATCH: api/authors/{id}/createdAt/now  (opsiyonel ekstra)
        [HttpPatch("{id:guid}/createdAt/now")]
        public IActionResult TouchCreatedAt(Guid id)
        {
            var updated = _authorService.UpdateAuthorCreatedAtNow(id);
            return updated is null ? NotFound() : Ok(updated);
        }

        // DELETE: api/authors/{id}
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            var existing = _authorService.GetById(id);
            if (existing is null) return NotFound();

            _authorService.Delete(id);
            return NoContent();
        }
    }
}
