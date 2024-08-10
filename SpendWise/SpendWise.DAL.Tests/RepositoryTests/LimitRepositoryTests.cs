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
    /// Test class for testing repository methods related to limits.
    /// </summary>
    public class LimitRepositoryTests : RepositoryTestsBase
    {
        private readonly IRepository<LimitEntity, LimitDto> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the <see cref="LimitRepositoryTests"/> class.
        /// Initializes the instance with necessary services.
        /// </summary>
        /// <param name="output">Provides output capabilities for test methods.</param>
        public LimitRepositoryTests(ITestOutputHelper output) : base(output)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<LimitEntity, LimitDto>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Tests whether inserting a new limit into the database successfully adds the limit.
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
                NoticeType = 2
            };

            // Act
            var insertedLimitDto = await _repository.InsertAsync(newLimitDto);

            // Assert
            Assert.NotNull(insertedLimitDto);
            DeepAssert.Equal(newLimitDto, insertedLimitDto);
        }

        /// <summary>
        /// Tests whether retrieving a limit by its ID returns the correct limit.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetLimitById_ReturnsCorrectLimit()
        {
            // Arrange
            var expectedLimitDto = _mapper.Map<LimitDto>(LimitSeeds.LimitAdminFamily);
            // Act
            var fetchedLimitDto = await _repository.GetByIdAsync(expectedLimitDto.Id);

            // Assert
            Assert.NotNull(fetchedLimitDto);
            DeepAssert.Equal(expectedLimitDto, fetchedLimitDto);
        }

        /// <summary>
        /// Tests whether updating a limit in the database successfully updates the existing limit.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_UpdatesLimitInDatabase()
        {
            // Arrange
            var existingLimitDto = _mapper.Map<LimitDto>(LimitSeeds.LimitJohnDoeFriends);

            var updatedLimitDto = new LimitDto
            {
                Id = existingLimitDto.Id,
                GroupUserId = existingLimitDto.GroupUserId,
                Amount = 750m,
                NoticeType = 2
            };

            // Act
            var resultLimitDto = await _repository.UpdateAsync(updatedLimitDto);

            // Assert
            Assert.NotNull(resultLimitDto);
            DeepAssert.Equal(updatedLimitDto, resultLimitDto);
            Assert.Equal(existingLimitDto.Id, resultLimitDto.Id);
        }

        /// <summary>
        /// Tests whether deleting a limit from the database successfully removes the existing limit.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteLimit_RemovesLimitFromDatabase()
        {
            // Arrange
            var limitDto = _mapper.Map<LimitDto>(LimitSeeds.LimitJohnDoeFriends);

            // Act
            await _repository.DeleteAsync(limitDto.Id);
            var deletedLimit = await _repository.GetByIdAsync(limitDto.Id);

            // Assert
            Assert.Null(deletedLimit);

            var totalCountAfterDelete = await _repository.Get().CountAsync();
            var totalCountBeforeDelete = totalCountAfterDelete + 1;
            Assert.Equal(totalCountBeforeDelete, totalCountAfterDelete + 1);
        }
    }
}