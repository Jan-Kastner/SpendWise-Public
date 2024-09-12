using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests.QueryObjectTests
{
    public class GroupQueryObjectTests : UnitOfWorkTestsBase
    {
        public GroupQueryObjectTests(ITestOutputHelper output) : base(output)
        {
        }

        #region IdQuery Tests

        /// <summary>
        /// Verifies that querying a group by its ID 
        /// returns the correct entry from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithId_ShouldReturnCorrectGroup()
        {
            // Arrange
            var GroupId = GroupSeeds.GroupFamily.Id;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithId(GroupId));

            // Assert
            Assert.NotNull(groups);
            Assert.Single(groups);
            Assert.Equal(GroupId, groups.First().Id);
        }

        /// <summary>
        /// Verifies that querying groups by multiple IDs 
        /// returns all correct entries associated with those IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithId_ShouldReturnCorrectGroups()
        {
            // Arrange
            var groupId1 = GroupSeeds.GroupFamily.Id;
            var groupId2 = GroupSeeds.GroupFriends.Id;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.OrWithId(groupId1).OrWithId(groupId2));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.True(g.Id == groupId1 || g.Id == groupId2));
        }

        /// <summary>
        /// Verifies that querying groups excluding a specific ID 
        /// does not return the entry with that ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithId_ShouldExcludeGroup()
        {
            // Arrange
            var excludedGroupId = GroupSeeds.GroupFamily.Id;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.NotWithId(excludedGroupId));

            // Assert
            Assert.NotNull(groups);
            Assert.DoesNotContain(groups, g => g.Id == excludedGroupId);
        }

        #endregion

        #region NameQuery Tests

        /// <summary>
        /// Verifies that querying groups by name 
        /// returns all correct entries associated with that name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithName_ShouldReturnCorrectGroups()
        {
            // Arrange
            var GroupName = GroupSeeds.GroupFamily.Name;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithName(GroupName));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.Contains(GroupName, g.Name));
        }

        /// <summary>
        /// Verifies that querying groups by multiple names 
        /// returns all correct entries associated with those names.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithName_ShouldReturnCorrectGroups()
        {
            // Arrange
            var groupName1 = GroupSeeds.GroupFamily.Name;
            var groupName2 = GroupSeeds.GroupFriends.Name;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.OrWithName(groupName1).OrWithName(groupName2));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.True(g.Name.Contains(groupName1) || g.Name.Contains(groupName2)));
        }

        /// <summary>
        /// Verifies that querying groups excluding a specific name 
        /// does not return entries with that name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithName_ShouldExcludeGroups()
        {
            // Arrange
            var excludedGroupName = GroupSeeds.GroupFamily.Name;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.NotWithName(excludedGroupName));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.DoesNotContain(excludedGroupName, g.Name));
        }

        /// <summary>
        /// Verifies that querying groups by partial name match 
        /// returns all correct entries that contain the specified text in the name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithNamePartialMatch_ShouldReturnCorrectGroups()
        {
            // Arrange
            var partialName = "Fam";
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithNamePartialMatch(partialName));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.Contains(partialName, g.Name));
        }

        /// <summary>
        /// Verifies that querying groups by partial name match using an OR condition 
        /// returns all correct entries that contain either of the specified texts in the name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithNamePartialMatch_ShouldReturnCorrectGroups()
        {
            // Arrange
            var partialName1 = "Fam";
            var partialName2 = "Friend";
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.OrWithNamePartialMatch(partialName1).OrWithNamePartialMatch(partialName2));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.True(g.Name.Contains(partialName1) || g.Name.Contains(partialName2)));
        }

        /// <summary>
        /// Verifies that querying groups with a NOT condition by partial name match 
        /// excludes all groups containing the specified text in the name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithNamePartialMatch_ShouldExcludeGroups()
        {
            // Arrange
            var excludedText = "Fam"; // Adjust as needed for testing
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.NotWithNamePartialMatch(excludedText));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.DoesNotContain(excludedText, g.Name));
        }

        #endregion

        #region DescriptionQuery Tests

        /// <summary>
        /// Verifies that querying groups by description 
        /// returns all correct entries associated with that description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDescription_ShouldReturnCorrectGroups()
        {
            // Arrange
            var groupDescription = GroupSeeds.GroupFamily.Description;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithDescription(groupDescription));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.NotNull(g.Description);
                Assert.NotNull(groupDescription);
                Assert.Contains(groupDescription, g.Description);
            });
        }

        /// <summary>
        /// Verifies that querying groups by description using an OR condition 
        /// returns all correct entries that contain either of the specified descriptions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDescription_ShouldReturnCorrectGroups()
        {
            // Arrange
            var groupDescription1 = GroupSeeds.GroupFamily.Description;
            var groupDescription2 = "Friends group";
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.OrWithDescription(groupDescription1).OrWithDescription(groupDescription2));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.NotNull(g.Description);
                Assert.NotNull(groupDescription1);
                Assert.NotNull(groupDescription2);
                Assert.True(g.Description.Contains(groupDescription1) || g.Description.Contains(groupDescription2));
            });
        }

        /// <summary>
        /// Verifies that querying groups by partial description match 
        /// returns all correct entries that contain the specified text in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDescriptionPartialMatch_ShouldReturnCorrectGroups()
        {
            // Arrange
            var partialDescription = "group";
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithDescriptionPartialMatch(partialDescription));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.NotNull(g.Description);
                Assert.Contains(partialDescription, g.Description);
            });
        }

        /// <summary>
        /// Verifies that querying groups by partial description match using an OR condition 
        /// returns all correct entries that contain either of the specified texts in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDescriptionPartialMatch_ShouldReturnCorrectGroups()
        {
            // Arrange
            var partialDescription1 = "group";
            var partialDescription2 = "Work";
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.OrWithDescriptionPartialMatch(partialDescription1).OrWithDescriptionPartialMatch(partialDescription2));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.NotNull(g.Description);
                Assert.True(g.Description.Contains(partialDescription1) || g.Description.Contains(partialDescription2));
            });
        }

        /// <summary>
        /// Verifies that querying groups with a NOT condition by description 
        /// excludes all groups containing the specified description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithDescription_ShouldExcludeGroups()
        {
            // Arrange
            var groupDescription = GroupSeeds.GroupFamily.Description;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.NotWithDescription(groupDescription));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.NotNull(groupDescription);
                Assert.DoesNotContain(groupDescription, g.Description);
            });
        }

        /// <summary>
        /// Verifies that querying groups with a NOT condition by partial description match 
        /// excludes all groups containing the specified text in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithDescriptionPartialMatch_ShouldExcludeGroups()
        {
            // Arrange
            var excludedText = "group"; // Adjust as needed for testing
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.NotWithDescriptionPartialMatch(excludedText));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.NotNull(g.Description);
                Assert.DoesNotContain(excludedText, g.Description);
            });
        }

        /// <summary>
        /// Verifies that querying groups without a description 
        /// returns all groups that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutDescription_ShouldReturnGroupsWithNullDescription()
        {
            // Arrange
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithoutDescription());

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.Null(g.Description);
            });
        }

        /// <summary>
        /// Verifies that querying groups without a description using an OR condition 
        /// returns all groups that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutDescription_ShouldReturnGroupsWithNullDescription()
        {
            // Arrange
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.OrWithoutDescription());

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.Null(g.Description);
            });
        }

        /// <summary>
        /// Verifies that querying groups with a NOT condition for null description 
        /// excludes all groups that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutDescription_ShouldExcludeGroupsWithNullDescription()
        {
            // Arrange
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.NotWithoutDescription());

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.NotNull(g.Description);
            });
        }

        #endregion

        #region GroupUserQuery Tests

        /// <summary>
        /// Verifies that querying groups by group user ID 
        /// returns all correct entries associated with that group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithGroupUser_ShouldReturnCorrectGroups()
        {
            // Arrange
            var groupUser = GroupUserSeeds.GroupUserJohnInFamily;
            var queryObject = new GroupQueryObject();

            //Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithGroupUser(groupUser.Id));

            // Assert
            Assert.NotNull(groups);
            Assert.Single(groups);
            Assert.Equal(groupUser.GroupId, groups.First().Id);
        }

        /// <summary>
        /// Verifies that querying groups by multiple group user IDs using an OR condition 
        /// returns all correct entries associated with either of the specified group users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithGroupUser_ShouldReturnCorrectGroups()
        {
            // Arrange
            var groupUser1 = GroupUserSeeds.GroupUserJohnInFamily;
            var groupUser2 = GroupUserSeeds.GroupUserCharlieInFamily;
            var queryObject = new GroupQueryObject();

            //Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.OrWithGroupUser(groupUser1.Id).OrWithGroupUser(groupUser2.Id));

            // Assert
            Assert.NotNull(groups);
            Assert.All(new[] { groupUser1, groupUser2 }, gu =>
                Assert.Contains(groups, g => g.Id == gu.GroupId));
        }

        /// <summary>
        /// Verifies that querying groups with a NOT condition by group user ID 
        /// excludes all groups containing the specified group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithGroupUser_ShouldExcludeGroups()
        {
            // Arrange
            var groupUser = GroupUserSeeds.GroupUserJohnInFamily;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.NotWithGroupUser(groupUser.Id));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.NotEqual(groupUser.GroupId, g.Id));
        }

        #endregion

        #region InvitationQuery Tests

        /// <summary>
        /// Verifies that querying groups with a specific invitation 
        /// returns all entries that have that invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithInvitation_ShouldReturnGroupsWithInvitation()
        {
            // Arrange
            var invitation = InvitationSeeds.InvitationDianaToCharlieIntoFamily;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithInvitation(invitation.Id));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.Equal(invitation.GroupId, g.Id));
        }

        /// <summary>
        /// Verifies that querying groups with multiple invitations 
        /// returns all entries that have any of those invitations.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithInvitation_ShouldReturnGroupsWithInvitation()
        {
            // Arrange
            var invitation1 = InvitationSeeds.InvitationDianaToCharlieIntoFamily;
            var invitation2 = InvitationSeeds.InvitationJohnToDianaIntoWork;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.OrWithInvitation(invitation1.Id).OrWithInvitation(invitation2.Id));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.True(g.Id == invitation1.GroupId || g.Id == invitation2.GroupId);
            });
        }

        /// <summary>
        /// Verifies that querying groups excluding a specific invitation 
        /// does not return entries with that invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithInvitation_ShouldExcludeGroupsWithInvitation()
        {
            // Arrange
            var invitation = InvitationSeeds.InvitationDianaToCharlieIntoFamily;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.NotWithInvitation(invitation.Id));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g => Assert.NotEqual(invitation.GroupId, g.Id));
        }

        #endregion 

        #region Complex Tests

        /// <summary>
        /// Verifies that querying groups by ID and Name using AND condition
        /// returns entries that match both criteria.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithIdAndName_ShouldReturnCorrectEntry()
        {
            // Arrange
            var groupId = GroupSeeds.GroupFamily.Id;
            var groupName = GroupSeeds.GroupFamily.Name;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithId(groupId).WithName(groupName));

            // Assert
            Assert.NotNull(groups);
            Assert.Single(groups);
            Assert.Equal(groupId, groups.First().Id);
            Assert.Equal(groupName, groups.First().Name);
        }

        /// <summary>
        /// Verifies that querying groups by Name and excluding a specific ID using NOT condition
        /// returns entries that match the name but exclude the specified ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithNameNotWithId_ShouldReturnCorrectEntries()
        {
            // Arrange
            var groupName = GroupSeeds.GroupFamily.Name;
            var excludedGroupId = GroupSeeds.GroupWork.Id;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithName(groupName).NotWithId(excludedGroupId));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                Assert.Equal(groupName, g.Name);
                Assert.NotEqual(excludedGroupId, g.Id);
            });
        }

        /// <summary>
        /// Verifies that querying groups by Description or Name using OR condition
        /// returns entries that match either criterion.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDescriptionOrName_ShouldReturnCorrectEntries()
        {
            // Arrange
            var groupDescription = GroupSeeds.GroupFamily.Description;
            var groupName = GroupSeeds.GroupFriends.Name;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.OrWithDescription(groupDescription).OrWithName(groupName));

            // Assert
            Assert.NotNull(groups);
            Assert.NotEmpty(groups);
            Assert.All(groups, g => Assert.True(g.Description == groupDescription || g.Name == groupName));
        }

        /// <summary>
        /// Verifies that querying groups by Name and Description using AND 
        /// and excluding a specific ID using NOT condition works together.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithNameAndDescriptionNotWithId_ShouldReturnCorrectEntries()
        {
            // Arrange
            var groupName = GroupSeeds.GroupFamily.Name;
            var groupDescription = GroupSeeds.GroupFamily.Description;
            var excludedGroupId = GroupSeeds.GroupWork.Id;
            var queryObject = new GroupQueryObject();

            // Act
            var groups = await _unitOfWork.Repository<GroupEntity, GroupDto>()
                .GetAsync(queryObject.WithName(groupName)
                                     .WithDescription(groupDescription)
                                     .NotWithId(excludedGroupId));

            // Assert
            Assert.NotNull(groups);
            Assert.All(groups, g =>
            {
                bool isNameMatch = g.Name == groupName;
                bool isDescriptionMatch = g.Description == groupDescription;
                bool isIdMatch = g.Id == excludedGroupId;

                Assert.True(isNameMatch && isDescriptionMatch && !isIdMatch);
            });
        }

        #endregion
    }
}