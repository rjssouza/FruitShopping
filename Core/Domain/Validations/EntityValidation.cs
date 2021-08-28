using Core.Domain.Entities;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Interfaces.Validations;

namespace Core.Domain.Validations
{
    public abstract class EntityValidation<TEntity, TUnitOfWork> : UnitValidation<TUnitOfWork>, IEntityValidation<TEntity>
        where TUnitOfWork : IUnitOfWork
        where TEntity : Entity<TEntity>
    {
        public EntityValidation(TUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public virtual void ValidateDelete(TEntity entity)
        {
            if (!entity.IsValid())
                this.AddErrors(entity.Errors);

            this.Validate();
        }

        public virtual void ValidateInsert(TEntity entity)
        {
            if (!entity.IsValid())
                this.AddErrors(entity.Errors);

            this.Validate();
        }

        public virtual void ValidateUpdate(TEntity entity)
        {
            if (!entity.IsValid())
                this.AddErrors(entity.Errors);

            this.Validate();
        }
    }
}