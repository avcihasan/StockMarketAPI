using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.DTOs.UserDTOs;
using StockMarket.Application.Exceptions;
using StockMarket.Application.Services;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResponseDto<NoContentDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            AppUser user = _mapper.Map<AppUser>(createUserDto);
            user.Id = Guid.NewGuid().ToString();
            IdentityResult result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (result.Succeeded)
                return ResponseDto<NoContentDto>.Success(HttpStatusCode.OK);

            StringBuilder sb = new();
            foreach (var error in result.Errors.Select(x => $"{x.Code} - {x.Description}\n").ToList())
                sb.Append(error);

            throw new CreateFailedException(sb.ToString());

        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user is not null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
        }
    }
}
