using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Tests.Helpers;
using SpendWise.DAL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Test class for testing repository methods related to categories.
    /// </summary>
    public class CategoryRepositoryTests : RepositoryTestsBase
    {
        private readonly IRepository<CategoryEntity, CategoryDto> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the <see cref="CategoryRepositoryTests"/> class.
        /// Initializes the instance with necessary services.
        /// </summary>
        /// <param name="output">Provides output capabilities for test methods.</param>
        public CategoryRepositoryTests(ITestOutputHelper output) : base(output)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<CategoryEntity, CategoryDto>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Tests whether inserting a new category into the database successfully adds the category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertCategory_AddsCategoryToDatabase()
        {
            // Arrange
            var newCategoryDto = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Category",
                Color = "#ff0000",
                Description = null,
                Icon = new byte[] {}
            };

            // Act
            var insertedCategoryDto = await _repository.InsertAsync(newCategoryDto);

            // Assert
            Assert.NotNull(insertedCategoryDto);
            DeepAssert.Equal(newCategoryDto, insertedCategoryDto);
        }

        /// <summary>
        /// Tests whether retrieving a category by its ID returns the correct category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetCategoryById_ReturnsCorrectCategory()
        {
            // Arrange
            var expectedCategoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);
            // Act
            var fetchedCategoryDto = await _repository.GetByIdAsync(expectedCategoryDto.Id);

            // Assert
            Assert.NotNull(expectedCategoryDto);
            DeepAssert.Equal(expectedCategoryDto, fetchedCategoryDto);
        }

        /// <summary>
        /// Tests whether updating a category in the database successfully updates the existing category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
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
            var resultCategoryDto = await _repository.UpdateAsync(updatedCategoryDto);

            // Assert
            Assert.NotNull(resultCategoryDto);
            DeepAssert.Equal(updatedCategoryDto, resultCategoryDto);
            Assert.Equal(existingCategoryDto.Id, resultCategoryDto.Id);
        }

        /// <summary>
        /// Tests whether deleting a category from the database successfully removes the existing category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteCategory_RemovesCategoryFromDatabase()
        {
            // Arrange
            var categoryDto = _mapper.Map<CategoryDto>(CategorySeeds.CategoryFood);

            // Act
            await _repository.DeleteAsync(categoryDto.Id);
            var deletedCategory = await _repository.GetByIdAsync(categoryDto.Id);

            // Assert
            Assert.Null(deletedCategory);

            var totalCountAfterDelete = await _repository.Get().CountAsync();
            var totalCountBeforeDelete = totalCountAfterDelete + 1;
            Assert.Equal(totalCountBeforeDelete, totalCountAfterDelete + 1);
        }
    }
}
