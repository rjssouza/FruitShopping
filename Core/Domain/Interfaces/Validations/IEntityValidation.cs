using Core.Domain.Entities;
using System;

namespace Core.Domain.Interfaces.Validations
{
    public interface IEntityValidation<TEntity> : IDisposable
        where TEntity : Entity<TEntity>
    {
         void ValidateInsert(TEntity entity);

         void ValidateUpdate(TEntity entity);

         void ValidateDelete(TEntity entity);
    }
}