using AutoMapper;
using Core.Application.AppServices;
using Core.Domain.Interfaces.Repositories;
using Fruit.Application.Interfaces.AppServices;
using Fruit.Application.ViewModels;
using Fruit.Application.ViewModels.Cart;
using Fruit.Domain.Entities;
using Fruit.Domain.Entities.Cart;
using Fruit.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Fruit.Application.AppServices
{
    internal class CartAppService : AppServiceTransaction, ICartAppService
    {
        private readonly ICartService _cartService;
        private readonly IFruitService _fruitService;

        public CartAppService(IUnitOfWorkTransaction coreUnitOfWorkTransaction, IMapper mapper,
            IFruitService fruitService,
            ICartService cartService, IHttpContextAccessor httpContextAccessor)
            : base(coreUnitOfWorkTransaction, mapper, httpContextAccessor)
        {
            _fruitService = fruitService;
            _cartService = cartService;
        }

        public CartViewModel AddItemToCart(FruitTableItemViewModel fruitViewModel)
        {
            var fruit = _fruitService.GetById(fruitViewModel.Id);
            var purchasingCart = GetCartForUser() ?? new CartEntity(this.CurrentUserId);
            purchasingCart.AddItem(new CartItemEntity(fruit, purchasingCart));
            SaveCartItems(purchasingCart);
            SubtractFruitInventory(fruit);

            SaveChanges();
            var result = this._mapper.Map<CartViewModel>(purchasingCart);

            return result;
        }

        public CartViewModel GetCardViewModel()
        {
            var purchasingCart = GetCartForUser();
            var result = this._mapper.Map<CartViewModel>(purchasingCart);

            return result;
        }

        public void Purchase(Guid cartId)
        {
            var purchasingCart = GetCartForUser();
            purchasingCart.Purchased = true;
            _cartService.Update(purchasingCart);

            SaveChanges();
        }

        public void RemoveItemFromCard(Guid fruitId)
        {
            var fruit = _fruitService.GetById(fruitId);
            var purchasingCart = GetCartForUser();
            var quantity = purchasingCart.Items.Where(t => t.FruitId == fruitId).Count();
            purchasingCart.Items.RemoveAll(t => t.FruitId == fruitId);
            if (purchasingCart.Items.Count == 0)
            {
                _cartService.Delete(purchasingCart);
                AddFruitInventory(fruit, quantity);
            }
            else
            {
                _cartService.Update(purchasingCart);
                AddFruitInventory(fruit);
            }

            SaveChanges();
        }

        private CartEntity GetCartForUser()
        {
            var purchasingCart = _cartService.GetAll(t => t.Purchased == false && t.UserId == CurrentUserId)
                                             .FirstOrDefault();

            return purchasingCart;
        }

        private void SaveCartItems(CartEntity purchasingCart)
        {
            if (purchasingCart.Id == Guid.Empty)
                _cartService.Insert(purchasingCart);
            else
                _cartService.Update(purchasingCart);
        }

        private void SubtractFruitInventory(FruitEntity fruit)
        {
            fruit.Inventory.Quantity--;
            if (fruit.Inventory.Quantity == 0)
                _fruitService.Delete(fruit);

            _fruitService.Update(fruit);
        }

        private void AddFruitInventory(FruitEntity fruit, int quantity = 0)
        {
            if (quantity <= 0)
                fruit.Inventory.Quantity++;
            else
                fruit.Inventory.Quantity += quantity;

            _fruitService.Update(fruit);
        }

    }
}