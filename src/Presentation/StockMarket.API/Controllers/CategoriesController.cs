using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Application.DTOs.CategoryDTOs;
using StockMarket.Application.UnitOfWorks;

namespace StockMarket.API.Controllers
{
    [Authorize(AuthenticationSchemes ="User")]
    public class CategoriesController : BaseController
    {
        readonly IServiceManager _serviceManager;

        public CategoriesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => CreateActionResult(await _serviceManager.CategoryService.GetAllCategoriesAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
            => CreateActionResult(await _serviceManager.CategoryService.GetCategoryAsync(id));
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto categoryDto)
            => Ok(await _serviceManager.CategoryService.CreateCategoryAsync(categoryDto));
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCategoryDto categoryDto)
           => Ok(await _serviceManager.CategoryService.UpdateCategoryAsync(categoryDto));
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
           => Ok(await _serviceManager.CategoryService.RemoveCategoryAsync(id));
    }
}
