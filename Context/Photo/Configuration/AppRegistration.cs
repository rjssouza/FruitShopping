using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Photo.Application.AppServices;
using Photo.Application.Interfaces.AppServices;
using Photo.Domain.Interfaces.Services;
using Photo.Domain.Interfaces.Validations;
using Photo.Domain.Services;
using Photo.Domain.Validations;

namespace Photo.Configuration
{
    public static class AppRegistration
    {
        public static IServiceCollection AddPhoto(this IServiceCollection services)
        {
            var mapper = GetMapper();
            services.AddSingleton(mapper);

            services.AddDataServices()
                    .AddInfrastructure()
                    .AddDomainServices();

            services.AddScoped<IPictureAppService, PictureAppService>();

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
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IPictureValidation, PictureValidation>();

            return services;
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}