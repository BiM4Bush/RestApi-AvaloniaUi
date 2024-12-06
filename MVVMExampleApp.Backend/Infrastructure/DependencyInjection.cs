using MVVMExampleApp.Backend.Services;

namespace MVVMExampleApp.Backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //DI
            services.AddScoped<IAddService, AddService>();

            return services;
        }
    }
}
