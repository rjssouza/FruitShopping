using AutoMapper;
using Security.Application.ViewModels.Account;
using Security.Domain.Entities;

namespace Security.Application.AutoMapper.Account
{
    internal class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            this.CreateMap<ApplicationUser, RegisterViewModel>();
        }
    }
}