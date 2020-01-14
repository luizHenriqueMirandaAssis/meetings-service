using Microsoft.Extensions.DependencyInjection;
using Schedule.Meetings.Application.Interfaces;
using Schedule.Meetings.Application.Services;

namespace Schedule.Meetings.Infrastructure.Ioc
{
    public class ApplicationInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IRoomsAppService, RoomsAppService>();
            services.AddScoped<IScheduleMeetingsAppService, ScheduleMeetingsAppService>();
        }
    }
}
