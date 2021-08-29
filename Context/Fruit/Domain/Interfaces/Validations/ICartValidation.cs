using Core.Domain.Interfaces.Validations;
using Fruit.Domain.Entities.Cart;

namespace Fruit.Domain.Interfaces.Validations
{
    internal interface ICartValidation : IEntityValidation<CartEntity>
    {
    }
}