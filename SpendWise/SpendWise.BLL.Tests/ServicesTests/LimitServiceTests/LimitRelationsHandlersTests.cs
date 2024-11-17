using SpendWise.BLL.Queries;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.BLL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Extensions;

namespace SpendWise.BLL.Tests.Handlers
{
    /// <summary>
    /// Contains tests for limit-related handlers focusing on relations.
    /// </summary>
    public class LimitRelationsHandlersTests : HandlersTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="LimitRelationsHandlersTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public LimitRelationsHandlersTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        /// <summary>
        /// Tests that the handler returns all limit details.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllLimitDetails()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(notAmount: 100);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Console.WriteLine(result.ToJson());
        }
    }
}