using CoachLife.Domain.DTOs.Request;
using FluentValidation;

namespace CoachLife.Domain.DTOs.Validator
{

    public class UserRequestValidator : AbstractValidator<UserRequestDto>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.DocumentNumber)
                .NotEmpty()
                .NotNull();
        }
    }
}
