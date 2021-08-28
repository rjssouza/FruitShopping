using Core.Domain.Validations;
using Photo.Domain.Interfaces.Validations;
using System;

namespace Photo.Domain.Validations
{
    internal class PictureValidation : Validation, IPictureValidation
    {
        public void PictureMustBeValid(byte[] picture)
        {
        }
    }
}