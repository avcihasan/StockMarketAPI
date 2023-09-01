using AutoMapper;
using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.Exceptions;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Domain.Entities;
using StockMarket.Persistence.Contexts;
using System.Linq.Expressions;
using System.Net;

namespace StockMarket.Persistence.Services
{
    public class CryptocurrencyService : ICryptocurrencyService
    {
        readonly IRepositoryManager _repositoryManager;
        readonly StockMartketDbContext stockMartketDbContext;
        readonly IMapper _mapper;

        public CryptocurrencyService(IRepositoryManager repositoryManager, IMapper mapper, StockMartketDbContext stockMartketDbContext)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            this.stockMartketDbContext = stockMartketDbContext;
        }

        public async Task<ResponseDto<NoContentDto>> CreateCryptocurrencyAsync(CreateCryptocurrencyDto cryptocurrency)
        {
            Cryptocurrency _cryptocurrency = _mapper.Map<Cryptocurrency>(cryptocurrency);
            bool result = await _repositoryManager.CryptocurrencyRepository.CreateAsync(_cryptocurrency);
            if (!result)
                throw new CreateFailedException(typeof(Cryptocurrency));
            try
            {
                await _repositoryManager.SaveAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            await _repositoryManager.CryptocurrencyRepository.GetAsync(_cryptocurrency.Id);
            return ResponseDto<NoContentDto>.Success(HttpStatusCode.Created);
        }

        public Task<ResponseDto<List<CryptocurrencyDto>>> GetAllCryptocurrenciesAsync()
            => Task.FromResult(ResponseDto<List<CryptocurrencyDto>>
                .Success(
                _mapper.Map<List<CryptocurrencyDto>>(_repositoryManager.CryptocurrencyRepository.GetAll().ToList()),
                HttpStatusCode.OK));

        //=> SuccessResponseDto<List<CryptocurrencyDto>>
        //    .Create(_mapper.Map<List<CryptocurrencyDto>>(await _repositoryManager.CryptocurrencyRepository
        //        .GetAll()
        //        //.Include(x => x.Category)
        //        //.Include(x=>x.CryptocurrencyPrices)
        //        .ToListAsync()), HttpStatusCode.OK);
        public Task<ResponseDto<List<CryptocurrencyDto>>> GetAllCryptocurrenciesAsync(Expression<Func<Cryptocurrency, bool>> func)
            => Task.FromResult(ResponseDto<List<CryptocurrencyDto>>.Success(_mapper.Map<List<CryptocurrencyDto>>(_repositoryManager.CryptocurrencyRepository.GetAll(func).ToList()), HttpStatusCode.OK));

        public async Task<ResponseDto<CryptocurrencyDto>> GetCryptocurrencyAsync(string id)
        {
            //Cryptocurrency cryptocurrency = await _repositoryManager.CryptocurrencyRepository
            //    .GetAll()
            //    .Include(x => x.CryptocurrencyPrices)
            //    .Include(x => x.Category)
            //    .FirstOrDefaultAsync(x=>x.Id==id); 
            Cryptocurrency cryptocurrency = await _repositoryManager.CryptocurrencyRepository
               .GetAsync(id);
            return cryptocurrency is null
                ? throw new NotFoundException(typeof(Cryptocurrency))
                : ResponseDto<CryptocurrencyDto>.Success(_mapper.Map<CryptocurrencyDto>(cryptocurrency), HttpStatusCode.OK);
        }

        public async Task<ResponseDto<CryptocurrencyDto>> GetCryptocurrencyAsync(Expression<Func<Cryptocurrency, bool>> func)
        {
            Cryptocurrency cryptocurrency = await _repositoryManager.CryptocurrencyRepository.GetAsync(func);
            return cryptocurrency is null
                ? throw new NotFoundException(typeof(Cryptocurrency))
                : ResponseDto<CryptocurrencyDto>.Success(_mapper.Map<CryptocurrencyDto>(cryptocurrency), HttpStatusCode.OK);
        }

        public async Task<ResponseDto<NoContentDto>> RemoveCryptocurrencyAsync(string id)
        {
            if (!_repositoryManager.CryptocurrencyRepository.Any(x => x.Id == id))
                throw new NotFoundException(typeof(Cryptocurrency));
            bool result = await _repositoryManager.CryptocurrencyRepository.RemoveAsync(id);
            if (!result)
                throw new CreateFailedException(typeof(Cryptocurrency));
            await _repositoryManager.SaveAsync();
            return ResponseDto<NoContentDto>.Success(HttpStatusCode.OK);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateCryptocurrencyAsync(UpdateCryptocurrencyDto updateCryptocurrencyDto)
        {
            if (!_repositoryManager.CryptocurrencyRepository.Any(x => x.Id == updateCryptocurrencyDto.Id))
                throw new NotFoundException(typeof(Cryptocurrency));
            bool result = _repositoryManager.CryptocurrencyRepository.Update(_mapper.Map<Cryptocurrency>(updateCryptocurrencyDto));
            if (!result)
                throw new UpdateFailedException(typeof(Cryptocurrency));
            await _repositoryManager.SaveAsync();
            return ResponseDto<NoContentDto>.Success(HttpStatusCode.OK);
        }
    }
}
