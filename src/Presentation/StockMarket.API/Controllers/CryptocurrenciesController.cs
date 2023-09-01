using Microsoft.AspNetCore.Mvc;
using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Application.UnitOfWorks;

namespace StockMarket.API.Controllers
{
    public class CryptocurrenciesController : BaseController
    {
        readonly IServiceManager _serviceManager;

        public CryptocurrenciesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCryptocurrencyDto createCryptocurrencyDto)
            => CreateActionResult(await _serviceManager.CryptocurrencyService.CreateCryptocurrencyAsync(createCryptocurrencyDto));

        [HttpGet]
        public async Task<IActionResult> Get()
            => CreateActionResult(await _serviceManager.CryptocurrencyService.GetAllCryptocurrenciesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
            => CreateActionResult(await _serviceManager.CryptocurrencyService.GetCryptocurrencyAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] string id)
            => CreateActionResult(await _serviceManager.CryptocurrencyService.RemoveCryptocurrencyAsync(id));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCryptocurrencyDto updateCryptocurrencyDto)
            => CreateActionResult(await _serviceManager.CryptocurrencyService.UpdateCryptocurrencyAsync(updateCryptocurrencyDto));
      
    }
}
