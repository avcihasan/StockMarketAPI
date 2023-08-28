using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.DTOs.TokenDTOs;
using StockMarket.Application.DTOs.UserDTOs;
using StockMarket.Application.Services;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenService _tokenService;
        readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task<ResponseDto<TokenDto>> LoginAsync(LoginUserDto loginUserDto)
        {
            AppUser user = await _userManager.FindByNameAsync(loginUserDto.UserName);
            if (user is null)
                return FailResponseDto<TokenDto>.Create("Şifre veya kullanıcı adı hatalı", System.Net.HttpStatusCode.InternalServerError);
            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, false);
            if (signInResult.Succeeded)
            {
                var accessToken = _tokenService.CreateAccessToken(1);
                await _userService.UpdateRefreshTokenAsync(accessToken.RefreshToken, user, accessToken.Expiration, 1);
                return SuccessResponseDto<TokenDto>.Create(accessToken, System.Net.HttpStatusCode.OK);
            }
            return FailResponseDto<TokenDto>.Create("Şifre veya kullanıcı adı hatalı", System.Net.HttpStatusCode.InternalServerError);
        }

        public async Task<ResponseDto<TokenDto>> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (user != null && user.RefreshTokenEndDate > DateTime.Now)
            {
                TokenDto token = _tokenService.CreateAccessToken(1);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 1);
                return SuccessResponseDto<TokenDto>.Create(token, System.Net.HttpStatusCode.OK);
            }

            return FailResponseDto<TokenDto>.Create("hata", System.Net.HttpStatusCode.InternalServerError);
        }
    }
}






