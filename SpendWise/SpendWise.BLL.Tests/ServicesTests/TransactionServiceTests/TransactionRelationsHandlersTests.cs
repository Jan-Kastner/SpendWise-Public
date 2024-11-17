using SpendWise.BLL.Queries;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.BLL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Extensions;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces;

namespace SpendWise.BLL.Tests.Handlers
{
    /// <summary>
    /// Contains tests for transaction-related handlers focusing on relations.
    /// </summary>
    public class TransactionRelationsHandlersTests : HandlersTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRelationsHandlersTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public TransactionRelationsHandlersTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        /// <summary>
        /// Tests that the handler returns all transaction details.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllTransactionDetails()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmount: 100, includeCategory: true, includeGroups: true, includeUser: true, includeParticipants: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Console.WriteLine(result.ToJson());
        }
    }
}