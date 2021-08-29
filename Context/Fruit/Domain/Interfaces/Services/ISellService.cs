using Core.Domain.Interfaces.Services;
using Fruit.Domain.Entities.Sell;
using System;

namespace Fruit.Domain.Interfaces.Services
{
    internal interface ISellService : IEntityService<Guid, SellEntity>
    {
    }
}