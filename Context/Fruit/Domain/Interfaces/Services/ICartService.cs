using Core.Domain.Interfaces.Services;
using Fruit.Domain.Entities.Cart;
using System;

namespace Fruit.Domain.Interfaces.Services
{
    internal interface ICartService : IEntityService<Guid, CartEntity>
    {
    }
}