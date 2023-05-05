using CoachLife.Domain.Services;
using CoachLife.Domain.Services.Interfaces;

namespace CoachLife.Infra.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            // services.AddDbContext<User>();
        }
    }
}
