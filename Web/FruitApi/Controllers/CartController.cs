using Fruit.Application.Interfaces.AppServices;
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

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(string))]
        public ActionResult Get()
        {
            return Ok("Ok autenticado");
        }
    }
}