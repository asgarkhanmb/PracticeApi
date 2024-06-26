using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Services.DTOs.Admin.Cities;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CityService:ICityService
    {
        private readonly ICityRepository _cityRepo;
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<CityService> _logger;


        public CityService(ICityRepository cityRepo,
                           IMapper mapper,
                           ICountryRepository countryRepo,
                           ILogger<CityService> logger)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
            _countryRepo = countryRepo;
            _logger = logger;
        }

        public async Task CreateAsync(CityCreateDto model)
        {
           var existCountry = await _countryRepo.GetById(model.CountryId);
            if (existCountry is null)
            {
                _logger.LogWarning($"Country is not found - {model.CountryId + "-" + DateTime.Now.ToString()}");
                throw new ArgumentNullException(nameof(existCountry));
            }
           await _cityRepo.CreateAsync(_mapper.Map<City>(model));
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
           return _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.GetAllWithCountry());
        }

        public async Task<CityDto> GetByIdAsync(int id)
        {
            var data = _cityRepo.FindBy(m => m.Id == id, m => m.Country);
            return _mapper.Map<CityDto>(data.FirstOrDefault());
        }

        public async Task<CityDto> GetByNameAsync(string name)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            var data = _cityRepo.FindBy(m => m.Name==name, m => m.Country);
            return _mapper.Map<CityDto>(data.FirstOrDefault());
        }
    }
}
