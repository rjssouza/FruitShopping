using AutoMapper;
using Fruit.Application.ViewModels.Cart;
using Fruit.Domain.Entities.Cart;

namespace Fruit.Application.AutoMapper.Cart
{
    internal class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<CartEntity, CartViewModel>()
                .ForPath(t => t.Items, opt => opt.MapFrom(t => t.Items));
            CreateMap<CartItemEntity, CartItemViewModel>()
                .ForMember(t => t.Price, opt => opt.MapFrom(t => t.Fruit.Price * t.Quantity))
                .ForMember(t => t.FruitName, opt => opt.MapFrom(t => t.Fruit.Name));
        }
    }
}