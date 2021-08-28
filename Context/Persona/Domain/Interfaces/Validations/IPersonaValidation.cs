using Core.Domain.Interfaces.Validations;
using Persona.Domain.Entities;

namespace Persona.Domain.Interfaces.Validations
{
    public interface IPersonaValidation : IEntityValidation<PersonaEntity>
    {
    }
}