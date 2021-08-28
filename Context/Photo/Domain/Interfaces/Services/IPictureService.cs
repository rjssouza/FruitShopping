namespace Photo.Domain.Interfaces.Services
{
    public interface IPictureService
    {
        string GetPictureUrl(string picureId);

        void RemovePicture(string pictureId);

        string SavePicture(byte[] picture);
    }
}