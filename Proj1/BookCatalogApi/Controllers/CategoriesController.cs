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

        // GET: api/Categories/{id} posta çevrildi
        [HttpPost("GetCategories")]
            public IActionResult GetCategories()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        // GET: api/Categories/{id}  post a çevrildi
        [HttpPost("GetCategory")]
        public IActionResult GetCategory(Guid id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST: api/Categories
        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            _categoryService.Create(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT: api/Categories/{id} POST A ÇEVRİLDİ
        [HttpPost("Update/{id}")]
        public IActionResult UpdateCategory(Guid id, Category updatedCategory)
        {
            var existingCategory = _categoryService.GetById(id);
            if (existingCategory == null)
                return NotFound();

            updatedCategory.Id = id;
            _categoryService.Update(updatedCategory);
            return NoContent();
        }
        //ÇEVRİLDİ
        [HttpPost("\"Delete/{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var existingCategory = _categoryService.GetById(id);
            if (existingCategory == null)
                return NotFound();

            _categoryService.Delete(id);
            return NoContent();
        }
        [HttpPost("Filter")]
        public IActionResult Filter([FromBody] CategoryFilter filter)
        {
            var query = _categoryService.GetAll().AsQueryable(); 

            if (!string.IsNullOrWhiteSpace(filter.NameContains))
                query = query.Where(c => c.Name.Contains(filter.NameContains, StringComparison.OrdinalIgnoreCase));

            var total = query.Count();
            var items = query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            return Ok(new { Total = total, Items = items });
        }

    }
}

