using Persona.Application.ViewModels;
using System;

namespace Persona.Application.Interfaces.AppServices
{
    public interface IPersonaAppService : IDisposable
    {
        void DeletePersona(Guid id);

        PersonaViewModel GetActive();

        PersonaViewModel GetById(Guid id);

        Guid SavePersona(PersonaViewModel persona);

        void SetPersonaActive(Guid id);

        void UpdatePersona(PersonaViewModel persona);

        string GetActiveName();

        string GetActivePhoto();
    }
}