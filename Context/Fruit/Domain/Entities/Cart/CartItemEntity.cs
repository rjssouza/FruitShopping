using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Fruit.Domain.Entities.Cart
{
    internal class CartItemEntity : Entity<CartItemEntity>
    {
        public CartItemEntity()
        {
        }

        public CartItemEntity(FruitEntity fruit, CartEntity cart)
        {
            FruitId = fruit.Id;
            Fruit = fruit;
            Quantity = 1;
            Cart = cart;
            CartId = cart.Id;
        }

        public virtual CartEntity Cart { get; private set; }
        public Guid CartId { get; private set; }
        public virtual FruitEntity Fruit { get; private set; }
        public Guid FruitId { get; private set; }
        public int Quantity { get; private set; }

        public override void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("CartItem");
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.CartId).IsRequired();

            builder.HasOne(t => t.Fruit)
                   .WithMany(item => item.Items)
                   .HasForeignKey(t => t.FruitId)
                   .IsRequired();

            builder.HasOne(t => t.Cart)
                   .WithMany(item => item.Items)
                   .HasForeignKey(item => item.CartId)
                   .IsRequired();
        }
    }
}