using Core.Data.Context;
using Fruit.Domain.Entities;
using Fruit.Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fruit.Data.Context
{
    internal class FruitShoppingDbContext : CoreDbContext
    {
        public FruitShoppingDbContext(IConfiguration configuration)
            : base(configuration)
        {
        }

        public DbSet<CartEntity> Cart { get; set; }
        public DbSet<CartItemEntity> CartItem { get; set; }
        public DbSet<FruitEntity> Fruit { get; set; }
        public DbSet<FruitInventoryEntity> FruitInventory { get; set; }
        public DbSet<FruitPictureEntity> FruitPicture { get; set; }

        protected override string DbName => "fruitshoppingdb";
    }
}