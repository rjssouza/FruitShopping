using AutoMapper;
using Core.Domain.Interfaces.Repositories;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Security.Application;
using Security.Application.AutoMapper.Account;
using Security.Application.Interfaces.AppServices;
using Security.Data.Context;
using Security.Data.Repositories;
using Security.Domain.Entities;
using Security.Domain.Interfaces.Repositories;
using Security.Domain.Interfaces.Services;
using Security.Domain.Services;

namespace Security.Configuration
{
    public static class AppRegistration
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            var mapper = GetMapper();
            services.AddSingleton(mapper);

            services.AddDataServices()
                    .AddDomainServices()
                    .AddInfrastructure()
                    .AddHttpClient();

            services.AddTransient<IAuthAppService, AuthAppService>();

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

        private static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<SecureDbContext>();
            services.AddScoped<ISecureUnitOfWork, SecureUnitOfWork>();
            services.AddScoped<IUnitOfWorkTransaction, SecureUnitOfWork>();

            return services;
        }

        private static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();

            return services;
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Configure<PasswordHasherOptions>(options =>
            {
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<SecureDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityServer.Cookie";
                config.LoginPath = "/Account/Login";
                config.LogoutPath = "/Account/Logout";
            });

            services.AddCors();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            .AddDeveloperSigningCredential()
            .AddInMemoryIdentityResources(Config.Ids)
            .AddInMemoryApiResources(Config.Apis)
            .AddInMemoryApiScopes(Config.ApiScope)
            .AddInMemoryClients(Config.Clients)
            .AddAspNetIdentity<ApplicationUser>();

            return services;
        }
    }
}