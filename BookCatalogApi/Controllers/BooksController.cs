using Microsoft.AspNetCore.Mvc;
using BookCatalogModel.Entities;
using BookCatalogBusiness.Services;
using BookCatalogModel.Interfaces;
namespace BookCatalogApi.Controllers
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

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _bookService.Create(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, Book updatedBook)
        {
            _bookService.Update(id, updatedBook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
