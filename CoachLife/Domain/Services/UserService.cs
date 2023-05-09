using CoachLife.Domain.Interfaces;
using CoachLife.Domain.Services.Interfaces;
using FluentResults;

namespace CoachLife.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Result> GetUserAsync(string documentNumber)
        {
            var user = await _userRepository.GetByDocumentNumber(documentNumber);

            if (user == null)
                return Result.Fail("User not found");

            //return Result.Ok(_mapper.Map<SearchUserResponse>(user));
            return Result.Ok();
        }
    }
}
