using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Tests.Helpers;
using SpendWise.DAL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Test class for testing repository methods related to groups.
    /// </summary>
    public class GroupRepositoryTests : RepositoryTestsBase
    {
        private readonly IRepository<GroupEntity, GroupDto> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the <see cref="GroupRepositoryTests"/> class.
        /// Initializes the instance with necessary services.
        /// </summary>
        /// <param name="output">Provides output capabilities for test methods.</param>
        public GroupRepositoryTests(ITestOutputHelper output) : base(output)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<GroupEntity, GroupDto>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Tests whether inserting a new group into the database successfully adds the group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertGroup_AddsGroupToDatabase()
        {
            // Arrange
            var newGroupDto = new GroupDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Group",
                Description = "Test group description"
            };

            // Act
            var insertedGroupDto = await _repository.InsertAsync(newGroupDto);

            // Assert
            Assert.NotNull(insertedGroupDto);
            DeepAssert.Equal(newGroupDto, insertedGroupDto);
        }

        /// <summary>
        /// Tests whether retrieving a group by its ID returns the correct group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetGroupById_ReturnsCorrectGroup()
        {
            // Arrange
            var expectedGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            var fetchedGroupDto = await _repository.GetByIdAsync(expectedGroupDto.Id);

            // Assert
            Assert.NotNull(fetchedGroupDto);
            DeepAssert.Equal(expectedGroupDto, fetchedGroupDto);
        }

        /// <summary>
        /// Tests whether updating a group in the database successfully updates the existing group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateGroup_UpdatesGroupInDatabase()
        {
            // Arrange
            var existingGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            var updatedGroupDto = new GroupDto
            {
                Id = existingGroupDto.Id,
                Name = "Updated Group",
                Description = "Updated description"
            };

            // Act
            var resultGroupDto = await _repository.UpdateAsync(updatedGroupDto);

            // Assert
            Assert.NotNull(resultGroupDto);
            DeepAssert.Equal(updatedGroupDto, resultGroupDto);
            Assert.Equal(existingGroupDto.Id, resultGroupDto.Id);
        }

        /// <summary>
        /// Tests whether deleting a group from the database successfully removes the existing group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteGroup_RemovesGroupFromDatabase()
        {
            // Arrange
            var groupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            await _repository.DeleteAsync(groupDto.Id);
            var deletedGroup = await _repository.GetByIdAsync(groupDto.Id);

            // Assert
            Assert.Null(deletedGroup);

            var totalCountAfterDelete = await _repository.Get().CountAsync();
            var totalCountBeforeDelete = totalCountAfterDelete + 1;
            Assert.Equal(totalCountBeforeDelete, totalCountAfterDelete + 1);
        }
    }
}
