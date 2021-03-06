using Core.Domain.Interfaces.Repositories;
using Fruit.Domain.Entities;
using System;

namespace Fruit.Domain.Interfaces.Repositories
{
    internal interface IFruitRepository : IEntityRepository<Guid, FruitEntity>
    {
    }
}