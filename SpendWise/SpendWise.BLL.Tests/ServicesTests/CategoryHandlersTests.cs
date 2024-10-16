using SpendWise.BLL.Queries;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.BLL.DTOs;
using SpendWise.Common.Tests.Seeds;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Handlers.Interfaces;
using Xunit;
using System.Threading.Tasks;

namespace SpendWise.BLL.Tests.Handlers
{
    /// <summary>
    /// Contains tests for category-related handlers.
    /// </summary>
    public class CategoryHandlersTests : HandlersTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryHandlersTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public CategoryHandlersTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        /// <summary>
        /// Tests that the handler returns all category details.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllCategoryDetails()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetCategoriesByCriteriaQueryHandler<CategoryDetailDto>>();
            var query = new GetCategoriesByCriteriaQuery(notColor: "#ff0000", notNamePartialMatch: "ood");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            // Print the details
            foreach (var category in result)
            {
                Console.WriteLine("Category Details:");
                Console.WriteLine($"ID: {category.Id}");
                Console.WriteLine($"Name: {category.Name}");
                Console.WriteLine($"Description: {category.Description}");
                Console.WriteLine($"Color: {category.Color}");
                Console.WriteLine($"Icon: {Convert.ToBase64String(category.Icon)}");
                Console.WriteLine("Transactions:");
                foreach (var transaction in category.Transactions)
                {
                    Console.WriteLine($"\tTransaction ID: {transaction.Id}");
                    Console.WriteLine($"\tAmount: {transaction.Amount}");
                    Console.WriteLine($"\tDate: {transaction.Date}");
                    Console.WriteLine($"\tDescription: {transaction.Description}");
                    Console.WriteLine($"\tType: {transaction.Type}");
                    Console.WriteLine();
                }
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}