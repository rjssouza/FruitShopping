using Core.Domain.Interfaces.Repositories;
using Core.Domain.Services;
using Fruit.Domain.Entities;
using Fruit.Domain.Interfaces.Repositories;
using Fruit.Domain.Interfaces.Services;
using Fruit.Domain.Interfaces.Validations;
using System;

namespace Fruit.Domain.Services
{
    internal class FruitInventoryService : EntityValidationService<Guid, FruitInventoryEntity, IFruitInventoryRepository, IFruitInventoryValidation>, IFruitInventoryService
    {
        public FruitInventoryService(IFruitInventoryValidation entityValidation, IUnitOfWork unityOfWork) 
            : base(entityValidation, unityOfWork)
        {
        }
    }
}