using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Persona.Domain.Entities
{
    public class PersonaEntity : Entity<PersonaEntity>
    {
        public bool Active { get; private set; }

        [ExcludeFromCodeCoverage]
        public int Identifier { get; private set; }

        public string Name { get; private set; }
        public virtual List<PersonaPhotoEntity> PhotoEntities { get; private set; }

        public PersonaEntity()
        {
            this.PhotoEntities = new List<PersonaPhotoEntity>();
        }

        public PersonaEntity(string name, PersonaPhotoEntity personaPhotoEntity)
            : this()
        {
            this.SetName(name);
            this.AddPhoto(personaPhotoEntity);
        }

        public void AddPhoto(PersonaPhotoEntity personaPhotoEntity)
        {
            this.PhotoEntities.Add(personaPhotoEntity);
        }

        public override void Configure(EntityTypeBuilder<PersonaEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Persona");

            builder.Property(t => t.Name).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Identifier).ValueGeneratedOnAdd()
                .Metadata
                .SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(t => t.Active).IsRequired();
            builder.HasMany(t => t.PhotoEntities)
                   .WithOne(item => item.Persona)
                   .HasForeignKey(item => item.PersonaId);


        }

        public void SetActive(bool active)
        {
            this.Active = active;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
    }
}