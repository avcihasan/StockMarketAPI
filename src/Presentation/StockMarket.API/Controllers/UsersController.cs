using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Application.DTOs.UserDTOs;
using StockMarket.Application.Services;

namespace StockMarket.API.Controllers
{
    
    public class UsersController : BaseController
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
            => CreateActionResult(await _userService.CreateUserAsync(createUserDto));
    }
}
