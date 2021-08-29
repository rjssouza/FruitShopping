using Core.Domain.Interfaces.Repositories;
using Core.Domain.Validations;
using Fruit.Domain.Entities.Sell;
using Fruit.Domain.Interfaces.Validations;

namespace Fruit.Domain.Validations
{
    internal class SellValidation : EntityValidation<SellEntity>, ISellValidation
    {
        public SellValidation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override void ValidateInsert(SellEntity entity)
        {
            base.ValidateInsert(entity);
            Items_ItemsMustBeInformed(entity);
            Total_TotalMustBeSuperiorThanZero(entity);
            UserId_UserIsRequired(entity);

            this.Validate();
        }

        public override void ValidateUpdate(SellEntity entity)
        {
            base.ValidateUpdate(entity);
            Items_ItemsMustBeInformed(entity);
            Total_TotalMustBeSuperiorThanZero(entity);
            UserId_UserIsRequired(entity);

            this.Validate();
        }

        private void Items_ItemsMustBeInformed(SellEntity entity)
        {
            var message = "";

            if (entity.SellItems.Count <= 0)
                this.AddError(message);
        }

        private void Total_TotalMustBeSuperiorThanZero(SellEntity entity)
        {
            var message = "";

            if (entity.Total <= 0)
                this.AddError(message);
        }

        private void UserId_UserIsRequired(SellEntity entity)
        {
            var message = "";

            if (string.IsNullOrEmpty(entity.UserId))
                this.AddError(message);
        }
    }
}