using AutoMapper;
using Persona.Application.ViewModels;
using Persona.Domain.Entities;

namespace STI.Application.AutoMapper.Persona
{
    internal class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            this.CreateMap<PersonaEntity, PersonaViewModel>()
                .ForMember(g => g.Photo, m => m.MapFrom(a => a.PhotoEntities));
            this.CreateMap<PersonaPhotoEntity, PhotoViewModel>();
        }
    }
}