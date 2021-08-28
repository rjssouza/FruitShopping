using Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Persona.Data.Context;
using Persona.Domain.Entities;
using Persona.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace Persona.Data.Repositories
{
    internal class PersonaRepository : EntityRepository<Guid, PersonaEntity, PersonaDbContext>, IPersonaRepository
    {
        public PersonaRepository(PersonaDbContext dbContext)
            : base(dbContext)
        {
        }

        public PersonaEntity GetActive()
        {
            var persona = this._dbContext.Persona
                    .Where(t => t.Active)
                    .FirstOrDefault();

            return persona;
        }

        public PersonaEntity GetByIdentifier(int identifier)
        {
            var persona = this._dbContext.Persona
                .Where(t => t.Identifier == identifier)
                .FirstOrDefault();

            return persona;
        }
    }
}