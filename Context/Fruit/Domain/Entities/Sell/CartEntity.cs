using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Fruit.Domain.Entities.Sell
{
    internal class CartEntity : Entity<CartEntity>
    {
        public DateTime Date { get; private set; }
        public virtual List<CartItemEntity> Items { get; private set; }
        public decimal Total { get; private set; }
        public string UserId { get; private set; }

        public override void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Cart");

            builder.Property(t => t.Total).IsRequired();
            builder.Property(t => t.Date).IsRequired();
            builder.Property(t => t.UserId).IsRequired();

            builder.HasMany(t => t.Items)
                   .WithOne(t => t.Cart)
                   .HasForeignKey(t => t.CartId);
        }
    }
}