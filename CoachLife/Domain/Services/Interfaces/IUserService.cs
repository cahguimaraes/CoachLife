using FluentResults;

namespace CoachLife.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result> GetUserAsync(string documentNumber);
    }
}
