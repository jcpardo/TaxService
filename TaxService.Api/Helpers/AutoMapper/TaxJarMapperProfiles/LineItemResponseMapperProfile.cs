using AutoMapper;
using TaxService.Api.Dtos.ResponseForOrder;
using TaxService.Api.Entities.TaxJar.ResponseForOrder;

namespace TaxService.Api.Helpers.AutoMapper.TaxJarMapperProfiles
{
    public class LineItemResponseMapperProfile : Profile
    {
        public LineItemResponseMapperProfile()
        {
            CreateMap<LineItemResponse, LineItemResponseDto>().ReverseMap();

        }
    }
}
