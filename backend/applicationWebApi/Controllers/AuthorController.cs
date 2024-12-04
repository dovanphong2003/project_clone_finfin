using BookStore.BLL.Services;
using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;

        public AuthorController(IAuthorService AuthorService)
        {
            _AuthorService = AuthorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await _AuthorService.GetAllAuthors();
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            var result = await _AuthorService.CreateAuthor(author);
            return result.IsSuccess
             ? Ok(result)
             : BadRequest(result.Error);
        }

        [HttpPatch]
        public async Task<IActionResult> updateAuthor([FromBody] UpdateRequest request)
        {
            var Author = new Author();
            var result = await _AuthorService.UpdateAuthor(Author, request.FieldsToUpdate, request.id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);

        }

        [HttpDelete]
        public async Task<IActionResult> deleteAuthor([FromQuery] long id)
        {
            var result = await _AuthorService.DeleteAuthor(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
