using Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Core.Domain.Interfaces.Repositories
{
    public interface IEntityRepository<Tkey, TEntity> : IDisposable
        where TEntity : Entity<TEntity>
    {
        void Delete(TEntity goal);

        IEnumerable<TEntity> GetAll(Func<TEntity, bool> selector = null);

        TEntity GetById(Tkey id);

        void Insert(TEntity goal);

        void Update(TEntity goal);
    }
}