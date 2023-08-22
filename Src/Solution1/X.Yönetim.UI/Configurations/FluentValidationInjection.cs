
using FluentValidation;
using FluentValidation.AspNetCore;
using X.Yönetim.UI.Validators.Accounts;

namespace X.Yönetim.UI.Configurations
{
    public static class FluentValidationInjection
    {
        public static IServiceCollection AddFluentValidationService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining(typeof(LoginValidator));

            return services;
        }
    }
}
