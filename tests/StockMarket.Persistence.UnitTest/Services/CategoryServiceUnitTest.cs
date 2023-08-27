using AutoMapper;
using FluentAssertions;
using Moq;
using StockMarket.Application.DTOs.CategoryDTOs;
using StockMarket.Application.DTOs.ResponseDTOs;
using StockMarket.Application.Repositories;
using StockMarket.Application.UnitOfWorks;
using StockMarket.Domain.Entities;
using StockMarket.Persistence.Repositories;
using StockMarket.Persistence.Services;
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
        public async void CreateCategoryAsync_InvalidData_ReturnsFailResponse()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.CreateAsync(It.IsAny<Category>())).ReturnsAsync(false);
            _mockMapper.Setup(x => x.Map<Category>(It.IsAny<CreateCategoryDto>())).Returns(new Category());


            var result = await _categoryService.CreateCategoryAsync(It.IsAny<CreateCategoryDto>());

            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Should().BeOfType<FailResponseDto<NoContentDto>>()
                .Subject
                .Errors
                .First()
                .Should()
                .Be("Ekleme Hatası");
        }



        [Fact]
        public async void CreateCategoryAsync_ValidData_ReturnsSuccessResponse()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.CreateAsync(It.IsAny<Category>())).ReturnsAsync(true);
            _mockMapper.Setup(x => x.Map<Category>(It.IsAny<CreateCategoryDto>())).Returns(new Category());
            _mockRepositoryManager.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var result = await _categoryService.CreateCategoryAsync(It.IsAny<CreateCategoryDto>());

            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Should().BeOfType<SuccessResponseDto<NoContentDto>>();

        }

        [Fact]
        public async void GetAllCategoriesAsync_ReturnsSuccesResponseWithListCategoryDto()
        {

            _mockRepositoryManager.Setup(x => x.CategoryRepository.GetAll(It.IsAny<bool>())).Returns(new List<Category>().AsQueryable());

            _mockMapper.Setup(x => x.Map<List<CategoryDto>>(It.IsAny<List<Category>>())).Returns(new List<CategoryDto>());

            var result = await _categoryService.GetAllCategoriesAsync();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeOfType<SuccessResponseDto<List<CategoryDto>>>()
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
        public async void GetCategoryAsync_CategoryNotFound_ReturnsFailResponse(int id)
        {
            Category category = null;
            _mockRepositoryManager.Setup(x => x.CategoryRepository.GetAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(category);

            var result = await _categoryService.GetCategoryAsync(id);

            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Should().BeOfType<FailResponseDto<CategoryDto>>()
                .Subject.Errors.First().Should().Be("Bulunamadı");

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
            result.Should().BeOfType<SuccessResponseDto<CategoryDto>>()
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
        public async void RemoveCategoryAsync_CategoryNotFound_ReturnsFailResponse(int id)
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(false);

            var result = await _categoryService.RemoveCategoryAsync(id);

            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Should().BeOfType<FailResponseDto<NoContentDto>>()
                .Subject.Errors.First().Should().Be("Bulunamadı");
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async void RemoveCategoryAsync_RemoveFailed_ReturnsFailResponse(int id)
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            _mockRepositoryManager.Setup(x=>x.CategoryRepository.RemoveAsync(It.IsAny<int>())).ReturnsAsync(false);

            var result = await _categoryService.RemoveCategoryAsync(id);

            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Should().BeOfType<FailResponseDto<NoContentDto>>()
                .Subject.Errors.First().Should().Be("silme hatası");
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
            result.Should().BeOfType<SuccessResponseDto<NoContentDto>>();
        }

        [Fact]
        public async void UpdateCategoryAsync_CategoryNotFound_ReturnsFailResponse()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(false);

            var result = await _categoryService.UpdateCategoryAsync(It.IsAny<UpdateCategoryDto>());

            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Should().BeOfType<FailResponseDto<NoContentDto>>()
                .Subject.Errors.First().Should().Be("Bulunamadı");
        }


        [Fact]
        public async void UpdateCategoryAsync_UpdateFailed_ReturnsFailResponse()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Update(It.IsAny<Category>())).Returns(false);
            _mockMapper.Setup(x => x.Map<Category>(It.IsAny<UpdateCategoryDto>())).Returns(new Category());

            var result = await _categoryService.UpdateCategoryAsync(It.IsAny<UpdateCategoryDto>());

            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Should().BeOfType<FailResponseDto<NoContentDto>>()
                .Subject.Errors.First().Should().Be("güncelleme hatası");
        }

        [Fact]
        public async void UpdateCategoryAsync_UpdateSuccess_ReturnsSuccessResponse()
        {
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Any(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            _mockRepositoryManager.Setup(x => x.CategoryRepository.Update(It.IsAny<Category>())).Returns(true);
            _mockMapper.Setup(x => x.Map<Category>(It.IsAny<UpdateCategoryDto>())).Returns(new Category());

            var result = await _categoryService.UpdateCategoryAsync(It.IsAny<UpdateCategoryDto>());

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeOfType<SuccessResponseDto<NoContentDto>>();
        }
    }
}
