using Core.Domain.Interfaces.Services;
using Fruit.Domain.Entities.Sell;
using System;

namespace Fruit.Domain.Interfaces.Services
{
    internal interface ICartService : IEntityService<Guid, CartEntity>
    {
    }
}