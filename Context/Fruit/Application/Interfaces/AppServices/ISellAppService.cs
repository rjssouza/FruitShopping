using Fruit.Application.ViewModels;
using Fruit.Application.ViewModels.Sell;
using System;

namespace Fruit.Application.Interfaces.AppServices
{
    public interface ISellAppService : IDisposable
    {
        void AddItemToCart(FruitViewModel fruitViewModel);

        void RemoveItemFromCard(Guid fruitId);

        void Sell(Guid sellId);
    }
}