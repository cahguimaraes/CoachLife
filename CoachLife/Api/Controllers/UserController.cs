using CoachLife.Application.Extensions.FluentResult;
using CoachLife.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<IActionResult> GetUserAsync(string documentNumber)
        {
            var user = await _userService.GetUserAsync(documentNumber);

            if (user.IsFailed)
                return user.ToActionResult(HttpStatusCode.NotFound);

            return user.ToActionResult(HttpStatusCode.OK);
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
