using InventoryIQ.Server.Dtos;
using InventoryIQ.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryIQ.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserService userService) : ControllerBase
    {
        private readonly UserService _userService = userService;

        [HttpPost("register")]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            var result = await _userService.AddUser(userDto);
            return Ok(result);
        }
    }
}
