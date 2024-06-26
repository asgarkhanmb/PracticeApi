using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation;
using Services.DTOs.Admin.Countries;
using Services.Helpers;
using System.Reflection;
using Services.Services.Interfaces;
using Services.Services;

namespace Services
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;

            });

            services.AddScoped<IValidator<CountryCreateDto>, CountryCreateDtoValidator>();

            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();

            return services;

        }
    }
}
