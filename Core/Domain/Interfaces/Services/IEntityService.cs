using Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Core.Domain.Interfaces.Services
{
    public interface IEntityService<TKey, TEntity> : IDisposable
        where TEntity : Entity<TEntity>
    {
        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate = null);

        TEntity GetById(TKey key);

        void Insert(TEntity entity);

        void Update(TEntity entity);
    }
}