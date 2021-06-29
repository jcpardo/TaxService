using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Api.Dtos.ResponseForOrder;
using TaxService.Api.Entities.TaxJar.ResponseForOrder;

namespace TaxService.Api.Helpers.AutoMapper.TaxJarMapperProfiles
{
    public class JurisdictionsResponseMapperProfile : Profile
    {
        public JurisdictionsResponseMapperProfile()
        {
            CreateMap<JurisdictionsResponse, JurisdictionsResponseDto>().ReverseMap();
        }
    }
}
