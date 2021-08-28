using Core.Domain.Validations;
using Persona.Domain.Entities;
using Persona.Domain.Interfaces.Infrastructure;
using Persona.Domain.Interfaces.Repositories;
using Persona.Domain.Interfaces.Validations;

namespace Persona.Domain.Validations
{
    internal class PersonaValidation : EntityValidation<PersonaEntity, IPersonaUnitOfWork>, IPersonaValidation
    {
        private readonly IPersonaPhotoValidation _personaPhotoValidation;

        public PersonaValidation(IPersonaUnitOfWork unitOfWork, IPersonaPhotoValidation personaPhotoValidation)
            : base(unitOfWork)
        {
            this._personaPhotoValidation = personaPhotoValidation;
        }

        public override void ValidateInsert(PersonaEntity entity)
        {
            base.ValidateInsert(entity);

            this.Active_OnlyOnePersonaActive();
            this.Name_NameMustBeInformed(entity);

            this.Validate();

            this.ValidatePhotosInsert(entity);
        }

        public override void ValidateUpdate(PersonaEntity entity)
        {
            base.ValidateUpdate(entity);

            this.Active_OnlyOnePersonaActive();
            this.Name_NameMustBeInformed(entity);

            this.Validate();

            this.ValidatePhotosUpdate(entity);
        }

        private void Active_OnlyOnePersonaActive()
        {
            var message = "Active_OnlyOnePersonaActive";
            var personaRepository = this._unitOfWork.GetRepository<IPersonaRepository>();
            var old = personaRepository.GetActive();

            if (old != null)
                this.AddError(message);
        }

        private void Name_NameMustBeInformed(PersonaEntity entity)
        {
            var message = "Name_NameMustBeInformed";

            if (string.IsNullOrEmpty(entity.Name))
                this.AddError(message);
        }

        private void ValidatePhotosInsert(PersonaEntity entity)
        {
            foreach (var photo in entity.PhotoEntities)
                this._personaPhotoValidation.ValidateInsert(photo);
        }

        private void ValidatePhotosUpdate(PersonaEntity entity)
        {
            foreach (var photo in entity.PhotoEntities)
                this._personaPhotoValidation.ValidateInsert(photo);
        }
    }
}