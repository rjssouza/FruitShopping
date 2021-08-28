using AutoMapper;
using Core.Application.AppServices;
using Photo.Application.Interfaces.AppServices;
using Photo.Application.ViewModels;
using Photo.Domain.Interfaces.Services;

namespace Photo.Application.AppServices
{
    internal class PictureAppService : AppServiceBase, IPictureAppService
    {
        private readonly IPictureService _pictureService;

        public PictureAppService(IMapper mapper, IPictureService pictureService)
            : base(mapper)
        {
            this._pictureService = pictureService;
        }

        public string GetPictureUrl(string picureId)
        {
            var result = this._pictureService.GetPictureUrl(picureId);

            return result;
        }

        public void RemovePicture(string pictureId)
        {
            this._pictureService.RemovePicture(pictureId);
        }

        public string SavePicture(PhotoViewModel picture)
        {
            var pictureName = this._pictureService.SavePicture(picture.Content);

            return pictureName;
        }
    }
}