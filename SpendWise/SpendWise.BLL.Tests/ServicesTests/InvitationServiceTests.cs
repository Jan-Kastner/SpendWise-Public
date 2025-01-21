using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Queries;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Tests.Seeds;

namespace SpendWise.BLL.Tests.ServicesTests
{
    /// <summary>
    /// Contains tests for invitation-related handlers focusing on relations.
    /// </summary>
    public class InvitationServiceTests : ServicesTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationServiceTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public InvitationServiceTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }


        #region Summary invitations

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by sent date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedBySentDate()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(sentDate: new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by not matching sent date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByNotSentDate()
        {
            // Arrange
            var expectedInvitations = new List<InvitationSummaryDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilySummary,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(notSentDate: new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by sent date range from.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedBySentDateFrom()
        {
            // Arrange
            var expectedInvitations = new List<InvitationSummaryDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilySummary,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(sentDateFrom: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by sent date range to.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedBySentDateTo()
        {
            // Arrange
            var expectedInvitations = new List<InvitationSummaryDto>
            {
                ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilySummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(sentDateTo: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by response date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByResponseDate()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(responseDate: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by not matching response date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByNotResponseDate()
        {
            // Arrange
            var expectedInvitations = new List<InvitationSummaryDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilySummary,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(notResponseDate: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by response date range from.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByResponseDateFrom()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(responseDateFrom: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by response date range to.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByResponseDateTo()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(responseDateTo: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by without response date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByWithoutResponseDate()
        {
            // Arrange
            var expectedInvitations = new List<InvitationSummaryDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilySummary,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(withResponseDate: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by acceptance status.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByIsAccepted()
        {
            // Arrange
            var expectedInvitations = new List<InvitationSummaryDto>
            {
                ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilySummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(isAccepted: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by pending status.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByIsPending()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkSummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(isPending: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by sender ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedBySenderId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(senderId: UserSeeds.UserDianaGreen.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by not matching sender ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByNotSenderId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(notSenderId: UserSeeds.UserJohnDoe.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by receiver ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByReceiverId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(receiverId: UserSeeds.UserCharlieBlack.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by not matching receiver ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByNotReceiverId()
        {
            // Arrange
            var expectedInvitations = new List<InvitationSummaryDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilySummary,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(notReceiverId: UserSeeds.UserCharlieBlack.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByGroupId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkSummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(groupId: GroupSeeds.GroupWork.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by not matching group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedByNotGroupId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkSummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationsByCriteriaQuery(notGroupId: GroupSeeds.GroupFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }
        #endregion

        #region List invitations

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by sent date.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedBySentDate()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(sentDate: new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by not matching sent date.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByNotSentDate()
        {
            // Arrange
            var expectedInvitations = new List<InvitationListDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyList,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(notSentDate: new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by response date.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByResponseDate()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(responseDate: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by not matching response date.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByNotResponseDate()
        {
            // Arrange
            var expectedInvitations = new List<InvitationListDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyList,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(notResponseDate: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by without response date.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByWithoutResponseDate()
        {
            // Arrange
            var expectedInvitations = new List<InvitationListDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyList,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(withResponseDate: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by acceptance status.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByIsAccepted()
        {
            // Arrange
            var expectedInvitations = new List<InvitationListDto>
            {
                ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyList,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyList
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(isAccepted: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by pending status.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByIsPending()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkList;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(isPending: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by sender ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedBySenderId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(senderId: UserSeeds.UserDianaGreen.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by not matching sender ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByNotSenderId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(notSenderId: UserSeeds.UserJohnDoe.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by receiver ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByReceiverId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(receiverId: UserSeeds.UserCharlieBlack.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by not matching receiver ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByNotReceiverId()
        {
            // Arrange
            var expectedInvitations = new List<InvitationListDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyList,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(notReceiverId: UserSeeds.UserCharlieBlack.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by group ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByGroupId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkList;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(groupId: GroupSeeds.GroupWork.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by not matching group ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedByNotGroupId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkList;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationListDto>>();
            var query = new GetInvitationsByCriteriaQuery(notGroupId: GroupSeeds.GroupFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }
        #endregion

        #region Detail invitations

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by sent date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedBySentDate()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(sentDate: new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by not matching sent date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByNotSentDate()
        {
            // Arrange
            var expectedInvitations = new List<InvitationDetailDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyDetail,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(notSentDate: new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by response date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByResponseDate()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(responseDate: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by not matching response date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByNotResponseDate()
        {
            // Arrange
            var expectedInvitations = new List<InvitationDetailDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyDetail,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(notResponseDate: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by without response date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByWithoutResponseDate()
        {
            // Arrange
            var expectedInvitations = new List<InvitationDetailDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyDetail,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(withResponseDate: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by acceptance status.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByIsAccepted()
        {
            // Arrange
            var expectedInvitations = new List<InvitationDetailDto>
            {
                ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(isAccepted: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by pending status.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByIsPending()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(isPending: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by sender ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedBySenderId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(senderId: UserSeeds.UserDianaGreen.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by not matching sender ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByNotSenderId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(notSenderId: UserSeeds.UserJohnDoe.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by receiver ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByReceiverId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(receiverId: UserSeeds.UserCharlieBlack.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by not matching receiver ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByNotReceiverId()
        {
            // Arrange
            var expectedInvitations = new List<InvitationDetailDto>
            {
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoFamilyDetail,
                ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(notReceiverId: UserSeeds.UserCharlieBlack.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedInvitation in expectedInvitations)
            {
                Assert.Contains(result, i => i.Id == expectedInvitation.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByGroupId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(groupId: GroupSeeds.GroupWork.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by not matching group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByNotGroupId()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationJohnToDianaIntoWorkDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(notGroupId: GroupSeeds.GroupFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }
        #endregion

        #region List invitaions by ID

        /// <summary>
        /// Tests that the handler returns the correct invitation list when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationList_WhenQueriedById()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationByIdQueryHandler<InvitationListDto>>();
            var query = new GetInvitationByIdQuery(InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedInvitation, result);
        }

        #endregion

        #region Summary invitations by ID

        /// <summary>
        /// Tests that the handler returns the correct invitation summary when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationSummary_WhenQueriedById()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationByIdQueryHandler<InvitationSummaryDto>>();
            var query = new GetInvitationByIdQuery(InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedInvitation, result);
        }

        #endregion

        #region Detail invitations by ID

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedById()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationByIdQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationByIdQuery(InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedInvitation, result);
        }

        #endregion

        #region Detail invitations by multiple queries

        /// <summary>
        /// Tests that the handler returns the correct invitation detail when queried by multiple criteria.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetail_WhenQueriedByMultipleCriteria()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationsByCriteriaQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationsByCriteriaQuery(
                sentDate: new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc),
                responseDate: new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc),
                isAccepted: true,
                senderId: UserSeeds.UserDianaGreen.Id,
                receiverId: UserSeeds.UserCharlieBlack.Id,
                groupId: GroupSeeds.GroupFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedInvitation, result.FirstOrDefault());
        }
        #endregion

        #region Related entities

        /// <summary>
        /// Tests that the handler returns the correct invitation detail with sender when queried by ID with sender.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetailWithSender_WhenQueriedByIdWithSender()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationByIdQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationByIdQuery(InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id, includeSender: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedInvitation, result);
            Assert.NotNull(result.Sender);
            DeepAssert.Equal(expectedInvitation.Sender, result.Sender);
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail with receiver when queried by ID with receiver.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetailWithReceiver_WhenQueriedByIdWithReceiver()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationByIdQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationByIdQuery(InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id, includeReceiver: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedInvitation, result);
            Assert.NotNull(result.Receiver);
            DeepAssert.Equal(expectedInvitation.Receiver, result.Receiver);
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail with group when queried by ID with group.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetailWithGroup_WhenQueriedByIdWithGroup()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationByIdQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationByIdQuery(InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id, includeGroup: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedInvitation, result);
            Assert.NotNull(result.Group);
            DeepAssert.Equal(expectedInvitation.Group, result.Group, propertiesToIgnore: new[] { "GroupParticipants" });
        }

        /// <summary>
        /// Tests that the handler returns the correct invitation detail with group participants when queried by ID with group participants.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnInvitationDetailWithRelations_WhenQueriedByIdWithRelations()
        {
            // Arrange
            var expectedInvitation = ExpectedInvitationServiceResults.InvitationDianaToCharlieIntoFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetInvitationByIdQueryHandler<InvitationDetailDto>>();
            var query = new GetInvitationByIdQuery(InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id, includeSender: true, includeReceiver: true, includeGroupParticipants: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedInvitation, result);
            Assert.NotNull(result.Group);
            Assert.NotNull(result.Sender);
            Assert.NotNull(result.Receiver);
            Assert.NotEmpty(result.Group.GroupParticipants);
            DeepAssert.Equal(expectedInvitation.Group, result.Group);
            DeepAssert.Equal(expectedInvitation.Sender, result.Sender);
            DeepAssert.Equal(expectedInvitation.Receiver, result.Receiver);
            foreach (var groupParticipant in expectedInvitation.Group!.GroupParticipants)
            {
                Assert.Contains(result.Group.GroupParticipants, gp => gp.Id == groupParticipant.Id);
            }
        }
        #endregion
    }
}