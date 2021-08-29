using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Fruit.Domain.Entities.Sell
{
    internal class SellEntity : Entity<SellEntity>
    {
        public DateTime Date { get; private set; }
        public virtual List<SellItemEntity> SellItems { get; private set; }
        public decimal Total { get; private set; }
        public string UserId { get; private set; }

        public override void Configure(EntityTypeBuilder<SellEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Sell");

            builder.Property(t => t.Total).IsRequired();
            builder.Property(t => t.Date).IsRequired();
            builder.Property(t => t.UserId).IsRequired();

            builder.HasMany(t => t.SellItems)
                   .WithOne(t => t.Sell)
                   .HasForeignKey(t => t.SellId);
        }
    }
}