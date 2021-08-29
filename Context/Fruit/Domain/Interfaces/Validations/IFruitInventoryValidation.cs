using Core.Domain.Interfaces.Validations;
using Fruit.Domain.Entities;

namespace Fruit.Domain.Interfaces.Validations
{
    internal interface IFruitInventoryValidation : IEntityValidation<FruitInventoryEntity>
    {
    }
}