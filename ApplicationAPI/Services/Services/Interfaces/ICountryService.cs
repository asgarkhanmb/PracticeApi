using Services.DTOs.Admin.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task CreateAsync(CountryCreateDto model);
        Task<CountryDto>GetById(int id);
        Task DeleteAsync(int id);
        Task EditAsync(int id,CountryEditDto model);

    }
}
