using CoachLife.Domain.Models;
using FluentResults;

namespace CoachLife.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<User>> GetUserAsync(string documentNumber);
        Task<Result> CreateUser(int id, string password);
    }
}
