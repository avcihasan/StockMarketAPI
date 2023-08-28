using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.DTOs.TokenDTOs;
using StockMarket.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Services
{
    public interface IAuthService
    {
        Task<ResponseDto<TokenDto>> LoginAsync(LoginUserDto loginUserDto);
        Task<ResponseDto<TokenDto>> RefreshTokenLoginAsync(string refreshToken);
    }
}
