using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository,CountryRepository>();
            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            services.AddScoped<ICityRepository,CityRepository>();

            return services;

        }
    }
}
