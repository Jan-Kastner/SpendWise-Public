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
    /// Contains tests for user-related handlers focusing on relations.
    /// </summary>
    public class UserRelationsHandlersTests : HandlersTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRelationsHandlersTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public UserRelationsHandlersTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        /// <summary>
        /// Tests that the handler returns all user details.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllUserDetails()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(includeGroupUsers: true, includeGroups: true, namePartialMatch: "Dia");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Console.WriteLine(result.ToJson());
        }
    }
}