using CoachLife.Domain.Models;

namespace CoachLife.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByDocumentNumber(string documentNumber);
    }
}
