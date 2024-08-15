using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for operations related to limits using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkLimitTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkLimitTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public UnitOfWorkLimitTests(ITestOutputHelper output) : base(output)
        {
        }

        // ====================================
        // CRUD Operations Tests
        // ====================================

        /// <summary>
        /// Tests if inserting a new limit with valid data correctly adds the limit to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertLimit_AddsLimitToDatabase()
        {
            // Arrange
            var newLimitDto = new LimitDto
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserAliceBrownInWork.Id,
                Amount = 1500m,
                NoticeType = 2,

            };

            // Act
            await _unitOfWork.Limits.InsertAsync(newLimitDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var limitInDb = await _unitOfWork.Limits.GetByIdAsync(newLimitDto.Id);
            Assert.NotNull(limitInDb);
            DeepAssert.Equal(newLimitDto, limitInDb);
        }

        /// <summary>
        /// Tests if fetching a limit by an existing ID returns the correct limit.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetLimitById_ReturnsCorrectLimit()
        {
            // Arrange
            var expectedLimitDto = _mapper.Map<LimitDto>(LimitSeeds.LimitAdminFamily);

            // Act
            var fetchedLimitDto = await _unitOfWork.Limits.GetByIdAsync(expectedLimitDto.Id);

            // Assert
            Assert.NotNull(fetchedLimitDto);
            DeepAssert.Equal(expectedLimitDto, fetchedLimitDto);
        }

        /// <summary>
        /// Tests if updating a limit with valid data correctly updates the limit in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_UpdatesLimitInDatabase()
        {
            // Arrange
            var existingLimitDto = _mapper.Map<LimitDto>(LimitSeeds.LimitAdminFamily);

            var updatedLimitDto = existingLimitDto with
            {
                Amount = 2000m,
                NoticeType = 1
            };

            // Act
            await _unitOfWork.Limits.UpdateAsync(updatedLimitDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultLimitDto = await _unitOfWork.Limits.GetByIdAsync(updatedLimitDto.Id);
            Assert.NotNull(resultLimitDto);
            DeepAssert.Equal(updatedLimitDto, resultLimitDto);
        }

        /// <summary>
        /// Tests if deleting a limit by an existing ID correctly removes the limit from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteLimit_RemovesLimitFromDatabase()
        {
            // Arrange
            var limitDto = _mapper.Map<LimitDto>(LimitSeeds.LimitAdminFamily);

            // Act
            await _unitOfWork.Limits.DeleteAsync(limitDto.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedLimit = await _unitOfWork.Limits.GetByIdAsync(limitDto.Id);
            Assert.Null(deletedLimit);
        }
    }
}
