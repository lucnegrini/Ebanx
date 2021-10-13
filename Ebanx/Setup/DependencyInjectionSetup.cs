using Ebanx.Core.Interfaces;
using Ebanx.Core.Services;
using Ebanx.Infrastructure.Abstractions;
using Ebanx.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ebanx.Setup
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IAccountService, AccountService>();

            return services;
        }
    }

}
