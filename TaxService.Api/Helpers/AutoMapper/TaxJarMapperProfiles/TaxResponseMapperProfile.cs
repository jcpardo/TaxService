using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Api.Dtos.ResponseForOrder;
using TaxService.Api.Entities.TaxJar.ResponseForOrder;

namespace TaxService.Api.Helpers.AutoMapper.TaxJarMapperProfiles
{
    public class TaxResponseMapperProfile : Profile
    {
        public TaxResponseMapperProfile()
        {
            CreateMap<TaxResponse, TaxResponseDto>().ReverseMap();
        }
    }
}
