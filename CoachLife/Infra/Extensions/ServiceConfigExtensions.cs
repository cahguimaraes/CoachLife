using CoachLife.Domain.Interfaces;
using CoachLife.Domain.Services;
using CoachLife.Domain.Services.Interfaces;
using CoachLife.Infra.Repositories;

namespace CoachLife.Infra.Extensions
{
    public static class ServiceConfigExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
