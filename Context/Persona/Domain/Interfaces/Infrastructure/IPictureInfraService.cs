using Core.Domain.Interfaces.Infrastructure;
using Persona.Application.ViewModels;

namespace Persona.Domain.Interfaces.Infrastructure
{
    public interface IPictureInfraService : IAntiCorruption
    {
        string GetPictureUrl(string pictureId);

        void RemovePicture(string pictureId);

        string SavePicture(PhotoViewModel picture);
    }
}