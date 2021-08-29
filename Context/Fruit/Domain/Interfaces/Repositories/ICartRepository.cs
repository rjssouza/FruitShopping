using Core.Domain.Interfaces.Repositories;
using Fruit.Domain.Entities.Cart;
using System;

namespace Fruit.Domain.Interfaces.Repositories
{
    internal interface ICartRepository : IEntityRepository<Guid, CartEntity>
    {
    }
}