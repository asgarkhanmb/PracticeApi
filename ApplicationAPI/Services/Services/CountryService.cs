using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Services.DTOs.Admin.Countries;
using Services.Services.Interfaces;

namespace Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;


        public CountryService(ICountryRepository countryRepo,
                              IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }



        public async Task CreateAsync(CountryCreateDto model)
        {
            if (model is null) throw new ArgumentNullException();
            await _countryRepo.CreateAsync(_mapper.Map<Country>(model));
        }

        public async Task DeleteAsync(int id)
        {
            var existingCountry = await _countryRepo.GetById(id);
            if (existingCountry == null)
            {
                throw new ArgumentException();
            }

            await _countryRepo.DeleteAsync(existingCountry);
        }

        public async Task EditAsync(int id, CountryEditDto model)
        {
            var existingCountry = await _countryRepo.GetById(id);
            if (existingCountry == null)
            {
                throw new ArgumentException();
            }

            _mapper.Map(model, existingCountry);

            await _countryRepo.EditAsync(existingCountry);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
          return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.GetAllAsync());
        }

        public async Task<CountryDto> GetById(int id)
        {
            var country = await _countryRepo.GetById(id);
            return _mapper.Map<CountryDto>(country);
        }
    }
}
