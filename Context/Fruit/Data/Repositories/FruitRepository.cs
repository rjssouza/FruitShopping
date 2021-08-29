using Core.Data.Repositories;
using Fruit.Data.Context;
using Fruit.Domain.Entities;
using Fruit.Domain.Interfaces.Repositories;
using System;

namespace Fruit.Data.Repositories
{
    internal class FruitRepository : EntityRepository<Guid, FruitEntity, FruitShoppingDbContext>, IFruitRepository
    {
        public FruitRepository(FruitShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}