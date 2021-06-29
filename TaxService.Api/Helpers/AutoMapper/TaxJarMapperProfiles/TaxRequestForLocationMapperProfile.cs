using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Api.Dtos.RequestForLocation;
using TaxService.Api.Entities.TaxJar.ResquestForLocation;

namespace TaxService.Api.Helpers.AutoMapper.TaxJarMapperProfiles
{
    public class TaxRequestForLocationMapperProfile : Profile
    {
        public TaxRequestForLocationMapperProfile()
        {
            CreateMap<TaxJarRequestForLocation, TaxRequestForLocationDto>().ReverseMap();
        }
    }
}
