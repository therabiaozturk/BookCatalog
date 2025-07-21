using Microsoft.AspNetCore.Mvc;
using BookCatalogModel.Entities;
using BookCatalogBusiness.Services;

namespace BookCatalogApi.Controllers
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

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(Guid id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.Create(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

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
