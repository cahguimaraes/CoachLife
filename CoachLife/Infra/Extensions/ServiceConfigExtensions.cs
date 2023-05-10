using CoachLife.Domain.DTOs.Request;
using CoachLife.Domain.DTOs.Validator;
using CoachLife.Domain.Interfaces;
using CoachLife.Domain.Services;
using CoachLife.Domain.Services.Interfaces;
using CoachLife.Infra.Repositories;
using FluentValidation;

namespace CoachLife.Infra.Extensions
{
    public static class ServiceConfigExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ISignUpService, SignUpService>();
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
            //services.AddSingleton<IAmazonCognitoIdentityProvider>(cognitoIdentityProvider);
            //  services.AddSingleton<CognitoUserPool>(cognitoUserPool);
        }
    }
}
