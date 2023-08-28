using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Application.DTOs.UserDTOs;
using StockMarket.Application.Services;

namespace StockMarket.API.Controllers
{
    public class AuthController : BaseController
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
         => CreateActionResult(await _authService.LoginAsync(loginUserDto));

        [HttpGet]
        public async Task<IActionResult> RefreshTokenLogin([FromForm] string refreshToken)
         => CreateActionResult(await _authService.RefreshTokenLoginAsync(refreshToken));
    }
}
