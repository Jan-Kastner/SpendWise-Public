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
    /// Test class for testing repository methods related to invitations.
    /// </summary>
    public class InvitationRepositoryTests : RepositoryTestsBase
    {
        private readonly IRepository<InvitationEntity, InvitationDto> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the <see cref="InvitationRepositoryTests"/> class.
        /// Initializes the instance with necessary services.
        /// </summary>
        /// <param name="output">Provides output capabilities for test methods.</param>
        public InvitationRepositoryTests(ITestOutputHelper output) : base(output)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<InvitationEntity, InvitationDto>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Tests whether inserting a new invitation into the database successfully adds the invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertInvitation_AddsInvitationToDatabase()
        {
            // Arrange
            var newInvitationDto = new InvitationDto
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserAdmin.Id,
                ReceiverId = UserSeeds.UserJohnDoe.Id,
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = DateTime.UtcNow,
                ResponseDate = null,
                IsAccepted = null
            };

            // Act
            var insertedInvitationDto = await _repository.InsertAsync(newInvitationDto);

            // Assert
            Assert.NotNull(insertedInvitationDto);
            DeepAssert.Equal(newInvitationDto, insertedInvitationDto);
        }

        /// <summary>
        /// Tests whether retrieving an invitation by its ID returns the correct invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetInvitationById_ReturnsCorrectInvitation()
        {
            // Arrange
            var expectedInvitationDto = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationAdminToJohnDoeIntoFamily);
            // Act
            var fetchedInvitationDto = await _repository.GetByIdAsync(expectedInvitationDto.Id);

            // Assert
            Assert.NotNull(fetchedInvitationDto);
            DeepAssert.Equal(expectedInvitationDto, fetchedInvitationDto);
        }

        /// <summary>
        /// Tests whether updating an invitation in the database successfully updates the existing invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_UpdatesInvitationInDatabase()
        {
            // Arrange
            var existingInvitationDto = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationAdminToJohnDoeIntoFamily);

            var updatedInvitationDto = new InvitationDto
            {
                Id = existingInvitationDto.Id,
                SenderId = existingInvitationDto.SenderId,
                ReceiverId = existingInvitationDto.ReceiverId,
                GroupId = existingInvitationDto.GroupId,
                SentDate = existingInvitationDto.SentDate,
                ResponseDate = DateTime.UtcNow,
                IsAccepted = true
            };

            // Act
            var resultInvitationDto = await _repository.UpdateAsync(updatedInvitationDto);

            // Assert
            Assert.NotNull(resultInvitationDto);
            DeepAssert.Equal(updatedInvitationDto, resultInvitationDto);
            Assert.Equal(existingInvitationDto.Id, resultInvitationDto.Id);
        }

        /// <summary>
        /// Tests whether deleting an invitation from the database successfully removes the existing invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteInvitation_RemovesInvitationFromDatabase()
        {
            // Arrange
            var invitationDto = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationJohnDoeToAdminIntoFriends);

            // Act
            await _repository.DeleteAsync(invitationDto.Id);
            var deletedInvitation = await _repository.GetByIdAsync(invitationDto.Id);

            // Assert
            Assert.Null(deletedInvitation);

            var totalCountAfterDelete = await _repository.Get().CountAsync();
            var totalCountBeforeDelete = totalCountAfterDelete + 1;
            Assert.Equal(totalCountBeforeDelete, totalCountAfterDelete + 1);
        }
    }
}
