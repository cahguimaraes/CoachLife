using CoachLife.Domain.DTOs.Request;
using FluentValidation;

namespace CoachLife.Domain.DTOs.Validator
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("O campo Password não pode ser vazio")
                .Matches(@"^(?=.*[A-Z])(?=.*[\W])(?=.*[0-9]).{8,}$")
                .WithMessage("O campo Password deve possuir pelo menos 8 caracteres, com pelo menos 1 letra maiúcula, 1 número e 1 caractere especial");
        }
    }
}
