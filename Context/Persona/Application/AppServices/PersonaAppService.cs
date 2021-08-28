using AutoMapper;
using Core.Application.AppServices;
using Core.Domain.Interfaces.Repositories;
using Persona.Application.Interfaces.AppServices;
using Persona.Application.ViewModels;
using Persona.Domain.Entities;
using Persona.Domain.Interfaces.Infrastructure;
using Persona.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace Persona.Application.AppServices
{
    internal class PersonaAppService : AppServiceTransaction, IPersonaAppService
    {
        private readonly IPersonaService _personaService;
        private readonly IPictureInfraService _pictureInfraService;

        private readonly Random _random = new();

        public PersonaAppService(IUnitOfWorkTransaction coreUnitOfWorkTransaction,
            IMapper mapper,
            IPersonaService personaService,
            IPictureInfraService pictureInfraService)
            : base(coreUnitOfWorkTransaction, mapper)
        {
            this._personaService = personaService;
            this._pictureInfraService = pictureInfraService;
        }

        public void DeletePersona(Guid id)
        {
            var persona = this._personaService.GetById(id);

            this._personaService.Delete(persona);
        }

        public PersonaViewModel GetActive()
        {
            var persona = _personaService.GetActive();
            var result = this._mapper.Map<PersonaViewModel>(persona);
            foreach (var personaPhoto in result.Photo)
                personaPhoto.PicureUrl = this._pictureInfraService.GetPictureUrl(personaPhoto.Name);

            return result;
        }

        public string GetActiveName()
        {
            var persona = this._personaService.GetActive();

            return persona.Name;
        }

        public string GetActivePhoto()
        {
            var persona = _personaService.GetActive();
            var personaPhoto = this.GetRandomPhoto(persona);
            var pictureUrl = this._pictureInfraService.GetPictureUrl(personaPhoto.Name);

            return pictureUrl;
        }

        public PersonaViewModel GetById(Guid id)
        {
            var persona = _personaService.GetById(id);
            var result = this._mapper.Map<PersonaViewModel>(persona);

            return result;
        }

        public Guid SavePersona(PersonaViewModel persona)
        {
            foreach (var photo in persona.Photo)
                photo.Name = this._pictureInfraService.SavePicture(photo);

            var entity = this._mapper.Map<PersonaEntity>(persona);
            this._personaService.Insert(entity);

            this._coreUnitOfWorkTransaction.SaveChanges();

            return entity.Id;
        }

        public void SetPersonaActive(Guid id)
        {
            this.TryInactivateOthers();

            var newActive = _personaService.GetById(id);
            newActive.SetActive(true);
            _personaService.Update(newActive);

            this._coreUnitOfWorkTransaction.SaveChanges();
        }

        public void UpdatePersona(PersonaViewModel persona)
        {
            var entity = this._mapper.Map<PersonaEntity>(persona);

            this._personaService.Update(entity);

            this._coreUnitOfWorkTransaction.SaveChanges();
        }

        private PersonaPhotoEntity GetRandomPhoto(PersonaEntity personaViewModel)
        {
            var identifier = _random.Next(0, personaViewModel.PhotoEntities.Count + 1);
            var personaPhoto = personaViewModel.PhotoEntities.Where(t => t.Identifier == identifier).FirstOrDefault();
            while (personaPhoto == null)
            {
                identifier = _random.Next(0, personaViewModel.PhotoEntities.Count + 1);
                personaPhoto = personaViewModel.PhotoEntities.Where(t => t.Identifier == identifier).FirstOrDefault();
            }

            return personaPhoto;
        }

        private void TryInactivateOthers()
        {
            var oldActive = _personaService.GetActive();
            if (oldActive != null)
            {
                oldActive.SetActive(false);
                _personaService.Update(oldActive);
            }

            this._coreUnitOfWorkTransaction.SaveChanges();
        }
    }
}