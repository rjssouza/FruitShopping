using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Fruit.Domain.Entities
{
    internal class FruitInventoryEntity : Entity<FruitInventoryEntity>
    {
        public virtual FruitEntity Fruit { get; private set; }
        public Guid? FruitId { get; set; }
        public int Quantity { get; set; }

        public override void Configure(EntityTypeBuilder<FruitInventoryEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("FruitInventory");

            builder.Property(t => t.Quantity).IsRequired();
            builder.HasOne(t => t.Fruit)
                   .WithOne(item => item.Inventory)
                   .HasForeignKey<FruitEntity>(t => t.InventoryId);
        }
    }
}