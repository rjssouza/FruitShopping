using AutoMapper;
using Fruit.Application.ViewModels;
using Fruit.Domain.Entities;

namespace Fruit.Application.AutoMapper
{
    internal class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<FruitEntity, FruitViewModel>()
                .ForMember(t => t.Inventory, opt => opt.MapFrom(t => t.Inventory))
                .ForPath(t => t.Pictures, opt => opt.MapFrom(t => t.Pictures))
                .ForPath(t => t.SellItems, opt => opt.MapFrom(t => t.SellItems));

            CreateMap<FruitInventoryEntity, FruitInventoryViewModel>();
            CreateMap<FruitPictureEntity, FruitPictureViewModel>();
        }
    }
}