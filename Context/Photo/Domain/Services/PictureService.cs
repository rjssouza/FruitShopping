using Azure.Storage.Blobs;
using Core.Constants;
using Core.Domain.Services;
using Core.Utils.Extension;
using Microsoft.Extensions.Configuration;
using Photo.Domain.Interfaces.Services;
using Photo.Domain.Interfaces.Validations;
using System;
using System.IO;

namespace Photo.Domain.Services
{
    internal class PictureService : Service, IPictureService
    {
        private const string CONTAINER_NAME = "picture";
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IPictureValidation _pictureValidation;

        public PictureService(IConfiguration configuration, IPictureValidation pictureValidation)
        {
            this._pictureValidation = pictureValidation;
            var connectionString = configuration[ConfigKeyConstants.CONTAINER_CONNECTION];
            this._blobServiceClient = new BlobServiceClient(connectionString);
        }

        public string GetPictureUrl(string picureId)
        {
            var containerClient = this._blobServiceClient.GetBlobContainerClient(CONTAINER_NAME);

            return $"{containerClient.Uri}/{picureId}";
        }

        public void RemovePicture(string pictureId)
        {
            var containerClient = this._blobServiceClient.GetBlobContainerClient(CONTAINER_NAME);

            containerClient.DeleteBlob(pictureId);
        }

        public string SavePicture(byte[] picture)
        {
            this._pictureValidation.PictureMustBeValid(picture);
            var pictureName = this.SavePictureOnAzure(picture);

            return pictureName;
        }

        private string SavePictureOnAzure(byte[] picture)
        {
            using var memStream = new MemoryStream(picture);
            var containerClient = this._blobServiceClient.GetBlobContainerClient(CONTAINER_NAME);
            var name = $"{Guid.NewGuid()}.{picture.ObterExtensao()}";
            containerClient.UploadBlob(name, memStream);

            return name;
        }
    }
}