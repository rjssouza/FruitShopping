using Core.Domain.Services;
using Persona.Domain.Entities;
using Persona.Domain.Interfaces.Infrastructure;
using Persona.Domain.Interfaces.Repositories;
using Persona.Domain.Interfaces.Services;
using Persona.Domain.Interfaces.Validations;
using System;

namespace Persona.Domain.Services
{
    internal class PersonaService : EntityValidationService<Guid, PersonaEntity, IPersonaRepository, IPersonaValidation, IPersonaUnitOfWork>, IPersonaService
    {
        public PersonaService(IPersonaValidation entityValidation, IPersonaUnitOfWork unityOfWork) : base(entityValidation, unityOfWork)
        {
        }

        public PersonaEntity GetActive()
        {
            var personaRepo = this._unitOfWork.GetRepository<IPersonaRepository>();
            var persona = personaRepo.GetActive();

            return persona;
        }
    }
}