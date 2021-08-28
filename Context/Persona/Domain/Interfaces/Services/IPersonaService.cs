using Core.Domain.Interfaces.Services;
using Persona.Domain.Entities;
using System;

namespace Persona.Domain.Interfaces.Services
{
    public interface IPersonaService : IEntityService<Guid, PersonaEntity>
    {
        PersonaEntity GetActive();
    }
}