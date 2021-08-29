using Core.Data.Context;
using Core.Domain.Entities;
using Core.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Data.Repositories
{
    public abstract class EntityRepository<Tkey, TEntity, DbContext> : IEntityRepository<Tkey, TEntity>
        where TEntity : Entity<TEntity>
        where DbContext : CoreDbContext
    {
        protected DbContext _dbContext;
        private bool disposedValue;

        public EntityRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual void Delete(TEntity entity)
        {
            this._dbContext.Remove<TEntity>(entity);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> GetAll(Func<TEntity, bool> selector = null)
        {
            var result = selector == null ? this._dbContext.Set<TEntity>() : this._dbContext.Set<TEntity>().Where(selector);

            return result;
        }

        public virtual TEntity GetById(Tkey id)
        {
            return this._dbContext.Find<TEntity>(id);
        }

        public virtual void Insert(TEntity entity)
        {
            this._dbContext.Add<TEntity>(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this._dbContext.Update<TEntity>(entity);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._dbContext.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}