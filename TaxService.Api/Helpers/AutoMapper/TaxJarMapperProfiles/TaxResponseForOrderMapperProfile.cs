using AutoMapper;
using TaxService.Api.Dtos.ResponseForOrder;
using TaxService.Api.Entities.TaxJar.ResponseForOrder;

namespace TaxService.Api.Helpers.AutoMapper.TaxJarMapperProfiles
{
    public class TaxResponseForOrderMapperProfile : Profile
    {
        public TaxResponseForOrderMapperProfile()
        {
            CreateMap<TaxJarResponseForOrder, TaxResponseForOrderDto>().ReverseMap();
        }
    }
}
