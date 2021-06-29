using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Api.Dtos.ResponseForLocation;
using TaxService.Api.Entities.TaxJar.ResponseForLocation;

namespace TaxService.Api.Helpers.AutoMapper.TaxJarMapperProfiles
{
    public class RateResponseMapperProfile : Profile
    {
        public RateResponseMapperProfile()
        {
            CreateMap<RateResponse, RateResponseDto>().ReverseMap();
        }
    }
}
