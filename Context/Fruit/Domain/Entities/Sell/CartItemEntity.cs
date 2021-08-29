using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Fruit.Domain.Entities.Sell
{
    internal class CartItemEntity : Entity<CartItemEntity>
    {
        public virtual FruitEntity Fruit { get; private set; }
        public Guid FruitId { get; private set; }
        public int Quantity { get; private set; }
        public virtual CartEntity Cart { get; private set; }
        public Guid CartId { get; private set; }

        public override void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("CartItem");
            builder.Property(t => t.Quantity).IsRequired();
            builder.HasOne(t => t.Cart)
                   .WithMany(item => item.Items)
                   .HasForeignKey(item => item.CartId);
            builder.HasOne(t => t.Fruit)
                   .WithMany(item => item.SellItems)
                   .HasForeignKey(t => t.CartId);
        }
    }
}