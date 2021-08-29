﻿using Core.Domain.Interfaces.Repositories;
using Core.Domain.Services;
using Fruit.Domain.Entities;
using Fruit.Domain.Interfaces.Repositories;
using Fruit.Domain.Interfaces.Services;
using Fruit.Domain.Interfaces.Validations;
using System;

namespace Fruit.Domain.Services
{
    internal class FruitService : EntityValidationService<Guid, FruitEntity, IFruitRepository, IFruitValidation>, IFruitService
    {
        public FruitService(IFruitValidation entityValidation, IUnitOfWork unityOfWork)
            : base(entityValidation, unityOfWork)
        {
        }
    }
}