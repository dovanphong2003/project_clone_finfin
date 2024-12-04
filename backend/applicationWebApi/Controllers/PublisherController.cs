using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.BLL.Services.Interfaces;
namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _PublisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _PublisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var result = await _PublisherService.GetAllPublishers();
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher([FromBody] Publisher publisher)
        {
            var result = await _PublisherService.CreatePublisher(publisher);
            return result.IsSuccess
             ? Ok(result)
             : BadRequest(result.Error);
        }

        [HttpPatch]
        public async Task<IActionResult> updatePublisher([FromBody] UpdateRequest request)
        {
            var Publisher = new Publisher();
            var result = await _PublisherService.UpdatePublisher(Publisher, request.FieldsToUpdate, request.id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);

        }

        [HttpDelete]
        public async Task<IActionResult> deletePublisher([FromQuery] long id)
        {
            var result = await _PublisherService.DeletePublisher(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
