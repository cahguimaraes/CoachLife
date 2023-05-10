using CoachLife.Application.Common.Enums;
using CoachLife.Domain.Models;

namespace CoachLife.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByDocumentNumber(string documentNumber);
        Task<User> GetById(int id);
        Task UpdateUserStatus(User user, UserStatus userEnum);
    }
}
