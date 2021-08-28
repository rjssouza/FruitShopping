using Core.Domain.Interfaces.Repositories;
using Persona.Domain.Entities;
using System;

namespace Persona.Domain.Interfaces.Repositories
{
    public interface IPersonaRepository : IEntityRepository<Guid, PersonaEntity>
    {
        PersonaEntity GetActive();

        PersonaEntity GetByIdentifier(int identifier);
    }
}