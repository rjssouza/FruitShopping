using Core.Domain.Entities;
using System;

namespace Core.Domain.Interfaces.Services
{
    public interface IEntityService<TKey, TEntity> : IDisposable
        where TEntity : Entity<TEntity>
    {
         TEntity GetById(TKey key);

         void Insert(TEntity entity);

         void Update(TEntity entity);

         void Delete(TEntity entity);
    }
}