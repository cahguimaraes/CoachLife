using CoachLife.Domain.Models;
using CoachLife.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoachLife.Domain.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }

        public async Task<IActionResult> GetUserAsync(int userId)
        {
            if (userId == 0)
                return null;

            var user = new User();
            user.UserId = userId;
            user.UserFullName = "Carolaine";
            user.UserStatus = "Active";
            user.UserDocumentNumber = "123456";

            return null;
        }
    }
}
