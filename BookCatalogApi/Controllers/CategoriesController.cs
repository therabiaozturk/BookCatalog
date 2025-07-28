using Microsoft.AspNetCore.Mvc;
using BookCatalog.Model.Entities;
using BookCatalog.Business.Services;
using BookCatalog.Model.Interfaces;
namespace BookCatalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        // GET: api/Categories/{id}
        [HttpGet("{id}")]
        public IActionResult GetCategory(Guid id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.Create(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT: api/Categories/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(Guid id, Category updatedCategory)
        {
            var existingCategory = _categoryService.GetById(id);
            if (existingCategory == null)
                return NotFound();

            updatedCategory.Id = id;
            _categoryService.Update(updatedCategory);
            return NoContent();
        }

        // DELETE: api/Categories/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var existingCategory = _categoryService.GetById(id);
            if (existingCategory == null)
                return NotFound();

            _categoryService.Delete(id);
            return NoContent();
        }
    }
}

