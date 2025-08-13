using Microsoft.AspNetCore.Mvc;
using BookCatalog.Model.Entities;
using BookCatalog.Business.Services;
using BookCatalog.Model.Interfaces;
namespace BookCatalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        //posta çevrilfi
        [HttpPost("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }
        //post a çevircez
        [HttpPost("GetBookById")]
        public IActionResult GetBookById(Guid id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost("CreateBook")]
        public IActionResult CreateBook(Book book)
        {
            _bookService.Create(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }
        //Post a çevrildi
        [HttpPost("UpdateBook/{id}")]
        public IActionResult UpdateBook(Guid id, Book updatedBook)
        {
            _bookService.Update(id, updatedBook);
            return NoContent();
        }

        [HttpPost("DeleteBook/{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
        [HttpPost("Filter")]
        public IActionResult Filter([FromBody] BookFilter filter)
        {
            var query = _bookService.GetAll().AsQueryable(); 

            if (!string.IsNullOrWhiteSpace(filter.TitleContains))
                query = query.Where(b => b.Title.Contains(filter.TitleContains, StringComparison.OrdinalIgnoreCase));

            if (filter.AuthorId.HasValue)
                query = query.Where(b => b.AuthorId == filter.AuthorId.Value);

            if (filter.CategoryId.HasValue)
                query = query.Where(b => b.CategoryId == filter.CategoryId.Value);

            if (!string.IsNullOrWhiteSpace(filter.Isbn))
                query = query.Where(b => b.Isbn == filter.Isbn);

            var total = query.Count();
            var items = query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            return Ok(new { Total = total, Items = items });
        }

    }
}
