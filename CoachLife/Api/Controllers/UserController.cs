using CoachLife.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoachLife.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserAsync(int userId)
        {
            await _userService.GetUserAsync(userId);

            return Ok(userId);
        }
    }
}
