using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webmotors.Challenge.Domain.Interfaces.Repositories;
using Webmotors.Challenge.Domain.Interfaces.Services;
using Webmotors.Challenge.Infra.Data;
using Webmotors.Challenge.Service;

namespace Webmotors.Challenge.Infra.IoC
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection WebmotorsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MSSQL_CONNECTION");
            return services
                .ConfigureRepositories(connectionString)
                .ConfigureDomainServices();
        }
        private static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAnuncioService, AnuncioService>();
            return services;
        }

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAnuncioRepository>(o => new AnuncioRepository(connectionString));
            return services;
        }
    }
}
