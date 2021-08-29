using Fruit.Application.Interfaces.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPhoto.Controllers
{
    [Authorize]
    [Route("api/fruit")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        private readonly IFruitAppService _fruitAppService;

        public FruitController(IFruitAppService pictureAppService)
        {
            _fruitAppService = pictureAppService;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(string))]
        public ActionResult GetPictureUrl()
        {
            return Ok();
        }
    }
}