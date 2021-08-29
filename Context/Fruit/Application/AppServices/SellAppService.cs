using AutoMapper;
using Core.Application.AppServices;
using Core.Domain.Interfaces.Repositories;
using Fruit.Application.Interfaces.AppServices;
using Fruit.Application.ViewModels;
using System;

namespace Fruit.Application.AppServices
{
    public class SellAppService : AppServiceTransaction, ISellAppService
    {
        public SellAppService(IUnitOfWorkTransaction coreUnitOfWorkTransaction, IMapper mapper)
            : base(coreUnitOfWorkTransaction, mapper)
        {
        }

        public void AddItemToCart(FruitViewModel fruitViewModel)
        {
            throw new NotImplementedException();
        }

        public void RemoveItemFromCard(Guid fruitId)
        {
            throw new NotImplementedException();
        }

        public void Sell(Guid sellId)
        {
            throw new NotImplementedException();
        }
    }
}