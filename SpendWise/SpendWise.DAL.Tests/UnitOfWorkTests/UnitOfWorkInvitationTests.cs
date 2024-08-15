using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for operations related to invitations using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkInvitationTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkInvitationTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public UnitOfWorkInvitationTests(ITestOutputHelper output) : base(output)
        {
        }

        // ====================================
        // CRUD Operations Tests
        // ====================================

        /// <summary>
        /// Tests if inserting a new invitation with valid data correctly adds the invitation to the database.
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
            await _unitOfWork.Invitations.InsertAsync(newInvitationDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var invitationInDb = await _unitOfWork.Invitations.GetByIdAsync(newInvitationDto.Id);
            Assert.NotNull(invitationInDb);
            DeepAssert.Equal(newInvitationDto, invitationInDb);
        }

        /// <summary>
        /// Tests if fetching an invitation by an existing ID returns the correct invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetInvitationById_ReturnsCorrectInvitation()
        {
            // Arrange
            var expectedInvitationDto = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationAdminToJohnDoeIntoFamily);

            // Act
            var fetchedInvitationDto = await _unitOfWork.Invitations.GetByIdAsync(expectedInvitationDto.Id);

            // Assert
            Assert.NotNull(fetchedInvitationDto);
            DeepAssert.Equal(expectedInvitationDto, fetchedInvitationDto);
        }

        /// <summary>
        /// Tests if updating an invitation with valid data correctly updates the invitation in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_UpdatesInvitationInDatabase()
        {
            // Arrange
            var existingInvitationDto = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationAdminToJohnDoeIntoFamily);

            var updatedInvitationDto = existingInvitationDto with
            {
                ResponseDate = DateTime.UtcNow,
                IsAccepted = true
            };

            // Act
            await _unitOfWork.Invitations.UpdateAsync(updatedInvitationDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultInvitationDto = await _unitOfWork.Invitations.GetByIdAsync(updatedInvitationDto.Id);
            Assert.NotNull(resultInvitationDto);
            DeepAssert.Equal(updatedInvitationDto, resultInvitationDto);
        }

        /// <summary>
        /// Tests if deleting an invitation by an existing ID correctly removes the invitation from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteInvitation_RemovesInvitationFromDatabase()
        {
            // Arrange
            var invitationDto = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationAdminToJohnDoeIntoFamily);

            // Act
            await _unitOfWork.Invitations.DeleteAsync(invitationDto.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedInvitation = await _unitOfWork.Invitations.GetByIdAsync(invitationDto.Id);
            Assert.Null(deletedInvitation);
        }
    }
}
