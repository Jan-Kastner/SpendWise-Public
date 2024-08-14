using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SpendWise.DAL.UnitOfWork;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    public class UnitOfWorkGroupTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkCategoryTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public UnitOfWorkGroupTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task InsertGroup_AddsGroupToDatabase()
        {
            // Arrange
            var newGroup = new GroupDto
            {
                Id = Guid.NewGuid(),
                Name = "Test Group",
                Description = "Test group description"
            };

            // Act
            await _unitOfWork.Groups.InsertAsync(newGroup);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var groupInDb = await _unitOfWork.Groups.GetByIdAsync(newGroup.Id);
            Assert.NotNull(groupInDb);
            DeepAssert.Equal(newGroup, groupInDb);
        }

        [Fact]
        public async Task GetGroupById_ReturnsCorrectGroup()
        {
            // Arrange
            var expectedGroupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            var fetchedGroupDto = await _unitOfWork.Groups.GetByIdAsync(expectedGroupDto.Id);

            // Assert
            Assert.NotNull(fetchedGroupDto);
            DeepAssert.Equal(expectedGroupDto, fetchedGroupDto);
        }

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
            await _unitOfWork.Groups.UpdateAsync(updatedGroupDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultGroupDto = await _unitOfWork.Groups.GetByIdAsync(updatedGroupDto.Id);
            Assert.NotNull(resultGroupDto);
            DeepAssert.Equal(updatedGroupDto, resultGroupDto);
        }

        [Fact]
        public async Task DeleteGroup_RemovesGroupFromDatabase()
        {
            // Arrange
            var groupDto = _mapper.Map<GroupDto>(GroupSeeds.GroupFamily);

            // Act
            await _unitOfWork.Groups.DeleteAsync(groupDto.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedGroup = await _unitOfWork.Groups.GetByIdAsync(groupDto.Id);
            Assert.Null(deletedGroup);
        }
    }
}
