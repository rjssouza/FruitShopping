using Core.Domain.Interfaces.Repositories;
using Core.Domain.Services;
using Fruit.Domain.Entities.Sell;
using Fruit.Domain.Interfaces.Repositories;
using Fruit.Domain.Interfaces.Services;
using Fruit.Domain.Interfaces.Validations;
using System;

namespace Fruit.Domain.Services
{
    internal class SellService : EntityValidationService<Guid, SellEntity, ISellRepository, ISellValidation>, ISellService
    {
        public SellService(ISellValidation entityValidation, IUnitOfWork unityOfWork) : base(entityValidation, unityOfWork)
        {
        }
    }
}