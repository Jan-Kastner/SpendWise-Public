using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Tests.UnitOfWorkTests
{
    public class UnitOfWorkLimitTests : UnitOfWorkTestsBase
    {
        public UnitOfWorkLimitTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        [Fact]
        public async Task AddLimit_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var limitToAdd = new LimitDto
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserJohnInFamily.Id,
                Amount = 1500m,
                NoticeType = NoticeType.SMS,
            };

            // Act
            await _unitOfWork.Repository<LimitEntity, LimitDto>().InsertAsync(limitToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(limitToAdd.Id);
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(limitToAdd, actualLimit);
        }

        [Fact]
        public async Task FetchLimitById_ExistingId_ReturnsExpectedLimit()
        {
            // Arrange
            var expectedLimit = _mapper.Map<LimitDto>(LimitSeeds.LimitCharlieFamily);

            // Act
            var actualLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(expectedLimit.Id);

            // Assert
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(expectedLimit, actualLimit);
        }

        [Fact]
        public async Task UpdateLimit_ValidData_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingLimit = _mapper.Map<LimitDto>(LimitSeeds.LimitCharlieFamily);
            var updatedLimit = existingLimit with
            {
                Amount = 2000m,
                NoticeType = NoticeType.SMS,
            };

            // Act
            await _unitOfWork.Repository<LimitEntity, LimitDto>().UpdateAsync(updatedLimit);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(updatedLimit.Id);
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(updatedLimit, actualLimit);
        }

        [Fact]
        public async Task DeleteLimit_ExistingId_SuccessfullyRemovesLimit()
        {
            // Arrange
            var limitToDelete = _mapper.Map<LimitDto>(LimitSeeds.LimitCharlieFamily);

            // Act
            await _unitOfWork.Repository<LimitEntity, LimitDto>().DeleteAsync(limitToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedLimit = await _unitOfWork.Repository<LimitEntity, LimitDto>().GetByIdAsync(limitToDelete.Id);
            Assert.Null(deletedLimit);
        }

        #endregion
    }
}
