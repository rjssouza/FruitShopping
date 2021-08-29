using AutoMapper;
using Fruit.Application.ViewModels.Sell;
using Fruit.Domain.Entities.Sell;

namespace Fruit.Application.AutoMapper.Sell
{
    internal class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<SellViewModel, SellEntity>()
                .ForPath(t => t.SellItems, opt => opt.MapFrom(t => t.SellItems));
            CreateMap<SellItemViewModel, SellItemEntity>();
        }
    }
}