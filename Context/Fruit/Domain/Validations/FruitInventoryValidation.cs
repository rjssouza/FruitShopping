using Core.Domain.Interfaces.Repositories;
using Core.Domain.Validations;
using Fruit.Domain.Entities;
using Fruit.Domain.Interfaces.Validations;

namespace Fruit.Domain.Validations
{
    internal class FruitInventoryValidation : EntityValidation<FruitInventoryEntity>, IFruitInventoryValidation
    {
        public FruitInventoryValidation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override void ValidateInsert(FruitInventoryEntity entity)
        {
            base.ValidateInsert(entity);
            this.Quantity_QuantityMustBeSuperiorThanZero(entity);

            this.Validate();
        }

        private void Quantity_QuantityMustBeSuperiorThanZero(FruitInventoryEntity entity)
        {
            var message = "Quantidade do inventorio deve ser maior que zero";
            if (entity.Quantity <= 0)
                this.AddError(message);
        }
    }
}