using AutoMapper;
using StockMarket.Application.DTOs.CategoryDTOs;
using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.Exceptions;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Domain.Entities;
using System.Net;

namespace StockMarket.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        readonly IRepositoryManager _repositoryManager;
        readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseDto<NoContentDto>> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            bool result = await _repositoryManager.CategoryRepository.CreateAsync(_mapper.Map<Category>(categoryDto));
            if (!result)
                throw new CreateFailedException(typeof(Category));
            await _repositoryManager.SaveAsync();
            return ResponseDto<NoContentDto>.Success(HttpStatusCode.Created);
        }

        public Task<ResponseDto<List<CategoryDto>>> GetAllCategoriesAsync()
          => Task.FromResult(ResponseDto<List<CategoryDto>>
                .Success(_mapper.Map<List<CategoryDto>>(_repositoryManager.CategoryRepository
                    .GetAll()
                    .ToList()), HttpStatusCode.OK));

        public async Task<ResponseDto<CategoryDto>> GetCategoryAsync(int id)
        {
            Category category = await _repositoryManager.CategoryRepository.GetAsync(id);
            return category is null
                ? throw new NotFoundException(typeof(Category))
                : ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), HttpStatusCode.OK);
        }

        public async Task<ResponseDto<NoContentDto>> RemoveCategoryAsync(int id)
        {
            if (!_repositoryManager.CategoryRepository.Any(x => x.Id == id))
                throw new NotFoundException(typeof(Category));
            bool result = await _repositoryManager.CategoryRepository.RemoveAsync(id);
            if (!result)
                throw new RemoveFailedException(typeof(Category));
            await _repositoryManager.SaveAsync();
            return ResponseDto<NoContentDto>.Success(HttpStatusCode.OK);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {

            if (!_repositoryManager.CategoryRepository.Any(x => x.Id == categoryDto.Id))
                throw new NotFoundException(typeof(Category));
            bool result = _repositoryManager.CategoryRepository.Update(_mapper.Map<Category>(categoryDto));
            if (!result)
                throw new UpdateFailedException(typeof(Category));
            await _repositoryManager.SaveAsync();
            return ResponseDto<NoContentDto>.Success(HttpStatusCode.OK);
        }
    }
}
