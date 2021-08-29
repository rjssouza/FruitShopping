using Fruit.Application.ViewModels;
using System;

namespace Fruit.Application.Interfaces.AppServices
{
    public interface IFruitAppService : IDisposable
    {
        FruitListViewModel GetListViewModel();

        void Register(FruitViewModel fruitViewModel);
    }
}