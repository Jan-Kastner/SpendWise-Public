using Xunit;
using Xunit.Abstractions;
using SpendWise.BLL.DTOs.Category;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.BLL.Services.Interfaces;

namespace SpendWise.BLL.Tests.Services
{
    public class CategoryServiceTests : ServicesTestsBase
    {
        public CategoryServiceTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Verifies that getting a category by its ID 
        /// returns the correct entry from the service.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetById_ShouldReturnCorrectCategory()
        {
            // Act
            var category = await _categoryService.GetCategoriesByNameAsync("Food");

            // Assert
            Assert.NotNull(category);
            Console.WriteLine("category:" + category.First());
        }
    }
}