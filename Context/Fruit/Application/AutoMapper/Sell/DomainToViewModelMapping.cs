using AutoMapper;
using Fruit.Application.ViewModels.Sell;
using Fruit.Domain.Entities.Sell;

namespace Fruit.Application.AutoMapper.Sell
{
    internal class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<SellEntity, SellViewModel>()
                .ForPath(t => t.SellItems, opt => opt.MapFrom(t => t.SellItems));
            CreateMap<SellItemEntity, SellItemViewModel>();
        }
    }
}