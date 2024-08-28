using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.Tests.UnitOfWorkTests
{
    public class UnitOfWorkInvitationTests : UnitOfWorkTestsBase
    {
        public UnitOfWorkInvitationTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Unit tests for CRUD (Create, Read, Update, Delete) operations on the Invitation entity using the Unit of Work pattern.
        /// These tests ensure that basic data manipulation tasks are correctly implemented and persist changes in the database as expected.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that a new invitation with valid data is successfully added to the database and persists correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddInvitation_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var invitationToAdd = new InvitationDto
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserJohnDoe.Id,
                ReceiverId = UserSeeds.UserAliceSmith.Id,
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = DateTime.UtcNow,
                ResponseDate = null,
                IsAccepted = null
            };

            // Act
            await _unitOfWork.Repository<InvitationEntity, InvitationDto>().InsertAsync(invitationToAdd);
            await _unitOfWork.SaveChangesAsync(); // Persist changes

            // Assert
            var actualInvitation = await _unitOfWork.Repository<InvitationEntity, InvitationDto>().GetByIdAsync(invitationToAdd.Id);
            Assert.NotNull(actualInvitation); // Ensure the invitation was added
            DeepAssert.Equal(invitationToAdd, actualInvitation); // Verify that the added invitation matches the input data
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching an invitation by its ID returns the expected invitation if it exists in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchInvitationById_ExistingId_ReturnsExpectedInvitation()
        {
            // Arrange
            var expectedInvitation = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationDianaToCharlieIntoFamily);

            // Act
            var actualInvitation = await _unitOfWork.Repository<InvitationEntity, InvitationDto>().GetByIdAsync(expectedInvitation.Id);

            // Assert
            Assert.NotNull(actualInvitation); // Ensure the invitation was found
            DeepAssert.Equal(expectedInvitation, actualInvitation); // Verify that the fetched invitation matches the expected invitation
        }

        [Fact]
        /// <summary>
        /// Verifies that updating an existing invitation with valid data successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_ValidData_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingInvitation = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationDianaToCharlieIntoFamily);
            var updatedInvitation = existingInvitation with
            {
                ResponseDate = DateTime.UtcNow,
                IsAccepted = true
            };

            // Act
            await _unitOfWork.Repository<InvitationEntity, InvitationDto>().UpdateAsync(updatedInvitation);
            await _unitOfWork.SaveChangesAsync(); // Persist changes

            // Assert
            var actualInvitation = await _unitOfWork.Repository<InvitationEntity, InvitationDto>().GetByIdAsync(updatedInvitation.Id);
            Assert.NotNull(actualInvitation); // Ensure the invitation was updated
            DeepAssert.Equal(updatedInvitation, actualInvitation); // Verify that the updated invitation matches the new data
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting an existing invitation by its ID successfully removes the invitation from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteInvitation_ExistingId_SuccessfullyRemovesInvitation()
        {
            // Arrange
            var invitationToDelete = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationDianaToCharlieIntoFamily);

            // Act
            await _unitOfWork.Repository<InvitationEntity, InvitationDto>().DeleteAsync(invitationToDelete.Id);
            await _unitOfWork.SaveChangesAsync(); // Persist changes

            // Assert
            var deletedInvitation = await _unitOfWork.Repository<InvitationEntity, InvitationDto>().GetByIdAsync(invitationToDelete.Id);
            Assert.Null(deletedInvitation); // Ensure the invitation was removed
        }

        #endregion


        #region Error Handling Tests

        /// <summary>
        /// Unit tests for error handling scenarios in the Invitation operations. 
        /// These tests verify that appropriate exceptions are thrown when invalid operations are attempted.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that adding an invitation with an invalid SenderId throws a ForeignDbUpdateException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddInvitation_WithInvalidSenderId_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidInvitation = new InvitationDto
            {
                Id = Guid.NewGuid(),
                SenderId = Guid.NewGuid(), // Invalid SenderId
                ReceiverId = UserSeeds.UserCharlieBlack.Id,
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = DateTime.UtcNow,
                ResponseDate = null,
                IsAccepted = null
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _unitOfWork.Repository<InvitationEntity, InvitationDto>().InsertAsync(invalidInvitation);
                await _unitOfWork.SaveChangesAsync(); // Persist changes, expecting an exception
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that adding an invitation with an invalid ReceiverId throws a ForeignDbUpdateException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddInvitation_WithInvalidReceiverId_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidInvitation = new InvitationDto
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserDianaGreen.Id,
                ReceiverId = Guid.NewGuid(), // Invalid ReceiverId
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = DateTime.UtcNow,
                ResponseDate = null,
                IsAccepted = null
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _unitOfWork.Repository<InvitationEntity, InvitationDto>().InsertAsync(invalidInvitation);
                await _unitOfWork.SaveChangesAsync(); // Persist changes, expecting an exception
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that adding an invitation with an invalid GroupId throws a ForeignDbUpdateException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddInvitation_WithInvalidGroupId_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidInvitation = new InvitationDto
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserDianaGreen.Id,
                ReceiverId = UserSeeds.UserCharlieBlack.Id,
                GroupId = Guid.NewGuid(), // Invalid GroupId
                SentDate = DateTime.UtcNow,
                ResponseDate = null,
                IsAccepted = null
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _unitOfWork.Repository<InvitationEntity, InvitationDto>().InsertAsync(invalidInvitation);
                await _unitOfWork.SaveChangesAsync(); // Persist changes, expecting an exception
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that attempting to update a non-existent invitation throws an InvalidOperationException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_NonExistentInvitation_ThrowsInvalidOperationException()
        {
            // Arrange
            var nonExistentInvitation = new InvitationDto
            {
                Id = Guid.NewGuid(), // Non-existent ID
                SenderId = UserSeeds.UserDianaGreen.Id,
                ReceiverId = UserSeeds.UserCharlieBlack.Id,
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = DateTime.UtcNow,
                ResponseDate = null,
                IsAccepted = null
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _unitOfWork.Repository<InvitationEntity, InvitationDto>().UpdateAsync(nonExistentInvitation);
                await _unitOfWork.SaveChangesAsync(); // Persist changes, expecting an exception
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that attempting to delete a non-existent invitation throws a KeyNotFoundException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteInvitation_NonExistentInvitation_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistentInvitationId = Guid.NewGuid(); // Non-existent ID

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _unitOfWork.Repository<InvitationEntity, InvitationDto>().DeleteAsync(nonExistentInvitationId);
                await _unitOfWork.SaveChangesAsync(); // Persist changes, expecting an exception
            });
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Unit tests for special cases and updates related to the Invitation entity.
        /// These tests validate specific update scenarios and exception handling during CRUD operations.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that changing the response date of an invitation successfully updates the record in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_ChangeResponseDate_SuccessfullyUpdates()
        {
            // Arrange
            var existingInvitation = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationDianaToCharlieIntoFamily);
            var updatedInvitation = existingInvitation with
            {
                ResponseDate = DateTime.UtcNow.AddDays(1), // Change response date to a future date
                IsAccepted = true
            };

            // Act
            await _unitOfWork.Repository<InvitationEntity, InvitationDto>().UpdateAsync(updatedInvitation);
            await _unitOfWork.SaveChangesAsync(); // Persist changes

            // Assert
            var actualInvitation = await _unitOfWork.Repository<InvitationEntity, InvitationDto>().GetByIdAsync(updatedInvitation.Id);
            Assert.NotNull(actualInvitation); // Ensure the invitation was updated
            Assert.Equal(updatedInvitation.ResponseDate, actualInvitation.ResponseDate); // Verify that the response date matches
        }

        [Fact]
        /// <summary>
        /// Verifies that setting the response date of an invitation to null successfully updates the record in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_SetNullResponseDate_SuccessfullyUpdates()
        {
            // Arrange
            var existingInvitation = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationDianaToCharlieIntoFamily);
            var updatedInvitation = existingInvitation with
            {
                ResponseDate = null, // Set response date to null
                IsAccepted = false
            };

            // Act
            await _unitOfWork.Repository<InvitationEntity, InvitationDto>().UpdateAsync(updatedInvitation);
            await _unitOfWork.SaveChangesAsync(); // Persist changes

            // Assert
            var actualInvitation = await _unitOfWork.Repository<InvitationEntity, InvitationDto>().GetByIdAsync(updatedInvitation.Id);
            Assert.NotNull(actualInvitation); // Ensure the invitation was updated
            Assert.Null(actualInvitation.ResponseDate); // Verify that the response date is null
        }

        [Fact]
        /// <summary>
        /// Verifies that adding an invitation with a future sent date throws a DbUpdateException.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddInvitation_WithFutureSentDate_ThrowsDbUpdateException()
        {
            // Arrange
            var invitationToAdd = new InvitationDto
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserJohnDoe.Id,
                ReceiverId = UserSeeds.UserAliceSmith.Id,
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = DateTime.UtcNow.AddDays(1), // Set sent date to a future date
                ResponseDate = null,
                IsAccepted = null
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await _unitOfWork.Repository<InvitationEntity, InvitationDto>().InsertAsync(invitationToAdd);
                await _unitOfWork.SaveChangesAsync(); // Attempt to persist changes
            });
        }

        [Fact]
        /// <summary>
        /// Verifies that attempting to change the UserId or GroupId of an existing GroupUser does not change those properties.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_ChangeSenderIdRecieverIdOrGroupId_ShouldNotChange()
        {
            // Arrange
            var existingInvitation = _mapper.Map<InvitationDto>(InvitationSeeds.InvitationDianaToCharlieIntoFamily);

            var updatedInvitation = new InvitationDto
            {
                Id = existingInvitation.Id,
                SenderId = Guid.NewGuid(), // Attempt to change SenderId
                ReceiverId = Guid.NewGuid(), // Attempt to change RecieverId
                GroupId = Guid.NewGuid(), // Attempt to change GroupId
                SentDate = existingInvitation.SentDate,
                ResponseDate = null,
                IsAccepted = null
            };

            // Act
            await _unitOfWork.Repository<InvitationEntity, InvitationDto>().UpdateAsync(updatedInvitation);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualInvitation = await _unitOfWork.Repository<InvitationEntity, InvitationDto>().GetByIdAsync(existingInvitation.Id);
            Assert.NotNull(actualInvitation);
            Assert.Equal(existingInvitation.SenderId, actualInvitation.SenderId); // SenderId should remain unchanged
            Assert.Equal(existingInvitation.ReceiverId, actualInvitation.ReceiverId); // ReceiverId should remain unchanged
            Assert.Equal(existingInvitation.GroupId, actualInvitation.GroupId); // GroupId should remain unchanged
        }


        #endregion
        #region Related Entities Handling Tests

        /// <summary>
        /// Unit tests for handling related entities when performing operations on invitations.
        /// These tests verify that integrity constraints are maintained after deletions.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that deleting an invitation with an associated sender keeps the sender intact.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteInvitation_WithAssociatedSender_KeepsSenderIntact()
        {
            // Arrange
            var invitationToDelete = InvitationSeeds.InvitationDianaToCharlieIntoFamily;

            // Act
            await _unitOfWork.Repository<InvitationEntity, InvitationDto>().DeleteAsync(invitationToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var sender = await _unitOfWork.Repository<UserEntity, UserDto>().GetByIdAsync(invitationToDelete.SenderId);
            Assert.NotNull(sender); // Ensure the sender still exists
            Assert.Equal(invitationToDelete.SenderId, sender.Id); // Verify that the sender is the same
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting an invitation with an associated receiver keeps the receiver intact.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteInvitation_WithAssociatedReceiver_KeepsReceiverIntact()
        {
            // Arrange
            var invitationToDelete = InvitationSeeds.InvitationJohnToDianaIntoFamily;

            // Act
            await _unitOfWork.Repository<InvitationEntity, InvitationDto>().DeleteAsync(invitationToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var receiver = await _unitOfWork.Repository<UserEntity, UserDto>().GetByIdAsync(invitationToDelete.ReceiverId);
            Assert.NotNull(receiver); // Ensure the receiver still exists
            Assert.Equal(invitationToDelete.ReceiverId, receiver.Id); // Verify that the receiver is the same
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting an invitation with an associated group keeps the group intact.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteInvitation_WithAssociatedGroup_KeepsGroupIntact()
        {
            // Arrange
            var invitationToDelete = InvitationSeeds.InvitationJohnToDianaIntoWork;

            // Act
            await _unitOfWork.Repository<InvitationEntity, InvitationDto>().DeleteAsync(invitationToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var group = await _unitOfWork.Repository<GroupEntity, GroupDto>().GetByIdAsync(invitationToDelete.GroupId);
            Assert.NotNull(group); // Ensure the group still exists
            Assert.Equal(invitationToDelete.GroupId, group.Id); // Verify that the group is the same
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Unit tests to verify transactional consistency after performing multiple invitation operations.
        /// These tests ensure that invitations are correctly inserted, updated, and deleted while maintaining consistency.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that after multiple invitation operations (insert, update, delete), the final state is consistent.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task TransactionalConsistency_AfterMultipleInvitationOperations()
        {
            // Arrange
            var newInvitationDto = new InvitationDto
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserDianaGreen.Id,
                ReceiverId = UserSeeds.UserCharlieBlack.Id,
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = DateTime.UtcNow,
                ResponseDate = null,
                IsAccepted = null
            };

            var updatedInvitationDto = new InvitationDto
            {
                Id = newInvitationDto.Id,
                SenderId = newInvitationDto.SenderId,
                ReceiverId = newInvitationDto.ReceiverId,
                GroupId = newInvitationDto.GroupId,
                SentDate = newInvitationDto.SentDate,
                ResponseDate = DateTime.UtcNow,
                IsAccepted = true
            };

            try
            {
                // Act
                // Insert
                await _unitOfWork.Repository<InvitationEntity, InvitationDto>().InsertAsync(newInvitationDto);
                await _unitOfWork.SaveChangesAsync();

                // Update
                await _unitOfWork.Repository<InvitationEntity, InvitationDto>().UpdateAsync(updatedInvitationDto);
                await _unitOfWork.SaveChangesAsync();

                // Delete
                await _unitOfWork.Repository<InvitationEntity, InvitationDto>().DeleteAsync(newInvitationDto.Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw; // Rethrow exception to indicate failure
            }

            // Assert
            var deletedInvitation = await _unitOfWork.Repository<InvitationEntity, InvitationDto>().GetByIdAsync(newInvitationDto.Id);
            Assert.Null(deletedInvitation); // Ensure the invitation was deleted
        }

        #endregion
    }
}
