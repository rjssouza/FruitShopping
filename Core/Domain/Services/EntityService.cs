using Core.Domain.Entities;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Interfaces.Services;

namespace Core.Domain.Services
{
    public abstract class EntityService<TKey, TEntity, TIEntityRepository, TUnitOfWork> : UnitService<TUnitOfWork>, IEntityService<TKey, TEntity>
        where TIEntityRepository : IEntityRepository<TKey, TEntity>
        where TUnitOfWork : IUnitOfWork
        where TEntity : Entity<TEntity>
    {
        public EntityService(TUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public virtual void Delete(TEntity entity)
        {
            var entityRepository = this._unitOfWork.GetRepository<TIEntityRepository>();

            entityRepository.Delete(entity);
        }

        public TEntity GetById(TKey key)
        {
            var entityRepository = this._unitOfWork.GetRepository<TIEntityRepository>();
            var result = entityRepository.GetById(key);

            return result;
        }

        public virtual void Insert(TEntity entity)
        {
            var entityRepository = this._unitOfWork.GetRepository<TIEntityRepository>();

            entityRepository.Insert(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entityRepository = this._unitOfWork.GetRepository<TIEntityRepository>();

            entityRepository.Update(entity);
        }
    }
}