using CoachLife.Application.Extensions.FluentResult;
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

        [HttpGet("user/{documentNumber}")]
        public async Task<ActionResult> GetUserAsync(string documentNumber)
        {
            var user = await _userService.GetUserAsync(documentNumber);

            if (user.IsFailed)
                return user.ToActionResult();

            return user.ToActionResult();
        }

        //[HttpPost]
        //public async Task<Result<ResultDto>> Post(
        //    [FromBody] CreateUserRequest request)
        //{
        //    var user = await _userService.CreateUser(request.UserId, request.Password);

        //    if (user.IsFailed)
        //        return user.ToResultDto();

        //    return user.ToResultDto();
        //}
    }
}
