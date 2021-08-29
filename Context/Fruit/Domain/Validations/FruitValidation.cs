using Core.Domain.Interfaces.Repositories;
using Core.Domain.Validations;
using Fruit.Domain.Entities;
using Fruit.Domain.Interfaces.Validations;

namespace Fruit.Domain.Validations
{
    internal class FruitValidation : EntityValidation<FruitEntity>, IFruitValidation
    {
        private readonly IFruitInventoryValidation _fruitInventoryValidation;

        public FruitValidation(IUnitOfWork unitOfWork, IFruitInventoryValidation fruitInventoryValidation) : base(unitOfWork)
        {
            _fruitInventoryValidation = fruitInventoryValidation;
        }

        public override void ValidateInsert(FruitEntity entity)
        {
            base.ValidateInsert(entity);
            Name_NameIsRequired(entity);
            Description_DescriptionIsRequired(entity);
            Inventoy_InventoryIsRequired(entity);
            Price_PriceMustBeSuperiorThanZero(entity);
            Inventory_ValidateInsert(entity);

            Validate();
        }

        public override void ValidateUpdate(FruitEntity entity)
        {
            base.ValidateInsert(entity);
            Name_NameIsRequired(entity);
            Description_DescriptionIsRequired(entity);
            Price_PriceMustBeSuperiorThanZero(entity);

            Validate();
        }

        private void Description_DescriptionIsRequired(FruitEntity fruitEntity)
        {
            var message = "";

            if (string.IsNullOrEmpty(fruitEntity.Description))
                AddError(message);
        }

        private void Inventory_ValidateInsert(FruitEntity fruitEntity)
        {
            _fruitInventoryValidation.ValidateInsert(fruitEntity.Inventory);
        }

        private void Inventoy_InventoryIsRequired(FruitEntity fruitEntity)
        {
            var message = "";
            if (fruitEntity.Inventory == null)
                AddError(message);
        }

        private void Name_NameIsRequired(FruitEntity fruitEntity)
        {
            var message = "";

            if (string.IsNullOrEmpty(fruitEntity.Name))
                AddError(message);
        }

        private void Price_PriceMustBeSuperiorThanZero(FruitEntity fruitEntity)
        {
            var message = "";
            if (fruitEntity.Price <= 0)
                AddError(message);
        }
    }
}