using StockMarket.Application.DTOs.CategoryDTOs;
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
    public interface ICategoryService
    {
        Task<ResponseDto<List<CategoryDto>>> GetAllCategoriesAsync();
        Task<ResponseDto<CategoryDto>> GetCategoryAsync(string id);
        Task<ResponseDto<NoContentDto>> CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task<ResponseDto<NoContentDto>> RemoveCategoryAsync(string id);
        Task<ResponseDto<NoContentDto>> UpdateCategoryAsync(UpdateCategoryDto categoryDto);
    }
}
