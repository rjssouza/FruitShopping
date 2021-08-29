using Core.Domain.Interfaces.Services;
using Fruit.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Fruit.Domain.Interfaces.Services
{
    internal interface IFruitService : IEntityService<Guid, FruitEntity>
    {
        List<FruitEntity> GetFruitList();
    }
}