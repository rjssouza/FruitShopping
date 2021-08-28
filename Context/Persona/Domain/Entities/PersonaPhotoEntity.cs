using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persona.Domain.Entities
{
    public class PersonaPhotoEntity : Entity<PersonaPhotoEntity>
    {
        public string Extension { get; private set; }
        public int Identifier { get; private set; }
        public string Name { get; private set; }
        public virtual PersonaEntity Persona { get; private set; }
        public Guid PersonaId { get; private set; }

        public PersonaPhotoEntity()
        {
        }

        public PersonaPhotoEntity(string name, string extension, PersonaEntity persona)
            : this()
        {
            this.SetName(name);
            this.SetExtension(extension);
            this.SetPersona(persona);
        }

        public override void Configure(EntityTypeBuilder<PersonaPhotoEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("PersonaPhoto");

            builder.Property(t => t.Name).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Extension).HasMaxLength(10).IsRequired();
            builder.Property(t => t.Identifier).ValueGeneratedOnAdd()
                .Metadata
                .SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.HasOne(t => t.Persona)
                   .WithMany(item => item.PhotoEntities)
                   .HasForeignKey(item => item.PersonaId);
        }

        public void SetExtension(string extension)
        {
            this.Extension = extension;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetPersona(PersonaEntity persona)
        {
            this.Persona = persona;
            this.PersonaId = persona.Id;
        }
    }
}