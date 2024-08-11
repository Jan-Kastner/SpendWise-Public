using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Tests.Helpers;
using SpendWise.DAL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SpendWise.DAL.Repositories;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Test class for testing repository methods related to group-user relationships.
    /// </summary>
    public class GroupUserRepositoryTests : RepositoryTestsBase
    {
        private readonly IRepository<GroupUserEntity, GroupUserDto> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the <see cref="GroupUserRepositoryTests"/> class.
        /// Initializes the instance with necessary services.
        /// </summary>
        /// <param name="output">Provides output capabilities for test methods.</param>
        public GroupUserRepositoryTests(ITestOutputHelper output) : base(output)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<GroupUserEntity, GroupUserDto>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Tests whether inserting a new group-user relationship into the database successfully adds it.
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
            var insertedGroupUserDto = await _repository.InsertAsync(newGroupUserDto);

            // Assert
            Assert.NotNull(insertedGroupUserDto);
            DeepAssert.Equal(newGroupUserDto, insertedGroupUserDto);
        }

        /// <summary>
        /// Tests whether retrieving a group-user relationship by its ID returns the correct relationship.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroupUserById_ReturnsCorrectGroupUser()
        {
            // Arrange
            var expectedGroupUserDto = _mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserJohnDoeInFamily);
            // Act
            var fetchedGroupUserDto = await _repository.GetByIdAsync(expectedGroupUserDto.Id);

            // Assert
            Assert.NotNull(fetchedGroupUserDto);
            DeepAssert.Equal(expectedGroupUserDto, fetchedGroupUserDto);
        }

        /// <summary>
        /// Tests whether updating a group-user relationship in the database successfully updates the existing relationship.
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
            var resultGroupUserDto = await _repository.UpdateAsync(updatedGroupUserDto);

            // Assert
            Assert.NotNull(resultGroupUserDto);
            DeepAssert.Equal(updatedGroupUserDto, resultGroupUserDto);
            Assert.Equal(existingGroupUserDto.Id, resultGroupUserDto.Id);
        }

        /// <summary>
        /// Tests whether deleting a group-user relationship from the database successfully removes it.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroupUser_RemovesGroupUserFromDatabase()
        {
            // Arrange
            var groupUserDto = _mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserJohnDoeInFamily);

            // Act
            await _repository.DeleteAsync(groupUserDto.Id);
            var deletedGroupUser = await _repository.GetByIdAsync(groupUserDto.Id);

            // Assert
            Assert.Null(deletedGroupUser);

            var totalCountAfterDelete = await _repository.Get().CountAsync();
            var totalCountBeforeDelete = totalCountAfterDelete + 1;
            Assert.Equal(totalCountBeforeDelete, totalCountAfterDelete + 1);
        }
    }
}
