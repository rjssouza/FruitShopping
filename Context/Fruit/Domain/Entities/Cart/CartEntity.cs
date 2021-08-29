using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Fruit.Domain.Entities.Cart
{
    internal class CartEntity : Entity<CartEntity>
    {
        public CartEntity()
        {
        }

        public CartEntity(string userId, params CartItemEntity[] items)
        {
            UserId = userId;
            Date = DateTime.Now;
            Items = items.ToList();
        }

        public DateTime Date { get; private set; }

        public virtual List<CartItemEntity> Items { get; private set; }

        public bool Purchased { get; set; }

        public decimal Total { get; private set; }

        public string UserId { get; private set; }

        public void AddItem(CartItemEntity item)
        {
            this.Items.Add(item);
            this.Total += item.Fruit.Price;
        }

        public override void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Cart");

            builder.Property(t => t.Total).IsRequired();
            builder.Property(t => t.Date).IsRequired();
            builder.Property(t => t.UserId).IsRequired();
        }
    }
}