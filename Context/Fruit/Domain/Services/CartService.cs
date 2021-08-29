using Core.Domain.Interfaces.Repositories;
using Core.Domain.Services;
using Fruit.Domain.Entities.Sell;
using Fruit.Domain.Interfaces.Repositories;
using Fruit.Domain.Interfaces.Services;
using Fruit.Domain.Interfaces.Validations;
using System;

namespace Fruit.Domain.Services
{
    internal class CartService : EntityValidationService<Guid, CartEntity, ISellRepository, ICartValidation>, ICartService
    {
        public CartService(ICartValidation entityValidation, IUnitOfWork unityOfWork) : base(entityValidation, unityOfWork)
        {
        }
    }
}