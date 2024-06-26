using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Admin.Countries;
using Services.Services.Interfaces;

namespace ApplicationAPI.Controllers.Admin
{
  
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;
        private readonly ILogger<CountryController> _logger;


        public CountryController(ICountryService countryService,
                                 ILogger<CountryController> logger)
        {
            _countryService = countryService;   
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Country get all is working");
                return Ok(await _countryService.GetAllAsync());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  CountryCreateDto request)
        {
            try
            {
                await _countryService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new {response ="Data successfully created"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });

            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var country = await _countryService.GetById(id);
                if (country == null)
                {
                    return NotFound();
                }
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _countryService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] CountryEditDto request)
        {
            try
            {
            
                await _countryService.EditAsync(id, request);
                return Ok();

                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
