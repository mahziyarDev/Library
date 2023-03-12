using Library.Service.DTOs.Admin.User;
using Library.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagement : ControllerBase
    {
        private readonly IUserService _userService;

        public UserManagement(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var data = (await _userService.GetUser()).Data;
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDTO userDto)
        {
            var result = await _userService.UpdateUser(userDto);
            return Ok(result);
        }
    }
}
