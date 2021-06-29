using AutoMapper;
using TaxService.Api.Dtos.RequestForOrder;
using TaxService.Api.Entities.TaxJar.RequestForOrder;

namespace TaxService.Api.Helpers.AutoMapper.TaxJarMapperProfiles
{
    public class LineItemRequestMapperProfile : Profile
    {
        public LineItemRequestMapperProfile()
        {
            CreateMap<LineItemRequest, LineItemRequestDto>().ReverseMap();
        }
    }
}