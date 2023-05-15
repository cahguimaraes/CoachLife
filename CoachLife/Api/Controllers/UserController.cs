using CoachLife.Application.Extensions.FluentResult;
using CoachLife.Domain.DTOs.Request;
using CoachLife.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoachLife.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [Route("{documentNumber}")]
        public async Task<IActionResult> GetUserAsync([FromRoute] string documentNumber)
        {
            var user = await _userService.GetUserAsync(documentNumber);

            if (user.IsFailed)
                return user.ToActionResult(HttpStatusCode.NotFound);

            return user.ToActionResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync([FromBody] UserRequestDto request)
        {
            // Call Validate or ValidateAsync and pass the object which needs to be validated
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            return StatusCode(StatusCodes.Status200OK, "Model is valid!");
        }
    }
}
