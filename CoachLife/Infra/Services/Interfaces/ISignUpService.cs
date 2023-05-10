using CoachLife.Domain.Models;

namespace CoachLife.Infra.Services.Interfaces
{
    public interface ISignUpService
    {
        public Task SignUp(User request, string password);
    }
}
