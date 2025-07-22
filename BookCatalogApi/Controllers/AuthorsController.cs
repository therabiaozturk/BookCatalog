using Microsoft.AspNetCore.Mvc;
using BookCatalogModel.Entities;
using BookCatalogBusiness.Services;
using BookCatalogModel.Interfaces;

namespace BookCatalogApi.Controllers
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

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAll();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var author = _authorService.GetById(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            _authorService.Create(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(Guid id, Author updatedAuthor)
        {
            var existing = _authorService.GetById(id);
            if (existing == null)
                return NotFound();

            _authorService.Update(id, updatedAuthor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            var author = _authorService.GetById(id);
            if (author == null)
                return NotFound();

            _authorService.Delete(id);
            return NoContent();
        }
    }
}
