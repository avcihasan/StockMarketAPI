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

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void GetCategoryAsync_CategoryNotFound_NotFoundException(int id)
        {
            Category category = null;
            _mockRepositoryManager.Setup(x => x.CategoryRepository.GetAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(category);

            Func<Task> func = async () => await _categoryService.GetCategoryAsync(id);

            func.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage("Category - Bulunamadı !");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async void GetCategoryAsync_CategoryFound_ReturnsSuccessResponseWithCategoryDto(int id)
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.GetAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(new Category());
            _mockMapper.Setup(x => x.Map<CategoryDto>(It.IsAny<Category>())).Returns(new CategoryDto());


            var result = await _categoryService.GetCategoryAsync(id);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeOfType<ResponseDto<CategoryDto>>()
                .Subject
                .Data
                .Should()
                .BeOfType<CategoryDto>();

        }



        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public  void RemoveCategoryAsync_CategoryNotFound_NotFoundException(int id)
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(false);

            Func<Task> func = async () => await _categoryService.RemoveCategoryAsync(id);

            func.Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage("Category - Bulunamadı !");
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public  void RemoveCategoryAsync_RemoveFailed_ReturnsFailResponse(int id)
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            _mockRepositoryManager.Setup(x => x.CategoryRepository.RemoveAsync(It.IsAny<int>())).ReturnsAsync(false);

            Func<Task> func = async ()=> await _categoryService.RemoveCategoryAsync(id);

            func.Should()
                .ThrowAsync<CreateFailedException>()
                .WithMessage("Category - Oluşturma Hatası !");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async void RemoveCategoryAsync_RemoveSuccess_ReturnsSuccessResponse(int id)
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            _mockRepositoryManager.Setup(x => x.CategoryRepository.RemoveAsync(It.IsAny<int>())).ReturnsAsync(true);
            _mockRepositoryManager.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var result = await _categoryService.RemoveCategoryAsync(id);

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
