using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.BLL.Services.Interfaces;
namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _UserService.GetAllUsers();
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        // get extended name of author, category, publisher
        [HttpGet("extendedRole")]
        public async Task<IActionResult> GetAllUserExtendedRole()
        {
            var result = await _UserService.GetAllUsersxtendedRole();
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User User)
        {
            var result = await _UserService.CreateUser(User);
            return result.IsSuccess
             ? Ok(result)
             : BadRequest(result.Error);
        }

        [HttpPatch]
        public async Task<IActionResult> updateUser([FromBody] UpdateRequest request)
        {
            var User = new User();
            var result = await _UserService.UpdateUser(User, request.FieldsToUpdate, request.id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);

        }

        [HttpDelete]
        public async Task<IActionResult> deleteUser([FromQuery] long id)
        {
            var result = await _UserService.DeleteUser(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
