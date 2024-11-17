using SpendWise.BLL.Queries;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.BLL.DTOs;
using SpendWise.Common.Tests.Seeds;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Extensions;

namespace SpendWise.BLL.Tests.Handlers
{
    /// <summary>
    /// Contains tests for group-related handlers focusing on relations.
    /// </summary>
    public class GroupRelationsHandlersTests : HandlersTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupRelationsHandlersTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public GroupRelationsHandlersTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        /// <summary>
        /// Tests that the handler returns all group details.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllGroupDetails()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(descriptionPartialMatch: "Fam", includeUser: true, includeTransactions: true, includeCategories: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Console.WriteLine(result.ToJson());
        }
    }
}