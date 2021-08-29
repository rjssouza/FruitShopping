using Core.Data.Context;
using Fruit.Domain.Entities;
using Fruit.Domain.Entities.Sell;
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

        public DbSet<FruitEntity> Fruit { get; set; }
        public DbSet<FruitInventoryEntity> FruitInventory { get; set; }
        public DbSet<FruitPictureEntity> FruitPicture { get; set; }
        public DbSet<SellEntity> Sell { get; set; }
        public DbSet<SellItemEntity> SellItem { get; set; }

        protected override string DbName => "fruitshoppingdb";
    }
}