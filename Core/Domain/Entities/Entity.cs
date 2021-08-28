using Core.Domain.Interfaces.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities
{
    public class Entity<TEntity> : ISpecificationObject, IEntityTypeConfiguration<TEntity>
        where TEntity : Entity<TEntity>
    {
        [NotMapped]
        public List<string> Errors { get; private set; }

        public Guid Id { get; private set; }

        public Entity()
        {
            this.Errors = new List<string>();
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(t => t.Id);
        }

        public bool IsValid()
        {
            return this.Errors.Count <= 0;
        }

        protected void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}