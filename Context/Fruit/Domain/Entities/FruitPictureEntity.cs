using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Fruit.Domain.Entities
{
    internal class FruitPictureEntity : Entity<FruitPictureEntity>
    {
        public byte[] Content { get; set; }
        public virtual FruitEntity Fruit { get; private set; }
        public Guid FruitId { get; set; }
        public string Name { get; set; }

        public override void Configure(EntityTypeBuilder<FruitPictureEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("FruitPicture");

            builder.Property(t => t.Name).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Content).IsRequired();
            builder.HasOne(t => t.Fruit)
                   .WithMany(item => item.Pictures)
                   .HasForeignKey(item => item.FruitId);
        }
    }
}