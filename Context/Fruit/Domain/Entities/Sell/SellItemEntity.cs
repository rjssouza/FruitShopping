using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Fruit.Domain.Entities.Sell
{
    internal class SellItemEntity : Entity<SellItemEntity>
    {
        public virtual FruitEntity Fruit { get; private set; }
        public Guid FruitId { get; private set; }
        public int Quantity { get; private set; }
        public virtual SellEntity Sell { get; private set; }
        public Guid SellId { get; private set; }

        public override void Configure(EntityTypeBuilder<SellItemEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("SellItem");
            builder.Property(t => t.Quantity).IsRequired();
            builder.HasOne(t => t.Sell)
                   .WithMany(item => item.SellItems)
                   .HasForeignKey(item => item.SellId);
            builder.HasOne(t => t.Fruit)
                   .WithMany(item => item.SellItems)
                   .HasForeignKey(t => t.SellId);
        }
    }
}