using Core.Data.Repositories;
using Persona.Data.Context;
using Persona.Domain.Interfaces.Infrastructure;
using System;

namespace Persona.Data.Repositories
{
    internal class PersonaUnitOfWork : UnitOfWork<PersonaDbContext>, IPersonaUnitOfWork
    {
        public PersonaUnitOfWork(PersonaDbContext context, IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
    }
}