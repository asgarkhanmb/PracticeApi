using Domain.Entities;
using Services.DTOs.Admin.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<CityDto> GetByIdAsync(int id);
        Task<CityDto> GetByNameAsync(string name);
        Task CreateAsync(CityCreateDto model);
    }
}
