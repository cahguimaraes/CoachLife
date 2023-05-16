using CoachLife.Application.Extensions.FluentValidation;
using CoachLife.Domain.DTOs.Request;
using FluentValidation;

namespace CoachLife.Domain.DTOs.Validator
{

    public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
    {
        public UserRequestDtoValidator()
        {
            RuleFor(x => x.DocumentNumber).IsCpf();
        }
    }
}
