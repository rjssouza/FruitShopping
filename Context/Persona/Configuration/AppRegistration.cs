using AutoMapper;
using Core.Domain.Interfaces.Repositories;
using Core.Utils;
using Microsoft.Extensions.DependencyInjection;
using Persona.AntiCorruption;
using Persona.Application.AppServices;
using Persona.Application.Interfaces.AppServices;
using Persona.Data.Context;
using Persona.Data.Repositories;
using Persona.Domain.Interfaces.Infrastructure;
using Persona.Domain.Interfaces.Repositories;
using Persona.Domain.Interfaces.Services;
using Persona.Domain.Interfaces.Validations;
using Persona.Domain.Services;
using Persona.Domain.Validations;
using STI.Application.AutoMapper.Persona;

namespace Persona.Configuration
{
    public static class AppRegistration
    {
        private static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<PersonaDbContext>();
            services.AddScoped<IPersonaUnitOfWork, PersonaUnitOfWork>();
            services.AddScoped<IUnitOfWorkTransaction, PersonaUnitOfWork>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IPersonaPhotoRepository, PersonaPhotoRepository>();

            return services;
        }

        private static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<IPersonaPhotoService, PersonaPhotoService>();
            services.AddScoped<IPersonaValidation, PersonaValidation>();
            services.AddScoped<IPersonaPhotoValidation, PersonaPhotoValidation>();

            return services;
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPictureInfraService, PictureService>();

            return services;
        }

        public static IServiceCollection AddPersona(this IServiceCollection services)
        {
            var mapper = GetMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<AzureKeyVaultClientCertificate>();

            services.AddDataServices()
                    .AddInfrastructure()
                    .AddDomainServices()
                    .AddHttpClient();

            services.AddScoped<IPersonaAppService, PersonaAppService>();

            return services;
        }

        public static IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelMapping());
                mc.AddProfile(new ViewModelToDomainMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            return mapper;
        }
    }
}