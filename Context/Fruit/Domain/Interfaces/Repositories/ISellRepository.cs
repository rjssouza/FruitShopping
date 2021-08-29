using Core.Domain.Interfaces.Repositories;
using Fruit.Domain.Entities.Sell;
using System;

namespace Fruit.Domain.Interfaces.Repositories
{
    internal interface ISellRepository : IEntityRepository<Guid, CartEntity>
    {
    }
}