using Core.Data.Repositories;
using Fruit.Data.Context;
using Fruit.Domain.Entities;
using Fruit.Domain.Interfaces.Repositories;
using System;

namespace Fruit.Data.Repositories
{
    internal class FruitInventoryRepository : EntityRepository<Guid, FruitInventoryEntity, FruitShoppingDbContext>, IFruitInventoryRepository
    {
        public FruitInventoryRepository(FruitShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}