using AutoMapper;
using TaxService.Api.Dtos.RequestForOrder;
using TaxService.Api.Entities.TaxJar.RequestForOrder;

namespace TaxService.Api.Helpers.AutoMapper.TaxJarMapperProfiles
{
    public class TaxRequestForOrderMapperProfile : Profile
    {
        public TaxRequestForOrderMapperProfile()
        {
            CreateMap<TaxJarRequestForOrder, TaxRequestForOrderDto>().ReverseMap();
        }
    }
}
