using Fruit.Application.Interfaces.AppServices;
using Fruit.Application.ViewModels;
using Fruit.Application.ViewModels.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiPhoto.Controllers
{
    [Authorize]
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartAppService _cartAppService;

        public CartController(ICartAppService cartAppService)
        {
            _cartAppService = cartAppService;
        }

        [HttpDelete("{fruitId}")]
        [ProducesResponseType(200, Type = typeof(FruitViewModel))]
        public ActionResult Delete(Guid fruitId)
        {
            _cartAppService.RemoveItemFromCard(fruitId);

            return Ok();
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(CartViewModel))]
        public ActionResult Get()
        {
            var vm = _cartAppService.GetCardViewModel();

            return Ok(vm);
        }


        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(CartViewModel))]
        public ActionResult Post(FruitTableItemViewModel fruitViewModel)
        {
            var vm = _cartAppService.AddItemToCart(fruitViewModel);

            return Ok(vm);
        }

        [HttpPut("{cartId}")]
        [ProducesResponseType(200)]
        public ActionResult Put(Guid cartId)
        {
            _cartAppService.Purchase(cartId);

            return Ok();
        }
    }
}