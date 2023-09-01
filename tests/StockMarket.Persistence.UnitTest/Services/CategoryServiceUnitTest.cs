using AutoMapper;
using FluentAssertions;
using Moq;
using StockMarket.Application.DTOs.CategoryDTOs;
using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.Exceptions;
using StockMarket.Application.Repositories;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Domain.Entities;
using StockMarket.Persistence.Repositories;
using StockMarket.Persistence.Services;
using System;
using System.Linq.Expressions;
using System.Net;
using Xunit;

namespace StockMarket.Persistence.UnitTest.Services
{
    public class CategoryServiceUnitTest
    {
        readonly CategoryService _categoryService;
        readonly Mock<IRepositoryManager> _mockRepositoryManager;
        readonly Mock<IMapper> _mockMapper;

        public CategoryServiceUnitTest()
        {
            _mockRepositoryManager = new();
            _mockMapper = new();
            _categoryService = new(_mockRepositoryManager.Object, _mockMapper.Object);
        }


        [Fact]
        public void CreateCategoryAsync_InvalidData_CreateFailedException()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.CreateAsync(It.IsAny<Category>())).ReturnsAsync(false);
            _mockMapper.Setup(x => x.Map<Category>(It.IsAny<CreateCategoryDto>())).Returns(new Category());


            Func<Task> func = async () => await _categoryService.CreateCategoryAsync(It.IsAny<CreateCategoryDto>());

            func.Should()
                .ThrowAsync<CreateFailedException>()
                .WithMessage("Category - Oluşturma Hatası !");
        }



        [Fact]
        public async void CreateCategoryAsync_ValidData_ReturnsSuccessResponse()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.CreateAsync(It.IsAny<Category>())).ReturnsAsync(true);
            _mockMapper.Setup(x => x.Map<Category>(It.IsAny<CreateCategoryDto>())).Returns(new Category());
            _mockRepositoryManager.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var result = await _categoryService.CreateCategoryAsync(It.IsAny<CreateCategoryDto>());

            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Should().BeOfType<ResponseDto<NoContentDto>>();

        }

        [Fact]
        public async void GetAllCategoriesAsync_ReturnsSuccesResponseWithListCategoryDto()
        {

            _mockRepositoryManager.Setup(x => x.CategoryRepository.GetAll(It.IsAny<bool>())).Returns(new List<Category>().AsQueryable());

            _mockMapper.Setup(x => x.Map<List<CategoryDto>>(It.IsAny<List<Category>>())).Returns(new List<CategoryDto>());

            var result = await _categoryService.GetAllCategoriesAsync();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeOfType<ResponseDto<List<CategoryDto>>>()
                .Subject
                .Data
                .Should()
                .BeOfType<List<CategoryDto>>();
        }

        [Fact]
        public void GetCategoryAsync_CategoryNotFound_NotFoundException()
        {
            Category category = null;
            _mockRepositoryManager.Setup(x => x.CategoryRepository.GetAsync(It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(category);

            Func<Task> func = async () => await _categoryService.GetCategoryAsync(It.IsAny<string>());

            func.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage("Category - Bulunamadı !");
        }

        [Fact]
        public async void GetCategoryAsync_CategoryFound_ReturnsSuccessResponseWithCategoryDto()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.GetAsync(It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(new Category());
            _mockMapper.Setup(x => x.Map<CategoryDto>(It.IsAny<Category>())).Returns(new CategoryDto());


            var result = await _categoryService.GetCategoryAsync(It.IsAny<string>());

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeOfType<ResponseDto<CategoryDto>>()
                .Subject
                .Data
                .Should()
                .BeOfType<CategoryDto>();

        }



        [Fact]
        public  void RemoveCategoryAsync_CategoryNotFound_NotFoundException()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(false);

            Func<Task> func = async () => await _categoryService.RemoveCategoryAsync(It.IsAny<string>());

            func.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage("Category - Bulunamadı !");
        }


        [Fact]
        public  void RemoveCategoryAsync_RemoveFailed_ReturnsFailResponse()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            _mockRepositoryManager.Setup(x => x.CategoryRepository.RemoveAsync(It.IsAny<string>())).ReturnsAsync(false);

            Func<Task> func = async ()=> await _categoryService.RemoveCategoryAsync(It.IsAny<string>());

            func.Should()
                .ThrowAsync<CreateFailedException>()
                .WithMessage("Category - Oluşturma Hatası !");
        }

        [Fact]
        public async void RemoveCategoryAsync_RemoveSuccess_ReturnsSuccessResponse()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            _mockRepositoryManager.Setup(x => x.CategoryRepository.RemoveAsync(It.IsAny<string>())).ReturnsAsync(true);
            _mockRepositoryManager.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var result = await _categoryService.RemoveCategoryAsync(It.IsAny<string>());

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeOfType<ResponseDto<NoContentDto>>();
        }

        [Fact]
        public  void UpdateCategoryAsync_CategoryNotFound_NotFoundException()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(false);

            Func<Task> func = async () => await _categoryService.UpdateCategoryAsync(It.IsAny<UpdateCategoryDto>());

            func.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage("Category - Bulunamadı !");
        }


        [Fact]
        public  void UpdateCategoryAsync_UpdateFailed_ReturnsFailResponse()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Update(It.IsAny<Category>())).Returns(false);
            _mockMapper.Setup(x => x.Map<Category>(It.IsAny<UpdateCategoryDto>())).Returns(new Category());

            Func<Task> func = async () => await _categoryService.UpdateCategoryAsync(It.IsAny<UpdateCategoryDto>());


            func.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage("Category - Güncelleme Hatası !");
        }

        [Fact]
        public async void UpdateCategoryAsync_UpdateSuccess_UpdateFailedException()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Update(It.IsAny<Category>())).Returns(true);
            _mockMapper.Setup(x => x.Map<Category>(It.IsAny<UpdateCategoryDto>())).Returns(new Category());

            var result = await _categoryService.UpdateCategoryAsync(It.IsAny<UpdateCategoryDto>());

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeOfType<ResponseDto<NoContentDto>>();
        }
    }
}
