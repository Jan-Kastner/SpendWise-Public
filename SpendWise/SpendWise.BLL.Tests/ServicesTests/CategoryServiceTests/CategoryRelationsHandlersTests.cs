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
    /// Contains tests for category-related handlers focusing on relations.
    /// </summary>
    public class CategoryRelationsHandlersTests : HandlersTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRelationsHandlersTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public CategoryRelationsHandlersTests(ITestOutputHelper output) : base(output)
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
        }
    }
}