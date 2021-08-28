using Core.Domain.Validations;
using Persona.Domain.Entities;
using Persona.Domain.Interfaces.Infrastructure;
using Persona.Domain.Interfaces.Validations;

namespace Persona.Domain.Validations
{
    internal class PersonaPhotoValidation : EntityValidation<PersonaPhotoEntity, IPersonaUnitOfWork>, IPersonaPhotoValidation
    {
        public PersonaPhotoValidation(IPersonaUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void ValidateInsert(PersonaPhotoEntity entity)
        {
            base.ValidateInsert(entity);
            this.Name_NameMustBeInformed(entity);
            this.Extension_ExtensionIsRequired(entity);

            this.Validate();
        }

        public override void ValidateUpdate(PersonaPhotoEntity entity)
        {
            base.ValidateUpdate(entity);
            this.Name_NameMustBeInformed(entity);
            this.Extension_ExtensionIsRequired(entity);

            this.Validate();
        }

        private void Extension_ExtensionIsRequired(PersonaPhotoEntity entity)
        {
            var message = "Extension_ExtensionIsRequired";
            if (string.IsNullOrEmpty(entity.Extension))
                this.AddError(message);
        }

        private void Name_NameMustBeInformed(PersonaPhotoEntity entity)
        {
            var message = "Name_NameMustBeInformed";

            if (string.IsNullOrEmpty(entity.Name))
                this.AddError(message);
        }
    }
}