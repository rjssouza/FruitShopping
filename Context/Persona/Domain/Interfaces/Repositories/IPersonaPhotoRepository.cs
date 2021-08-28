using Core.Domain.Interfaces.Repositories;
using Persona.Domain.Entities;
using System;

namespace Persona.Domain.Interfaces.Repositories
{
    public interface IPersonaPhotoRepository : IEntityRepository<Guid, PersonaPhotoEntity>
    {
    }
}