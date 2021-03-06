using Core.Domain.Interfaces.Services;
using Fruit.Domain.Entities;
using System;

namespace Fruit.Domain.Interfaces.Services
{
    internal interface IFruitInventoryService : IEntityService<Guid, FruitInventoryEntity>
    {
    }
}