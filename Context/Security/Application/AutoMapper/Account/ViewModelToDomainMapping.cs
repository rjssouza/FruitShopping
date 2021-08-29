using AutoMapper;
using Security.Application.ViewModels.Account;
using Security.Domain.Entities;

namespace Security.Application.AutoMapper.Account
{
    internal class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            this.CreateMap<RegisterViewModel, ApplicationUser>();
        }
    }
}