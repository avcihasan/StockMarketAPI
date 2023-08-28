using AutoMapper;
using StockMarket.Application.DTOs.CategoryDTOs;
using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Application.DTOs.UserDTOs;
using StockMarket.Domain.Entities;
using StockMarket.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Cryptocurrency, CryptocurrencyDto>()
                .ForMember(x => x.CategoryName, x=> x.MapFrom(x=>x.Category.Name))
                .ReverseMap();
            CreateMap<CreateCryptocurrencyDto, Cryptocurrency>();
            CreateMap<UpdateCryptocurrencyDto, Cryptocurrency>();

            CreateMap<CryptocurrencyPrice, CryptocurrencyPriceDto>();
                
            CreateMap<CreateUserDto, AppUser>();

            

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, CategoryDto>(); 
          
        }
    }
}
