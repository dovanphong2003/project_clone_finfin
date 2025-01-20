using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.BLL.Services;
using BookStore.DAL.Entities;
using BookStore.DAL.Modal;
namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSoldController : ControllerBase
    {
        private readonly IBookSoldService _BookSoldService;

        public BookSoldController(IBookSoldService BookSoldService)
        {
            _BookSoldService = BookSoldService;
        }

        [HttpGet("extended")]
        public async Task<IActionResult> GetAllBookSoldsExtended()
        {
            var result = await _BookSoldService.GetAllBookSoldsExtended();
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookSold([FromBody] AddOrder addOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Log thông tin nhận được
            Console.WriteLine($"Order ID: {addOrder.order_id}");
            Console.WriteLine($"Created At: {addOrder.createdAt}");
            Console.WriteLine($"Created By: {addOrder.createdBy}");

            foreach (var item in addOrder.data)
            {
                Console.WriteLine($"Book ID: {item.book.book_id}, Title: {item.book.title}, Quantity: {item.quantity}");
            }

            // Gọi service xử lý thêm order
            var result = await _BookSoldService.CreateBookSold(addOrder);

            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result.Error);
        }
            
        [HttpPatch]
        public async Task<IActionResult> updateBookSold([FromBody] UpdateRequest request)
        {
            var order = new Order();
            var result = await _BookSoldService.UpdateBookSold(order, request.FieldsToUpdate, request.id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);

        }

        [HttpDelete]
        public async Task<IActionResult> deleteBookSold([FromQuery] long id)
        {
            var result = await _BookSoldService.DeleteBookSold(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
