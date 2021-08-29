using AutoMapper;
using Fruit.Application.ViewModels.Sell;
using Fruit.Domain.Entities.Sell;

namespace Fruit.Application.AutoMapper.Sell
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