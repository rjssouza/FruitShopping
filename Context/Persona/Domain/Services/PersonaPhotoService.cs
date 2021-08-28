using Core.Domain.Interfaces.Repositories;
using Core.Domain.Services;
using Persona.Domain.Entities;
using Persona.Domain.Interfaces.Infrastructure;
using Persona.Domain.Interfaces.Repositories;
using Persona.Domain.Interfaces.Services;
using System;

namespace Persona.Domain.Services
{
    internal class PersonaPhotoService : EntityService<Guid, PersonaPhotoEntity, IPersonaPhotoRepository, IPersonaUnitOfWork>, IPersonaPhotoService
    {
        public PersonaPhotoService(IPersonaUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}