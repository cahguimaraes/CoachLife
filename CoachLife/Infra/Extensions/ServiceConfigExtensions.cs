using CoachLife.Domain.DTOs.Validator;
using CoachLife.Domain.Interfaces;
using CoachLife.Domain.Services;
using CoachLife.Domain.Services.Interfaces;
using CoachLife.Infra.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CoachLife.Infra.Extensions
{
    public static class ServiceConfigExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<UserRequestValidator>();
        }
    }
}
