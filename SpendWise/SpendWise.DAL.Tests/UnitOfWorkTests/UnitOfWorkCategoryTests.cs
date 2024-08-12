using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SpendWise.DAL.UnitOfWork;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    public class UnitOfWorkCategoryTests : UnitOfWorkTestsBase
    {
        public UnitOfWorkCategoryTests(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public async Task CreateCategory_ShouldCreateNewCategory()
        {
            var newCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "New Category",
                Description = "Test Description",
                Color = "#0000ff",
                Icon = new byte[]{}
            };

            await _unitOfWork.Categories.InsertAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();

            var categoryInDb = await _unitOfWork.Categories.GetByIdAsync(newCategory.Id);

            Assert.NotNull(categoryInDb);
            DeepAssert.Equal(newCategory, categoryInDb);
        }

        [Fact]
        public async Task GetCategoryById_ReturnsCorrectCategory()
        {
            // Arrange
            var expectedCategoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);
            // Act
            var fetchedCategoryDto = await _unitOfWork.Categories.GetByIdAsync(expectedCategoryDto.Id);

            // Assert
            Assert.NotNull(expectedCategoryDto);
            DeepAssert.Equal(expectedCategoryDto, fetchedCategoryDto);
        }

        [Fact]
        public async Task UpdateCategory_UpdatesCategoryInDatabase()
        {
            // Arrange
            var existingCategoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            var updatedCategoryDto = new CategoryDto
            {
                Id = existingCategoryDto.Id,
                Name = "Updated Category",
                Color = "#00ff00",
                Description = "Updated Description",
                Icon = new byte[] {}
            };

            // Act
            await _unitOfWork.Categories.UpdateAsync(updatedCategoryDto);
            await _unitOfWork.SaveChangesAsync();

            var resultCategoryDto = await _unitOfWork.Categories.GetByIdAsync(updatedCategoryDto.Id);

            // Assert
            Assert.NotNull(resultCategoryDto);
            DeepAssert.Equal(updatedCategoryDto, resultCategoryDto);
        }

        [Fact]
        public async Task DeleteCategory_RemovesCategoryFromDatabase()
        {
            // Arrange
            var categoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            await _unitOfWork.Categories.DeleteAsync(categoryDto.Id);
            await _unitOfWork.SaveChangesAsync();

            var deletedCategory = await _unitOfWork.Categories.GetByIdAsync(categoryDto.Id);

            // Assert
            Assert.Null(deletedCategory);

            var totalCountAfterDelete = await _unitOfWork.Categories.Get().CountAsync();
            var totalCountBeforeDelete = totalCountAfterDelete + 1;
            Assert.Equal(totalCountBeforeDelete, totalCountAfterDelete + 1);
        }

    }
}
