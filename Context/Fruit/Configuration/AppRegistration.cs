using AutoMapper;
using Core.Data.Repositories;
using Core.Domain.Interfaces.Repositories;
using Fruit.Application.AppServices;
using Fruit.Application.AutoMapper;
using Fruit.Application.Interfaces.AppServices;
using Fruit.Data.Context;
using Fruit.Data.Repositories;
using Fruit.Domain.Interfaces.Repositories;
using Fruit.Domain.Interfaces.Services;
using Fruit.Domain.Interfaces.Validations;
using Fruit.Domain.Services;
using Fruit.Domain.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace Persona.Configuration
{
    public static class AppRegistration
    {
        public static IServiceCollection AddFruitShopping(this IServiceCollection services)
        {
            var mapper = GetMapper();
            services.AddSingleton(mapper);

            services.AddDataServices()
                    .AddInfrastructure()
                    .AddDomainServices()
                    .AddHttpClient();

            services.AddTransient<IFruitAppService, FruitAppService>();

            return services;
        }

        public static IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelMapping());
                mc.AddProfile(new ViewModelToDomainMapping());
                mc.AddProfile(new Fruit.Application.AutoMapper.Sell.DomainToViewModelMapping());
                mc.AddProfile(new Fruit.Application.AutoMapper.Sell.ViewModelToDomainMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            return mapper;
        }

        private static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<FruitShoppingDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork<FruitShoppingDbContext>>();
            services.AddTransient<IUnitOfWorkTransaction, UnitOfWork<FruitShoppingDbContext>>();
            services.AddTransient<IFruitInventoryRepository, FruitInventoryRepository>();
            services.AddTransient<IFruitRepository, FruitRepository>();
            services.AddTransient<ISellRepository, SellRepository>();

            return services;
        }

        private static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IFruitInventoryService, FruitInventoryService>();
            services.AddTransient<IFruitService, FruitService>();
            services.AddTransient<ICartService, CartService>();

            return services;
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IFruitInventoryValidation, FruitInventoryValidation>();
            services.AddTransient<IFruitValidation, FruitValidation>();
            services.AddTransient<ICartValidation, CartValidation>();

            return services;
        }
    }
}