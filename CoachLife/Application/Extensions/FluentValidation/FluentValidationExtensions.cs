using FluentValidation;

namespace CoachLife.Application.Extensions.FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> IsCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder.SetValidator(new CPFValidator<T>()).WithMessage("Invalid document. Make sure that the document is a valid CPF.");
    }
}
