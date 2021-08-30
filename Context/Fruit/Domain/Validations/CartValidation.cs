using Core.Domain.Interfaces.Repositories;
using Core.Domain.Validations;
using Fruit.Domain.Entities.Cart;
using Fruit.Domain.Interfaces.Validations;

namespace Fruit.Domain.Validations
{
    internal class CartValidation : EntityValidation<CartEntity>, ICartValidation
    {
        public CartValidation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override void ValidateInsert(CartEntity entity)
        {
            base.ValidateInsert(entity);
            Items_ItemsMustBeInformed(entity);
            Total_TotalMustBeSuperiorThanZero(entity);
            UserId_UserIsRequired(entity);

            this.Validate();
        }

        public override void ValidateUpdate(CartEntity entity)
        {
            base.ValidateUpdate(entity);
            Items_ItemsMustBeInformed(entity);
            Total_TotalMustBeSuperiorThanZero(entity);
            UserId_UserIsRequired(entity);

            this.Validate();
        }

        private void Items_ItemsMustBeInformed(CartEntity entity)
        {
            var message = "Itens de compra devem ser informados";

            if (entity.Items.Count <= 0)
                this.AddError(message);
        }

        private void Total_TotalMustBeSuperiorThanZero(CartEntity entity)
        {
            var message = "Total deve ser maior que zero";

            if (entity.Total <= 0)
                this.AddError(message);
        }

        private void UserId_UserIsRequired(CartEntity entity)
        {
            var message = "Identificador do usuário deve ser informado";

            if (string.IsNullOrEmpty(entity.UserId))
                this.AddError(message);
        }
    }
}