using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.BLL.Services;
namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _BookService;

        public BookController(IBookService BookService)
        {
            _BookService = BookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _BookService.GetAllBooks();
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book Book)
        {
            var result = await _BookService.CreateBook(Book);
            return result.IsSuccess
             ? Ok(result)
             : BadRequest(result.Error);
        }

        [HttpPatch]
        public async Task<IActionResult> updateBook([FromBody] UpdateRequest request)
        {
            var Book = new Book();
            var result = await _BookService.UpdateBook(Book, request.FieldsToUpdate, request.id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);

        }

        [HttpDelete]
        public async Task<IActionResult> deleteBook([FromQuery] long id)
        {
            var result = await _BookService.DeleteBook(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
