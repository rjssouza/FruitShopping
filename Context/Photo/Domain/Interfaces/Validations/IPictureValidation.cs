namespace Photo.Domain.Interfaces.Validations
{
    public interface IPictureValidation
    {
        void PictureMustBeValid(byte[] picture);
    }
}