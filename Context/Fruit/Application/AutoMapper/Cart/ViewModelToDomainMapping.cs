using AutoMapper;
using Fruit.Application.ViewModels.Cart;
using Fruit.Domain.Entities.Cart;

namespace Fruit.Application.AutoMapper.Cart
{
    internal class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<CartViewModel, CartEntity>()
                .ForPath(t => t.Items, opt => opt.MapFrom(t => t.Items));
            CreateMap<CartItemViewModel, CartItemEntity>();
        }
    }
}