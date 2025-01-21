using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Queries;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Extensions;

namespace SpendWise.BLL.Tests.ServicesTests
{
    /// <summary>
    /// Contains tests for group-related handlers focusing on relations.
    /// </summary>
    public class GroupServiceTests : ServicesTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupServiceTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public GroupServiceTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        #region Summary Groups

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving all group summaries without any criteria.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllGroupSummaries_WhenQueriedWithoutCriteria()
        {
            // Arrange
            var expectedGroups = new List<GroupSummaryDto>
            {
                ExpectedGroupServiceResults.GroupFamilySummary,
                ExpectedGroupServiceResults.GroupFriendsSummary,
                ExpectedGroupServiceResults.GroupWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery();

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(expectedGroup, result);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving a group summary by name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedByName()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(name: "Family");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving a group summary by partial name match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedByNamePartialMatch()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(namePartialMatch: "Fam");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries excluding a specific name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedNotName()
        {
            // Arrange
            var expectedGroups = new List<GroupSummaryDto>
            {
                ExpectedGroupServiceResults.GroupFriendsSummary,
                ExpectedGroupServiceResults.GroupWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(notName: "Family");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(expectedGroup, result);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries excluding a partial name match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedNotNamePartialMatch()
        {
            // Arrange
            var expectedGroups = new List<GroupSummaryDto>
            {
                ExpectedGroupServiceResults.GroupFriendsSummary,
                ExpectedGroupServiceResults.GroupWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(notNamePartialMatch: "Fam");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(expectedGroup, result);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries by description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedByDescription()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFriendsSummary;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(description: "Friends group");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries by partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedByDescriptionPartialMatch()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFriendsSummary;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(descriptionPartialMatch: "Friends");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries excluding a specific description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedNotDescription()
        {
            // Arrange
            var expectedGroups = new List<GroupSummaryDto>
            {
                ExpectedGroupServiceResults.GroupFamilySummary,
                ExpectedGroupServiceResults.GroupWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(notDescription: "Friends group");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(expectedGroup, result);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries excluding a partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedNotDescriptionPartialMatch()
        {
            // Arrange
            var expectedGroups = new List<GroupSummaryDto>
            {
                ExpectedGroupServiceResults.GroupFamilySummary,
                ExpectedGroupServiceResults.GroupWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(notDescriptionPartialMatch: "Friends");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(expectedGroup, result);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries without a description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedWithoutDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(withDescription: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries that are not without a description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedNotWithoutDescription()
        {
            // Arrange
            var expectedGroups = new List<GroupSummaryDto>
            {
                ExpectedGroupServiceResults.GroupFamilySummary,
                ExpectedGroupServiceResults.GroupFriendsSummary,
                ExpectedGroupServiceResults.GroupWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(withDescription: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(expectedGroup, result);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries by invitation ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedByInvitationId()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(invitationId: InvitationSeeds.InvitationJohnToDianaIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group summaries excluding a specific invitation ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedNotInvitationId()
        {
            // Arrange
            var expectedGroups = new List<GroupSummaryDto>
            {
                ExpectedGroupServiceResults.GroupFriendsSummary,
                ExpectedGroupServiceResults.GroupWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupsByCriteriaQuery(notInvitationId: InvitationSeeds.InvitationJohnToDianaIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(expectedGroup, result);
            }
        }

        #endregion

        #region List Groups

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving all group lists without any criteria.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllGroupLists_WhenQueriedWithoutCriteria()
        {
            // Arrange
            var expectedGroups = new List<GroupListDto>
            {
                ExpectedGroupServiceResults.GroupFamilyList,
                ExpectedGroupServiceResults.GroupFriendsList,
                ExpectedGroupServiceResults.GroupWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(includeUser: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                DeepAssert.Contains(expectedGroup, result, propertiesToIgnore: ["GroupParticipants"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving a group list by name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedByName()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(name: "Family");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving a group list by partial name match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedByNamePartialMatch()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(namePartialMatch: "Fam");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists excluding a specific name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedNotName()
        {
            // Arrange
            var expectedGroups = new List<GroupListDto>
            {
                ExpectedGroupServiceResults.GroupFriendsList,
                ExpectedGroupServiceResults.GroupWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(notName: "Family");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists excluding a partial name match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedNotNamePartialMatch()
        {
            // Arrange
            var expectedGroups = new List<GroupListDto>
            {
                ExpectedGroupServiceResults.GroupFriendsList,
                ExpectedGroupServiceResults.GroupWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(notNamePartialMatch: "Fam");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists by description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedByDescription()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFriendsList;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(description: "Friends group");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists by partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedByDescriptionPartialMatch()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFriendsList;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(descriptionPartialMatch: "Friends");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists excluding a specific description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedNotDescription()
        {
            // Arrange
            var expectedGroups = new List<GroupListDto>
            {
                ExpectedGroupServiceResults.GroupFamilyList,
                ExpectedGroupServiceResults.GroupWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(notDescription: "Friends group");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists excluding a partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedNotDescriptionPartialMatch()
        {
            // Arrange
            var expectedGroups = new List<GroupListDto>
            {
                ExpectedGroupServiceResults.GroupFamilyList,
                ExpectedGroupServiceResults.GroupWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(notDescriptionPartialMatch: "Friends");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists without a description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedWithoutDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(withDescription: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists that are not without a description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedNotWithoutDescription()
        {
            // Arrange
            var expectedGroups = new List<GroupListDto>
            {
                ExpectedGroupServiceResults.GroupFamilyList,
                ExpectedGroupServiceResults.GroupFriendsList,
                ExpectedGroupServiceResults.GroupWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(withDescription: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists by invitation ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedByInvitationId()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(invitationId: InvitationSeeds.InvitationJohnToDianaIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group lists excluding a specific invitation ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedNotInvitationId()
        {
            // Arrange
            var expectedGroups = new List<GroupListDto>
            {
                ExpectedGroupServiceResults.GroupFriendsList,
                ExpectedGroupServiceResults.GroupWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupListDto>>();
            var query = new GetGroupsByCriteriaQuery(notInvitationId: InvitationSeeds.InvitationJohnToDianaIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        #endregion

        #region Detailed Groups

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving all group details with participants included.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllGroupDetail_WhenQueriedWithoutCriteriaIncludeParticipants()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFamilyDetail,
                ExpectedGroupServiceResults.GroupFriendsDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(includeUser: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                DeepAssert.Contains(expectedGroup, result, propertiesToIgnore: ["GroupParticipants"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving all group details with transactions included.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllGroupDetail_WhenQueriedWithoutCriteriaIncludeTransactions()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFamilyDetail,
                ExpectedGroupServiceResults.GroupFriendsDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(includeTransactions: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                DeepAssert.Contains(expectedGroup, result, propertiesToIgnore: ["GroupParticipants"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving all group details with categories included.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnAllGroupDetail_WhenQueriedWithoutCriteriaIncludeCategories()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFamilyDetail,
                ExpectedGroupServiceResults.GroupFriendsDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(includeCategories: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                DeepAssert.Contains(expectedGroup, result, propertiesToIgnore: ["GroupParticipants"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving a group detail by name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedByName()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(name: "Family");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving a group detail by partial name match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedByNamePartialMatch()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(namePartialMatch: "Fam");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details excluding a specific name.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedNotName()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFriendsDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(notName: "Family");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details excluding a partial name match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedNotNamePartialMatch()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFriendsDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(notNamePartialMatch: "Fam");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details by description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedByDescription()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFriendsDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(description: "Friends group");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details by partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedByDescriptionPartialMatch()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFriendsDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(descriptionPartialMatch: "Friends");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details excluding a specific description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedNotDescription()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFamilyDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(notDescription: "Friends group");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details excluding a partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedNotDescriptionPartialMatch()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFamilyDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(notDescriptionPartialMatch: "Friends");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details without a description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedWithoutDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(withDescription: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details that are not without a description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedNotWithoutDescription()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFamilyDetail,
                ExpectedGroupServiceResults.GroupFriendsDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(withDescription: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details by invitation ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedByInvitationId()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(invitationId: InvitationSeeds.InvitationJohnToDianaIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests the <see cref="IGetGroupsByCriteriaQueryHandler{T}"/> handler for retrieving group details excluding a specific invitation ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedNotInvitationId()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFriendsDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(notInvitationId: InvitationSeeds.InvitationJohnToDianaIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        #endregion

        #region Summary groups by ID

        /// <summary>
        /// Tests that the handler returns the correct group summary when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupSummary_WhenQueriedById()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetGroupByIdQueryHandler<GroupSummaryDto>>();
            var query = new GetGroupByIdQuery(GroupSeeds.GroupFamily.Id, includeUser: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedGroup, result);
        }

        #endregion

        #region List groups by ID

        /// <summary>
        /// Tests that the handler returns the correct group list when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedById()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetGroupByIdQueryHandler<GroupListDto>>();
            var query = new GetGroupByIdQuery(GroupSeeds.GroupFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedGroup, result, propertiesToIgnore: ["GroupParticipants"]);
        }

        #endregion

        #region Detail groups by ID

        /// <summary>
        /// Tests that the handler returns the correct group detail when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedById()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupByIdQueryHandler<GroupDetailDto>>();
            var query = new GetGroupByIdQuery(GroupSeeds.GroupFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedGroup, result, propertiesToIgnore: ["GroupParticipants"]);
        }

        #endregion

        #region Detail groups by multiple queries

        /// <summary>
        /// Tests that the handler returns the correct group detail when queried by description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedByNameAndNotNameAndDescription()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(name: "Family", notName: "Work", description: "Family group");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct group detail when queried by partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedByDescriptionPartialMatchAndNotName()
        {
            // Arrange
            var expectedGroups = new List<GroupDetailDto>
            {
                ExpectedGroupServiceResults.GroupFriendsDetail,
                ExpectedGroupServiceResults.GroupWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(descriptionPartialMatch: "group", notName: "Family");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            foreach (var expectedGroup in expectedGroups)
            {
                Assert.Contains(result, x => x.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct group detail when queried by name and description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedByNameAndDescription()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(name: "Family", description: "Family group");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct group detail when queried by name and partial description match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedByNameAndDescriptionPartialMatch()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupsByCriteriaQueryHandler<GroupDetailDto>>();
            var query = new GetGroupsByCriteriaQuery(name: "Family", descriptionPartialMatch: "group");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedGroup, result.FirstOrDefault(), propertiesToIgnore: ["GroupParticipants"]);
        }

        #endregion

        #region Related entities

        /// <summary>
        /// Tests that the handler returns the correct group detail when queried with users.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupList_WhenQueriedWithUser()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetGroupByIdQueryHandler<GroupListDto>>();
            var query = new GetGroupByIdQuery(id: GroupSeeds.GroupFamily.Id, includeUser: true);

            // Act
            var result = await handler.Handle(query);

            Assert.NotNull(result);
            DeepAssert.Equal(expectedGroup, result);
            foreach (var expectedUser in expectedGroup.GroupParticipants)
            {
                Assert.Contains(result.GroupParticipants, x => x.Id == expectedUser.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct group detail when queried with users.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedWithUser()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupByIdQueryHandler<GroupDetailDto>>();
            var query = new GetGroupByIdQuery(id: GroupSeeds.GroupFamily.Id, includeUser: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedGroup, result);
            foreach (var expectedUser in expectedGroup.GroupParticipants)
            {
                Assert.Contains(result.GroupParticipants, x => x.Id == expectedUser.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct group detail when queried with transactions. 
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedWithTransactions()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupByIdQueryHandler<GroupDetailDto>>();
            var query = new GetGroupByIdQuery(id: GroupSeeds.GroupFamily.Id, includeTransactions: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedGroup, result);
            foreach (var expectedUser in expectedGroup.GroupParticipants)
            {
                Assert.Contains(result.GroupParticipants, x => x.Id == expectedUser.Id);
                var actualTransactions = result.GroupParticipants.FirstOrDefault(x => x.Id == expectedUser.Id)!.Transactions;
                var expectedTransactions = expectedUser.Transactions;
                foreach (var expectedTransaction in expectedTransactions)
                {
                    Assert.Contains(actualTransactions, x => x.Id == expectedTransaction.Id);
                }
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct group detail when queried with categories.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnGroupDetail_WhenQueriedWithCategories()
        {
            // Arrange
            var expectedGroup = ExpectedGroupServiceResults.GroupFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetGroupByIdQueryHandler<GroupDetailDto>>();
            var query = new GetGroupByIdQuery(id: GroupSeeds.GroupFamily.Id, includeCategories: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedGroup, result);
            foreach (var expectedUser in expectedGroup.GroupParticipants)
            {
                Assert.Contains(result.GroupParticipants, x => x.Id == expectedUser.Id);
                var actualTransactions = result.GroupParticipants.FirstOrDefault(x => x.Id == expectedUser.Id)!.Transactions;
                var expectedTransactions = expectedUser.Transactions;
                foreach (var expectedTransaction in expectedTransactions)
                {
                    Assert.Contains(actualTransactions, x => x.Id == expectedTransaction.Id);
                    var actualTransaction = actualTransactions.FirstOrDefault(x => x.Id == expectedTransaction.Id);
                    Assert.NotNull(actualTransaction);
                    DeepAssert.Equal(expectedTransaction.Category, actualTransaction.Category);
                }
            }
        }

        #endregion
    }
}