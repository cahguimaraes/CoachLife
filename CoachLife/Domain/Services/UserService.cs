using CoachLife.Application.Common.Enums;
using CoachLife.Domain.Interfaces;
using CoachLife.Domain.Models;
using CoachLife.Domain.Services.Interfaces;
using FluentResults;

namespace CoachLife.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        //private readonly ISignUpService _signUpService;
        public UserService(IUserRepository userRepository)//, ISignUpService signUpService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            //  _signUpService = signUpService ?? throw new ArgumentNullException(nameof(signUpService));
        }

        public async Task<Result> CreateUser(int id, string password)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                return Result.Fail("User not found");

            // await _signUpService.SignUp(user, password);

            await _userRepository.UpdateUserStatus(user, UserStatus.INATIVE);

            //return Result.Ok(_mapper.Map<SearchUserResponse>(user));
            return Result.Ok();
        }

        public async Task<Result<User>> GetUserAsync(string documentNumber)
        {
            var user = await _userRepository.GetByDocumentNumber(documentNumber);

            if (user == null)
                return Result.Fail<User>("User not found");

            //return Result.Ok(_mapper.Map<SearchUserResponse>(user));
            return Result.Ok(user);
        }
    }
}
