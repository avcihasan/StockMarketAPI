using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.Services
{
    public interface ICryptocurrencyService
    {
       
        Task<List<CryptocurrencyDto>> GetCryptocurrenciesAsync();
        Task<List<CryptocurrencyDto>> GetCryptocurrenciesAsync(Expression<Func<Cryptocurrency,bool>> func);
        Task<CryptocurrencyDto> GetCryptocurrencyAsync(int id);
        Task<CryptocurrencyDto> GetCryptocurrencyAsync(Expression<Func<Cryptocurrency, bool>> func);
        Task CreateCryptocurrencyAsync(CreateCryptocurrencyDto cryptocurrency);
        Task RemoveCryptocurrencyAsync(int id);
        Task UpdateCryptocurrencyAsync(UpdateCryptocurrencyDto updateCryptocurrencyDto);
    }
}
