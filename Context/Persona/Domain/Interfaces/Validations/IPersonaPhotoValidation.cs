using Core.Domain.Interfaces.Validations;
using Persona.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Domain.Interfaces.Validations
{
    public interface IPersonaPhotoValidation : IEntityValidation<PersonaPhotoEntity>
    {
    }
}
