using Fruit.Application.Interfaces.AppServices;
using Fruit.Application.ViewModels;
using Fruit.Application.ViewModels.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(CartViewModel))]
        public ActionResult Get()
        {
            var vm = _cartAppService.GetCardViewModel();

            return Ok(vm);
        }

        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(FruitViewModel))]
        public ActionResult Post(FruitViewModel fruitViewModel)
        {
            var vm = _cartAppService.AddItemToCart(fruitViewModel);

            return Ok(vm);
        }
    }
}