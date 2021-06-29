using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TaxService.Interfaces;

namespace TaxService.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Tax Service",
                    Description = "This API calculate taxes."
                });
                x.AddSecurityDefinition("apiKey", new OpenApiSecurityScheme
                {
                    Description = "Please enter the valid API Key",
                    In = ParameterLocation.Header,
                    Name = "apiKey",
                    Type = SecuritySchemeType.ApiKey
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "apiKey"
                                },
                                Name = "apiKey",
                                Type = SecuritySchemeType.ApiKey,
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //x.IncludeXmlComments(xmlPath);

                //x.CustomSchemaIds(s => s.GetCustomAttributes<DisplayNameAttribute>().SingleOrDefault()?.DisplayName);
            });
        }
    }
}