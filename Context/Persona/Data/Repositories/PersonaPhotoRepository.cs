using Core.Data.Repositories;
using Persona.Data.Context;
using Persona.Domain.Entities;
using Persona.Domain.Interfaces.Repositories;
using System;

namespace Persona.Data.Repositories
{
    internal class PersonaPhotoRepository : EntityRepository<Guid, PersonaPhotoEntity, PersonaDbContext>, IPersonaPhotoRepository
    {
        public PersonaPhotoRepository(PersonaDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}