using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Application.DTOs.ResponseDTOs;
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
        Task<ResponseDto<List<CryptocurrencyDto>>> GetAllCryptocurrenciesAsync();
        Task<ResponseDto<List<CryptocurrencyDto>>> GetAllCryptocurrenciesAsync(Expression<Func<Cryptocurrency,bool>> func);
        Task<ResponseDto<CryptocurrencyDto>> GetCryptocurrencyAsync(int id);
        Task<ResponseDto<CryptocurrencyDto>> GetCryptocurrencyAsync(Expression<Func<Cryptocurrency, bool>> func);
        Task<ResponseDto<NoContentDto>> CreateCryptocurrencyAsync(CreateCryptocurrencyDto cryptocurrency);
        Task<ResponseDto<NoContentDto>> RemoveCryptocurrencyAsync(int id);
        Task<ResponseDto<NoContentDto>> UpdateCryptocurrencyAsync(UpdateCryptocurrencyDto updateCryptocurrencyDto);
    }
}
