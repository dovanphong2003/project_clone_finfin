using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.BLL.Services;
using BookStore.Shared.Response;
namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _bookService.GetAllBooks();
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
    }
}
