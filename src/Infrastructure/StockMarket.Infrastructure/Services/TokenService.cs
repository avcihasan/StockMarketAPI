using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StockMarket.Application.ConfigurationModels;
using StockMarket.Application.DTOs.TokenDTOs;
using StockMarket.Application.Services;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        readonly JwtToken _jwtToken;
        public TokenService(IOptions<JwtToken> options)
        {
            _jwtToken = options.Value;
        }


        public TokenDto CreateAccessToken(int minute,AppUser user)
        {
            TokenDto token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_jwtToken.SigningKey));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddMinutes(minute);

            JwtSecurityToken jwtSecurityToken = new(
                audience: _jwtToken.Audience,
                issuer: _jwtToken.Issuer,
                notBefore: DateTime.Now,
                expires: token.Expiration,
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) }
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.RefreshToken = CreateRefreshToken();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using  RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
