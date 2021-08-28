using Core.AntiCorruption;
using Persona.Application.ViewModels;
using Persona.Domain.Interfaces.Infrastructure;
using System.Net.Http;

namespace Persona.AntiCorruption
{
    internal class PictureService : ApiAntiCorruption, IPictureInfraService
    {
        protected override string BaseUrl => "https://localhost:44308/";

        public PictureService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public string GetPictureUrl(string pictureId)
        {
            var pictureUrl = this.Get($"api/picture/{pictureId}");

            return pictureUrl;
        }

        public void RemovePicture(string pictureId)
        {
            this.Delete<string>("api/picture", pictureId);
        }

        public string SavePicture(PhotoViewModel picture)
        {
            var pictureName = this.PostString<PhotoViewModel>("api/picture", picture);

            return pictureName;
        }
    }
}