using Core.Domain.Entities;
using Fruit.Domain.Entities.Sell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Fruit.Domain.Entities
{
    internal class FruitEntity : Entity<FruitEntity>
    {
        public string Description { get; private set; }
        public virtual FruitInventoryEntity Inventory { get; private set; }
        public Guid InventoryId { get; set; }
        public string Name { get; private set; }
        public virtual List<FruitPictureEntity> Pictures { get; private set; }
        public decimal Price { get; private set; }
        public virtual List<SellItemEntity> SellItems { get; private set; }

        public override void Configure(EntityTypeBuilder<FruitEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Fruit");

            builder.Property(t => t.Name).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Price).IsRequired();
            builder.HasMany(t => t.Pictures)
                   .WithOne(item => item.Fruit)
                   .HasForeignKey(item => item.FruitId);
            builder.HasOne(t => t.Inventory)
                   .WithOne(item => item.Fruit)
                   .HasForeignKey<FruitEntity>(t => t.InventoryId);
        }
    }
}