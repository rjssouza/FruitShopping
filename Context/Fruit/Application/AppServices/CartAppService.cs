using AutoMapper;
using Core.Application.AppServices;
using Core.Domain.Interfaces.Repositories;
using Fruit.Application.Interfaces.AppServices;
using Fruit.Application.ViewModels;
using Fruit.Application.ViewModels.Cart;
using System;

namespace Fruit.Application.AppServices
{
    public class CartAppService : AppServiceTransaction, ICartAppService
    {
        public CartAppService(IUnitOfWorkTransaction coreUnitOfWorkTransaction, IMapper mapper)
            : base(coreUnitOfWorkTransaction, mapper)
        {
        }

        public CartViewModel AddItemToCart(FruitViewModel fruitViewModel)
        {
            throw new NotImplementedException();
        }

        public void Purchase(Guid cartId)
        {
            throw new NotImplementedException();
        }

        public void RemoveItemFromCard(Guid fruitId)
        {
            throw new NotImplementedException();
        }
    }
}