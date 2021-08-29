using AutoMapper;
using Fruit.Application.ViewModels;
using Fruit.Domain.Entities;
using System.Linq;

namespace Fruit.Application.AutoMapper
{
    internal class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<FruitViewModel, FruitEntity>()
               .ForMember(t => t.Inventory, opt => opt.MapFrom(t => t.Inventory))
               .ForPath(t => t.Pictures, opt => opt.MapFrom(t => t.Pictures))
               .ForPath(t => t.SellItems, opt => opt.MapFrom(t => t.SellItems));

            CreateMap<FruitInventoryViewModel, FruitInventoryEntity>();
            CreateMap<FruitPictureViewModel, FruitPictureEntity>();

            CreateMap<FruitViewModel, FruitTableItemViewModel>()
                .ForMember(t => t.Picture, opt => opt.MapFrom(t => t.Pictures.Select(z => z.Content).FirstOrDefault()));
        }
    }
}