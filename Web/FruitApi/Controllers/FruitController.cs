using Fruit.Application.Interfaces.AppServices;
using Fruit.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiPhoto.Controllers
{
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
        [ProducesResponseType(200, Type = typeof(FruitListViewModel))]
        public ActionResult Get()
        {
            var fruitListViewModel = _fruitAppService.GetListViewModel();

            return Ok(fruitListViewModel);
        }
    }
}