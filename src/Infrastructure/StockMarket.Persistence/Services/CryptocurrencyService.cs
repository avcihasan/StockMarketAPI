using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Persistence.Services
{
    public class CryptocurrencyService : ICryptocurrencyService
    {
        readonly IRepositoryManager _repositoryManager;
        readonly IMapper _mapper;

        public CryptocurrencyService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateCryptocurrencyAsync(CreateCryptocurrencyDto cryptocurrency)
        {
            bool result = await _repositoryManager.CryptocurrencyRepository.CreateAsync(_mapper.Map<Cryptocurrency>(cryptocurrency));
            if (!result)
                throw new Exception("Ekleme Hatası");
            await _repositoryManager.SaveAsync();
        }

        public async Task<List<CryptocurrencyDto>> GetCryptocurrenciesAsync()
            => _mapper.Map<List<CryptocurrencyDto>>(await _repositoryManager.CryptocurrencyRepository.GetAll().ToListAsync());

        public async Task<List<CryptocurrencyDto>> GetCryptocurrenciesAsync(Expression<Func<Cryptocurrency, bool>> func)
            => _mapper.Map<List<CryptocurrencyDto>>(await _repositoryManager.CryptocurrencyRepository.GetAll(func).ToListAsync());

        public async Task<CryptocurrencyDto> GetCryptocurrencyAsync(int id)
        {
            Cryptocurrency cryptocurrency = await _repositoryManager.CryptocurrencyRepository.GetAsync(id);
            return cryptocurrency is null
                ? throw new Exception("Getirme Hatası")
                : _mapper.Map<CryptocurrencyDto>(cryptocurrency);
        }

        public async Task<CryptocurrencyDto> GetCryptocurrencyAsync(Expression<Func<Cryptocurrency, bool>> func)
        {
            Cryptocurrency cryptocurrency = await _repositoryManager.CryptocurrencyRepository.GetAsync(func);
            return cryptocurrency is null
                ? throw new Exception("Getirme Hatası")
                : _mapper.Map<CryptocurrencyDto>(cryptocurrency);
        }

        public async Task RemoveCryptocurrencyAsync(int id)
        {
            if (!_repositoryManager.CryptocurrencyRepository.Any(x => x.Id == id))
                throw new Exception("Bulunma hatası");
            bool result =await _repositoryManager.CryptocurrencyRepository.RemoveAsync(id);
            if (!result)
                throw new Exception("Silme Hatası");
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateCryptocurrencyAsync(UpdateCryptocurrencyDto updateCryptocurrencyDto)
        {
            if (!_repositoryManager.CryptocurrencyRepository.Any(x => x.Id == updateCryptocurrencyDto.Id))
                throw new Exception("Bulunma hatası");
            bool result = _repositoryManager.CryptocurrencyRepository.Update(_mapper.Map<Cryptocurrency>(updateCryptocurrencyDto));
            if (!result)
                throw new Exception("Güncelleme Hatası");
            await _repositoryManager.SaveAsync();
        }

    }
}
