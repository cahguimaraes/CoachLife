using CoachLife.Application.Common.Enums;
using CoachLife.Domain.Interfaces;
using CoachLife.Domain.Models;
using CoachLife.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CoachLife.Infra.Repositories
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(LifeCoachContext db) : base(db)
        {
        }

        public async Task<User> GetByDocumentNumber(string documentNumber)
        {
            return await DbSet.Where(x => x.UserDocumentNumber == documentNumber).FirstOrDefaultAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await DbSet.Where(x => x.UserId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateUserStatus(User user, UserStatus userEnum)
        {
            user.UserStatus = userEnum.ToString();

            await SaveChanges();
        }

    }

}
