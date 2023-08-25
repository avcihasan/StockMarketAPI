using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Domain.Entities;
using StockMarket.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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
        public async Task<ResponseDto<NoContentDto>> CreateCryptocurrencyAsync(CreateCryptocurrencyDto cryptocurrency)
        {
            bool result = await _repositoryManager.CryptocurrencyRepository.CreateAsync(_mapper.Map<Cryptocurrency>(cryptocurrency));
            if (!result)
                return FailResponseDto<NoContentDto>.Create("Ekleme Hatası", HttpStatusCode.InternalServerError);
            await _repositoryManager.SaveAsync();
            return SuccessResponseDto<NoContentDto>.Create(HttpStatusCode.Created);
        }

        public Task<ResponseDto<List<CryptocurrencyDto>>> GetAllCryptocurrenciesAsync()
            => Task.FromResult(SuccessResponseDto<List<CryptocurrencyDto>>
                .Create(
                _mapper.Map<List<CryptocurrencyDto>>(_repositoryManager.CryptocurrencyRepository.GetAll().ToList()),
                HttpStatusCode.OK));

        //=> SuccessResponseDto<List<CryptocurrencyDto>>
        //    .Create(_mapper.Map<List<CryptocurrencyDto>>(await _repositoryManager.CryptocurrencyRepository
        //        .GetAll()
        //        //.Include(x => x.Category)
        //        //.Include(x=>x.CryptocurrencyPrices)
        //        .ToListAsync()), HttpStatusCode.OK);


        public Task<ResponseDto<List<CryptocurrencyDto>>> GetAllCryptocurrenciesAsync(Expression<Func<Cryptocurrency, bool>> func)
            => Task.FromResult(SuccessResponseDto<List<CryptocurrencyDto>>.Create(_mapper.Map<List<CryptocurrencyDto>>(_repositoryManager.CryptocurrencyRepository.GetAll(func).ToList()), HttpStatusCode.OK));

        public async Task<ResponseDto<CryptocurrencyDto>> GetCryptocurrencyAsync(int id)
        {
            //Cryptocurrency cryptocurrency = await _repositoryManager.CryptocurrencyRepository
            //    .GetAll()
            //    .Include(x => x.CryptocurrencyPrices)
            //    .Include(x => x.Category)
            //    .FirstOrDefaultAsync(x=>x.Id==id); 
            Cryptocurrency cryptocurrency = await _repositoryManager.CryptocurrencyRepository
               .GetAsync(id);
            return cryptocurrency is null
                ? FailResponseDto<CryptocurrencyDto>.Create("Bulunamadı", HttpStatusCode.InternalServerError)
                : SuccessResponseDto<CryptocurrencyDto>.Create(_mapper.Map<CryptocurrencyDto>(cryptocurrency), HttpStatusCode.OK);
        }

        public async Task<ResponseDto<CryptocurrencyDto>> GetCryptocurrencyAsync(Expression<Func<Cryptocurrency, bool>> func)
        {
            Cryptocurrency cryptocurrency = await _repositoryManager.CryptocurrencyRepository.GetAsync(func);
            return cryptocurrency is null
                ? FailResponseDto<CryptocurrencyDto>.Create("Bulunamadı", HttpStatusCode.InternalServerError)
                : SuccessResponseDto<CryptocurrencyDto>.Create(_mapper.Map<CryptocurrencyDto>(cryptocurrency), HttpStatusCode.OK);
        }

        public async Task<ResponseDto<NoContentDto>> RemoveCryptocurrencyAsync(int id)
        {
            if (!_repositoryManager.CryptocurrencyRepository.Any(x => x.Id == id))
                return FailResponseDto<NoContentDto>.Create("Bulunamadı", HttpStatusCode.InternalServerError);
            bool result = await _repositoryManager.CryptocurrencyRepository.RemoveAsync(id);
            if (!result)
                return FailResponseDto<NoContentDto>.Create("silme hatası", HttpStatusCode.InternalServerError);
            await _repositoryManager.SaveAsync();
            return SuccessResponseDto<NoContentDto>.Create(HttpStatusCode.OK);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateCryptocurrencyAsync(UpdateCryptocurrencyDto updateCryptocurrencyDto)
        {
            if (!_repositoryManager.CryptocurrencyRepository.Any(x => x.Id == updateCryptocurrencyDto.Id))
                return FailResponseDto<NoContentDto>.Create("Bulunamadı", HttpStatusCode.InternalServerError);
            bool result = _repositoryManager.CryptocurrencyRepository.Update(_mapper.Map<Cryptocurrency>(updateCryptocurrencyDto));
            if (!result)
                return FailResponseDto<NoContentDto>.Create("güncelleme hatası", HttpStatusCode.InternalServerError);
            await _repositoryManager.SaveAsync();
            return SuccessResponseDto<NoContentDto>.Create(HttpStatusCode.OK);
        }


    }
}
