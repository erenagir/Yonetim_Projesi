using X.Yönetim.UI.Services.Abstraction;
using X.Yönetim.UI.Services.Implementation;

namespace X.Yönetim.UI.Configurations
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IRestService, RestService>();
            
            return services;
        }
    }
}
