using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockMarket.Application.DTOs.CategoryDTOs;
using StockMarket.Application.DTOs.CryptocurrencyDTOs;
using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.Services;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
                return FailResponseDto<NoContentDto>.Create("Ekleme Hatası", HttpStatusCode.InternalServerError);
            await _repositoryManager.SaveAsync();
            return SuccessResponseDto<NoContentDto>.Create(HttpStatusCode.Created);
        }

        public Task<ResponseDto<List<CategoryDto>>> GetAllCategoriesAsync()
          => Task.FromResult(SuccessResponseDto<List<CategoryDto>>
                .Create(_mapper.Map<List<CategoryDto>>(_repositoryManager.CategoryRepository
                    .GetAll()
                    .ToList()), HttpStatusCode.OK));

        public async Task<ResponseDto<CategoryDto>> GetCategoryAsync(int id)
        {
            Category category = await _repositoryManager.CategoryRepository.GetAsync(id);
            return category is null
                ? FailResponseDto<CategoryDto>.Create("Bulunamadı", HttpStatusCode.InternalServerError)
                : SuccessResponseDto<CategoryDto>.Create(_mapper.Map<CategoryDto>(category), HttpStatusCode.OK);
        }

        public async Task<ResponseDto<NoContentDto>> RemoveCategoryAsync(int id)
        {
            if (!_repositoryManager.CategoryRepository.Any(x => x.Id == id))
                return FailResponseDto<NoContentDto>.Create("Bulunamadı", HttpStatusCode.InternalServerError);
            bool result = await _repositoryManager.CategoryRepository.RemoveAsync(id);
            if (!result)
                return FailResponseDto<NoContentDto>.Create("silme hatası", HttpStatusCode.InternalServerError);
            await _repositoryManager.SaveAsync();
            return SuccessResponseDto<NoContentDto>.Create(HttpStatusCode.OK);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {

            if (!_repositoryManager.CategoryRepository.Any(x => x.Id == categoryDto.Id))
                return FailResponseDto<NoContentDto>.Create("Bulunamadı", HttpStatusCode.InternalServerError);
            bool result = _repositoryManager.CategoryRepository.Update(_mapper.Map<Category>(categoryDto));
            if (!result)
                return FailResponseDto<NoContentDto>.Create("güncelleme hatası", HttpStatusCode.InternalServerError);
            await _repositoryManager.SaveAsync();
            return SuccessResponseDto<NoContentDto>.Create(HttpStatusCode.OK);
        }
    }
}
