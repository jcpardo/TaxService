using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxService.Api.Helpers.AutoMapper;
using TaxService.Api.Interfaces;

namespace TaxService.Api.Installers
{
    public class MapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var mapper = AutoMapperUtility.MapperConfiguration().CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
