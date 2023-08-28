using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.DTOs.UserDTOs;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Services
{
    public interface  IUserService
    {
        Task<ResponseDto<NoContentDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
