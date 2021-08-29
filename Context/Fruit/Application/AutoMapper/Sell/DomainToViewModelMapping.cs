using AutoMapper;
using Fruit.Application.ViewModels.Sell;
using Fruit.Domain.Entities.Sell;

namespace Fruit.Application.AutoMapper.Sell
{
    internal class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<CartEntity, CartViewModel>()
                .ForPath(t => t.Items, opt => opt.MapFrom(t => t.Items));
            CreateMap<CartItemEntity, CartItemViewModel>();
        }
    }
}