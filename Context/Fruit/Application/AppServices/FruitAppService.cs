using AutoMapper;
using Core.Application.AppServices;
using Core.Domain.Interfaces.Repositories;
using Fruit.Application.Interfaces.AppServices;
using Fruit.Application.ViewModels;
using Fruit.Domain.Interfaces.Services;

namespace Fruit.Application.AppServices
{
    internal class FruitAppService : AppServiceTransaction, IFruitAppService
    {
        private readonly IFruitService _fruitService;

        public FruitAppService(IUnitOfWorkTransaction coreUnitOfWorkTransaction, IMapper mapper, IFruitService fruitService)
            : base(coreUnitOfWorkTransaction, mapper)
        {
            _fruitService = fruitService;
        }

        public FruitListViewModel GetListViewModel()
        {
            throw new System.NotImplementedException();
        }

        public void Register(FruitViewModel fruitViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}