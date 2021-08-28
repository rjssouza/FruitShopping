using Core.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persona.Domain.Entities;

namespace Persona.Data.Context
{
    internal class PersonaDbContext : CoreDbContext
    {
        public DbSet<PersonaEntity> Persona { get; set; }
        public DbSet<PersonaPhotoEntity> PersonaPhoto { get; set; }

        public PersonaDbContext(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}