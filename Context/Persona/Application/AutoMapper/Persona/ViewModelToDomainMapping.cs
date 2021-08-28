using AutoMapper;
using Core.Utils.Extension;
using Persona.Application.ViewModels;
using Persona.Domain.Entities;

namespace STI.Application.AutoMapper.Persona
{
    internal class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            this.CreateMap<PersonaViewModel, PersonaEntity>()
                .ForMember(g => g.PhotoEntities, m => m.MapFrom(a => a.Photo));
            this.CreateMap<PhotoViewModel, PersonaPhotoEntity>()
                .ForMember(g => g.Extension, m => m.MapFrom(a => a.Content.ObterExtensao()));
        }
    }
}