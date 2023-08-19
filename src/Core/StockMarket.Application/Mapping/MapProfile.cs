﻿using AutoMapper;
using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Domain.Entities;
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
            CreateMap<Cryptocurrency, CryptocurrencyDto>().ReverseMap();
            CreateMap<CreateCryptocurrencyDto, Cryptocurrency>();
            CreateMap<UpdateCryptocurrencyDto, Cryptocurrency>();
        }
    }
}