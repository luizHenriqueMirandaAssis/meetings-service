using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Meetings.Infrastructure.Ioc
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            InfraInjector.RegisterServices(services);
            ApplicationInjector.RegisterServices(services);
        }
    }
}
