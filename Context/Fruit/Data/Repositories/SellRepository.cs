using Core.Data.Repositories;
using Fruit.Data.Context;
using Fruit.Domain.Entities.Sell;
using Fruit.Domain.Interfaces.Repositories;
using System;

namespace Fruit.Data.Repositories
{
    internal class SellRepository : EntityRepository<Guid, CartEntity, FruitShoppingDbContext>, ISellRepository
    {
        public SellRepository(FruitShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}