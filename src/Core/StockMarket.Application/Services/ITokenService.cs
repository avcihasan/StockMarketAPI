using StockMarket.Application.DTOs.TokenDTOs;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Services
{
    public interface  ITokenService
    {
        TokenDto CreateAccessToken(int minute,AppUser user);
        string CreateRefreshToken();
    }
}
