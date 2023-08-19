using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Application.UnitOfWorks;

namespace StockMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptocurrenciesController : ControllerBase
    {

        readonly IServiceManager _serviceManager;

        public CryptocurrenciesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCryptocurrencyDto createCryptocurrencyDto)
        {
            await _serviceManager.CryptocurrencyService.CreateCryptocurrencyAsync(createCryptocurrencyDto);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serviceManager.CryptocurrencyService.GetCryptocurrenciesAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _serviceManager.CryptocurrencyService.GetCryptocurrencyAsync(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            await _serviceManager.CryptocurrencyService.RemoveCryptocurrencyAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCryptocurrencyDto updateCryptocurrencyDto)
        {
            await _serviceManager.CryptocurrencyService.UpdateCryptocurrencyAsync(updateCryptocurrencyDto);
            return Ok();
        }
    }
}
