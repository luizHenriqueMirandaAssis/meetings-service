using Microsoft.Extensions.DependencyInjection;
using Schedule.Meetings.Domain.Interfaces.Repositories;
using Schedule.Meetings.Infrastructure.Data.Repositories;

namespace Schedule.Meetings.Infrastructure.Ioc
{
    public class InfraInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRoomsRepository, RoomsRepository>();
            services.AddScoped<IScheduleMeetingsRepository, ScheduleMeetingsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
