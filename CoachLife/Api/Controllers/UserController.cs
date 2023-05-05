using CoachLife.Application.Extensions;
using CoachLife.Domain.Services.Interfaces;
using FluentResults;
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
        public async Task<Result<ResultDto>> GetUserAsync(int userId)
        {
            var user = await _userService.GetUserAsync(userId);

            if (user.IsFailed)
                return user.ToResultDto();

            return user.ToResultDto();
        }
    }
}
