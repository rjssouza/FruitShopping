using Microsoft.AspNetCore.Mvc;
using Photo.Application.Interfaces.AppServices;
using Photo.Application.ViewModels;

namespace ApiPhoto.Controllers
{
    [Route("api/picture")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureAppService _pictureAppService;

        public PictureController(IPictureAppService pictureAppService)
        {
            this._pictureAppService = pictureAppService;
        }

        [HttpGet("{picureId}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public ActionResult GetPictureUrl(string picureId)
        {
            var activePersona = this._pictureAppService.GetPictureUrl(picureId);

            return Ok(activePersona);
        }

        [HttpDelete("{pictureId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public ActionResult RemovePicture(string pictureId)
        {
            this._pictureAppService.RemovePicture(pictureId);

            return Ok(true);
        }

        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(string))]
        public ActionResult SavePicture([FromBody] PhotoViewModel photoViewModel)
        {
            var photoResult = this._pictureAppService.SavePicture(photoViewModel);

            return Ok(photoResult);
        }
    }
}