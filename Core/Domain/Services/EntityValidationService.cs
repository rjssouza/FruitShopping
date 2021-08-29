using Core.Domain.Entities;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Interfaces.Validations;

namespace Core.Domain.Services
{
    public abstract class EntityValidationService<TKey, TEntity, TEntityRepository, TEntityValidation> :
        EntityService<TKey, TEntity, TEntityRepository>
        where TEntityRepository : IEntityRepository<TKey, TEntity>
        where TEntityValidation : IEntityValidation<TEntity>
        where TEntity : Entity<TEntity>
    {
        protected readonly TEntityValidation _entityValidation;

        public EntityValidationService(TEntityValidation entityValidation, IUnitOfWork unityOfWork)
            : base(unityOfWork)
        {
            this._entityValidation = entityValidation;
        }

        public override void Delete(TEntity entity)
        {
            this._entityValidation.ValidateDelete(entity);

            base.Delete(entity);
        }

        public override void Insert(TEntity entity)
        {
            this._entityValidation.ValidateInsert(entity);

            base.Insert(entity);
        }

        public override void Update(TEntity entity)
        {
            this._entityValidation.ValidateUpdate(entity);

            base.Update(entity);
        }
    }
}