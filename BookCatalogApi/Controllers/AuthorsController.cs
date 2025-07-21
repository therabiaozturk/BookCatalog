using Microsoft.AspNetCore.Mvc;
using BookCatalogModel.Entities;
using BookCatalogDataAccess;

namespace BookCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _context.Authors.ToList();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(Guid id, Author updatedAuthor)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
                return NotFound();

            // Güncelleme alanları
            author.FirstName = updatedAuthor.FirstName;
            author.LastName = updatedAuthor.LastName;
            author.BirthDate = updatedAuthor.BirthDate;
            author.Biography = updatedAuthor.Biography;
            author.CreatedAt = updatedAuthor.CreatedAt;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
                return NotFound();

            _context.Authors.Remove(author);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
