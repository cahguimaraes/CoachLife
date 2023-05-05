using CoachLife.Domain.Models;
using CoachLife.Domain.Services.Interfaces;
using FluentResults;

namespace CoachLife.Domain.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }

        public async Task<Result> GetUserAsync(int userId)
        {
            if (userId == 0)
                return Result.Fail("User not found");

            var user = new User();
            user.UserId = userId;
            user.UserFullName = "Carolaine";
            user.UserStatus = "Active";
            user.UserDocumentNumber = "123456";

            return Result.Ok();
        }
    }
}
