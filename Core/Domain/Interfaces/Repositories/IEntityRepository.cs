using Core.Domain.Entities;
using System;

namespace Core.Domain.Interfaces.Repositories
{
    public interface IEntityRepository<Tkey, TEntity> : IDisposable
        where TEntity : Entity<TEntity>
    {
        TEntity GetById(Tkey id);

         void Insert(TEntity goal);

         void Update(TEntity goal);

         void Delete(TEntity goal);
    }
}