using Microsoft.AspNetCore.Mvc;

namespace CoachLife.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> GetUserAsync(int userId);
    }
}
