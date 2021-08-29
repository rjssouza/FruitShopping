using Core.Data.Repositories;
using Fruit.Data.Context;
using Fruit.Domain.Entities.Cart;
using Fruit.Domain.Interfaces.Repositories;
using System;

namespace Fruit.Data.Repositories
{
    internal class CartRepository : EntityRepository<Guid, CartEntity, FruitShoppingDbContext>, ICartRepository
    {
        public CartRepository(FruitShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}