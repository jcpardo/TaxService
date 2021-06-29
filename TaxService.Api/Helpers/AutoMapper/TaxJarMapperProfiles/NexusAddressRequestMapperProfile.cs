using AutoMapper;
using TaxService.Api.Dtos.RequestForOrder;
using TaxService.Api.Entities.TaxJar.RequestForOrder;

namespace TaxService.Api.Helpers.AutoMapper.TaxJarMapperProfiles
{
    public class NexusAddressRequestMapperProfile : Profile
    {
        public NexusAddressRequestMapperProfile()
        {
            CreateMap<NexusAddressRequest, AddressRequestDto>().ReverseMap();
        }
    }
}