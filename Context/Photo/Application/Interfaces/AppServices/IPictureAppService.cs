using Photo.Application.ViewModels;

namespace Photo.Application.Interfaces.AppServices
{
    public interface IPictureAppService
    {
        string GetPictureUrl(string picureId);

        void RemovePicture(string pictureId);

        string SavePicture(PhotoViewModel picture);
    }
}