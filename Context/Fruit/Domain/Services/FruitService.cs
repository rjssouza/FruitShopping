using Core.Domain.Interfaces.Repositories;
using Core.Domain.Services;
using Fruit.Domain.Entities;
using Fruit.Domain.Interfaces.Repositories;
using Fruit.Domain.Interfaces.Services;
using Fruit.Domain.Interfaces.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fruit.Domain.Services
{
    internal class FruitService : EntityValidationService<Guid, FruitEntity, IFruitRepository, IFruitValidation>, IFruitService
    {
        public FruitService(IFruitValidation entityValidation, IUnitOfWork unityOfWork)
            : base(entityValidation, unityOfWork)
        {
        }

        public List<FruitEntity> GetFruitList()
        {
            var fruitList = _unitOfWork.GetRepository<IFruitRepository>()
                .GetAll()
                .OrderBy(t => t.Name)
                .ThenBy(t => t.Price);

            return fruitList.ToList();
        }
    }
}