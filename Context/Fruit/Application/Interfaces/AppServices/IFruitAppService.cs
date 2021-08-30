using Fruit.Application.ViewModels;
using System;

namespace Fruit.Application.Interfaces.AppServices
{
    public interface IFruitAppService : IDisposable
    {
        FruitTableItemViewModel GetById(Guid id);

        FruitListViewModel GetListViewModel();

        void Register(FruitViewModel fruitViewModel);
    }
}