using AutoMapper;
using Core.Application.AppServices;
using Core.Domain.Interfaces.Repositories;
using Fruit.Application.Interfaces.AppServices;
using Fruit.Application.ViewModels;
using Fruit.Application.ViewModels.Cart;
using Fruit.Domain.Interfaces.Services;
using System;

namespace Fruit.Application.AppServices
{
    internal class CartAppService : AppServiceTransaction, ICartAppService
    {
        private readonly ICartService _cartService;
        private readonly IFruitService _fruitService;

        public CartAppService(IUnitOfWorkTransaction coreUnitOfWorkTransaction, IMapper mapper,
            IFruitService fruitService,
            ICartService cartService)
            : base(coreUnitOfWorkTransaction, mapper)
        {
            _fruitService = fruitService;
            _cartService = cartService;
        }

        public CartViewModel AddItemToCart(FruitViewModel fruitViewModel)
        {
            throw new NotImplementedException();
        }

        public CartViewModel GetCardViewModel()
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