using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Persona.Configuration
{
    public static class AppRegistration
    {
        public static IServiceCollection AddPersona(this IServiceCollection services)
        {
            var mapper = GetMapper();
            services.AddSingleton(mapper);

            services.AddDataServices()
                    .AddInfrastructure()
                    .AddDomainServices()
                    .AddHttpClient();

            return services;
        }

        public static IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
            });

            IMapper mapper = mapperConfig.CreateMapper();

            return mapper;
        }

        private static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}