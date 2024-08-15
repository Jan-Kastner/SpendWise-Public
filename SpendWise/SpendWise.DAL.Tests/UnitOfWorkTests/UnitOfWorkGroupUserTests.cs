using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for operations related to group-user relationships using the
    /// Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkGroupUserTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkGroupUserTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public UnitOfWorkGroupUserTests(ITestOutputHelper output) : base(output)
        {
        }

        // ====================================
        // CRUD Operations Tests
        // ====================================

        /// <summary>
        /// Tests if inserting a new group-user relationship with valid data correctly adds the relationship to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertGroupUser_AddsGroupUserToDatabase()
        {
            // Arrange
            var newGroupUserDto = new GroupUserDto
            {
                Id = Guid.NewGuid(),
                UserId = UserSeeds.UserAliceBrown.Id,
                GroupId = GroupSeeds.GroupWork.Id,
                LimitId = null
            };

            // Act
            await _unitOfWork.GroupUsers.InsertAsync(newGroupUserDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var groupUserInDb = await _unitOfWork.GroupUsers.GetByIdAsync(newGroupUserDto.Id);
            Assert.NotNull(groupUserInDb);
            DeepAssert.Equal(newGroupUserDto, groupUserInDb);
        }

        /// <summary>
        /// Tests if fetching a group-user relationship by an existing ID returns the correct relationship.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroupUserById_ReturnsCorrectGroupUser()
        {
            // Arrange
            var expectedGroupUserDto = _mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserJohnDoeInFamily);

            // Act
            var fetchedGroupUserDto = await _unitOfWork.GroupUsers.GetByIdAsync(expectedGroupUserDto.Id);

            // Assert
            Assert.NotNull(fetchedGroupUserDto);
            DeepAssert.Equal(expectedGroupUserDto, fetchedGroupUserDto);
        }

        /// <summary>
        /// Tests if updating a group-user relationship with valid data correctly updates the relationship in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroupUser_UpdatesGroupUserInDatabase()
        {
            // Arrange
            var existingGroupUserDto = _mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserJohnDoeInFamily);

            var updatedGroupUserDto = new GroupUserDto
            {
                Id = existingGroupUserDto.Id,
                UserId = UserSeeds.UserJohnDoe.Id,
                GroupId = GroupSeeds.GroupFriends.Id, // Change group
                LimitId = null
            };

            // Act
            await _unitOfWork.GroupUsers.UpdateAsync(updatedGroupUserDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultGroupUserDto = await _unitOfWork.GroupUsers.GetByIdAsync(updatedGroupUserDto.Id);
            Assert.NotNull(resultGroupUserDto);
            DeepAssert.Equal(updatedGroupUserDto, resultGroupUserDto);
        }

        /// <summary>
        /// Tests if deleting a group-user relationship by an existing ID correctly removes the relationship from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroupUser_RemovesGroupUserFromDatabase()
        {
            // Arrange
            var groupUserDto = _mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserJohnDoeInFamily);

            // Act
            await _unitOfWork.GroupUsers.DeleteAsync(groupUserDto.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroupUser = await _unitOfWork.GroupUsers.GetByIdAsync(groupUserDto.Id);
            Assert.Null(deletedGroupUser);
        }
    }
}
