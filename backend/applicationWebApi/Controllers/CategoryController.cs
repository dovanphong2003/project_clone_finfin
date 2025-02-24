using BookStore.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.BLL.Services;
using BookStore.DTO.DTOs;
using BookStore.DAL.Entities;
using Microsoft.OpenApi.Validations;
namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategories();
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            var category = new Category { category_id = categoryDTO.category_id, name = categoryDTO.name, is_active = categoryDTO.is_active, parent_id = categoryDTO.parent_id, isDeleted = false, createdAt = DateTime.Now, updatedAt = DateTime.Now };
            var result = await _categoryService.CreateCategory(category);
            return result.IsSuccess
             ? Ok(result)
             : BadRequest(result.Error);
        }

        [HttpPatch]
        public async Task<IActionResult> updateCategory([FromBody] UpdateRequest request)
        {
            var category = new Category();
            var result = await _categoryService.UpdateCategory(category, request.FieldsToUpdate, request.id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);

        }

        [HttpDelete]
        public async Task<IActionResult> deleteCategory([FromQuery] long id)
        {
            var result = await _categoryService.DeleteCategory(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
