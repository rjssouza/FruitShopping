using Core.Domain.Interfaces.Validations;
using Fruit.Domain.Entities.Sell;

namespace Fruit.Domain.Interfaces.Validations
{
    internal interface ICartValidation : IEntityValidation<CartEntity>
    {
    }
}