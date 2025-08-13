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

        // GET: api/authors  POST A ÇEVRİLDİ
        [HttpPost("GetAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAll();
            return Ok(authors);
        }

        // GET: api/authors/GetAuthor/{id}   POST OALRAK DEĞİŞTİ
        [HttpPost("GetAuthor")] 
        public async Task<IActionResult> GetAuthor(string id)
        {
            var author = await _authorService.GetById(id);
            return author is null ? NotFound() : Ok(author);
        }

        // POST: api/authors
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            await _authorService.Create(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        // PUT: api/authors/{id} POST OLARAK DEĞİŞTİRİLDİ
        [HttpPost("Update")]
        public async Task<IActionResult> Update(string id, [FromBody] Author updatedAuthor)
        {
            var existing = await _authorService.GetById(id);
            if (existing is null) return NotFound();

            updatedAuthor.Id = id;     
            await _authorService.Update(updatedAuthor);
            return NoContent();
        }

        // PATCH: api/authors/{id}/createdAt/now POST OLARAK DEĞİŞİTİRİLDİ
        [HttpPost("TouchCreatedAt")]
        public async Task<IActionResult> TouchCreatedAt(string id)
        {
            var updated = await _authorService.UpdateAuthorCreatedAtNow(id);
            return updated is null ? NotFound() : Ok(updated);
        }

        // DELETE: api/authors/{id}
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(string id)
        { 
            await _authorService.Delete(id);
            return NoContent();
        }
        [HttpPost("Filter")]
        public async Task<IActionResult> Filter([FromBody] AuthorFilter filter)
        {
            var list = await _authorService.GetAll(); 
            var query = list.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.NameContains))
                query = query.Where(a => a.Name.Contains(filter.NameContains, StringComparison.OrdinalIgnoreCase)); 

            if (filter.CreatedFrom.HasValue)
                query = query.Where(a => a.CreatedAt >= filter.CreatedFrom.Value); 

            if (filter.CreatedTo.HasValue)
                query = query.Where(a => a.CreatedAt <= filter.CreatedTo.Value);

            var total = query.Count();
            var items = query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            return Ok(new { Total = total, Items = items });
        }

    }
}
