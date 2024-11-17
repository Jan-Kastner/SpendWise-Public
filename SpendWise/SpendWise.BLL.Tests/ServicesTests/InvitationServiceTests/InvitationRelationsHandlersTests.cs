using SpendWise.BLL.Queries;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.BLL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Extensions;
using System;

namespace SpendWise.BLL.Tests.Handlers
{
    /// <summary>
    /// Contains tests for invitation-related handlers focusing on relations.
    /// </summary>
    public class InvitationRelationsHandlersTests : HandlersTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationRelationsHandlersTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public InvitationRelationsHandlersTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        /// <summary>
        /// Tests that the handler returns all invitation details.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllInvitationDetails()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(
                includeGroup: true,
                includeSender: true,
                includeReceiver: true,
                includeGroupParticipants: true,
                withoutResponseDate: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Console.WriteLine(result.ToJson());
        }
    }
}