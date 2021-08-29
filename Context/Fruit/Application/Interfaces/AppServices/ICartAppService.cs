using Fruit.Application.ViewModels;
using Fruit.Application.ViewModels.Cart;
using System;

namespace Fruit.Application.Interfaces.AppServices
{
    public interface ICartAppService : IDisposable
    {
        CartViewModel GetCardViewModel();

        CartViewModel AddItemToCart(FruitTableItemViewModel fruitViewModel);

        void Purchase(Guid sellId);

        void RemoveItemFromCard(Guid fruitId);
    }
}