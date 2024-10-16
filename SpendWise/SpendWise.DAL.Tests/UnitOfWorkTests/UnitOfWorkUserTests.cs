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
    /// <summary>
    /// Contains tests for operations related to users using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkUserTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkUserTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public UnitOfWorkUserTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Tests that a user with valid data is added and persisted successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var userToAdd = new UserDto
            {
                Id = Guid.NewGuid(),
                Name = "New",
                Surname = "User",
                Email = "new.user@spendwise.com",
                PasswordHash = "password987",
                DateOfRegistration = DateTime.UtcNow,
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                PreferredTheme = Theme.SystemDefault
            };

            // Act
            await _unitOfWork.UserRepository.InsertAsync(userToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new UserQueryObject().WithId(userToAdd.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            DeepAssert.Equal(userToAdd, actualUser);
        }

        /// <summary>
        /// Tests that fetching a user by its ID returns the expected user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchUserById_ExistingId_ReturnsExpectedUser()
        {
            // Arrange
            var expectedUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);
            var queryObject = new UserQueryObject().WithId(expectedUser.Id);

            // Act
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);

            // Assert
            Assert.NotNull(actualUser);
            DeepAssert.Equal(expectedUser, actualUser);
        }

        /// <summary>
        /// Tests that updating a user with valid data persists the changes successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ValidData_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);
            var updatedUser = existingUser with
            {
                Surname = "UpdatedDoe",
                Email = "updated.john.doe@spendwise.com"
            };

            // Act
            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new UserQueryObject().WithId(updatedUser.Id);
            var actualUpdatedUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUpdatedUser);
            DeepAssert.Equal(updatedUser, actualUpdatedUser);
        }

        /// <summary>
        /// Tests that deleting a user with an existing ID removes the user successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser_ExistingId_SuccessfullyRemovesUser()
        {
            // Arrange
            var userToDelete = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            // Act
            await _unitOfWork.UserRepository.DeleteAsync(userToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new UserQueryObject().WithId(userToDelete.Id);
            var deletedUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.Null(deletedUser);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that adding a user with a future date of registration throws a Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_WithFutureDateOfRegistration_ThrowsException()
        {
            // Arrange
            var invalidUser = new UserDto
            {
                Id = Guid.NewGuid(),
                Name = "Future",
                Surname = "User",
                Email = "future.user@spendwise.com",
                PasswordHash = "password123",
                DateOfRegistration = DateTime.UtcNow.AddYears(1), // Future date
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                PreferredTheme = Theme.SystemDefault
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.UserRepository.InsertAsync(invalidUser);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that updating a non-existent user throws an Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_NonExistentUser_ThrowsException()
        {
            // Arrange
            var nonExistentUser = new UserDto
            {
                Id = Guid.NewGuid(), // Non-existent ID
                Name = "NonExistent",
                Surname = "User",
                Email = "nonexistent.user@spendwise.com",
                PasswordHash = "password123",
                DateOfRegistration = DateTime.UtcNow,
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                PreferredTheme = Theme.SystemDefault
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.UserRepository.UpdateAsync(nonExistentUser);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that deleting a non-existent user throws a Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser_NonExistentUser_ThrowsException()
        {
            // Arrange
            var nonExistentUserId = Guid.NewGuid(); // Non-existent ID

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.UserRepository.DeleteAsync(nonExistentUserId);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that adding a user with a duplicate email throws a Exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_WithDuplicateEmail_ThrowsException()
        {
            // Arrange
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);
            var duplicateUser = existingUser with
            {
                Id = Guid.NewGuid(),
                Email = existingUser.Email, // Duplicate email
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _unitOfWork.UserRepository.InsertAsync(duplicateUser);
                await _unitOfWork.SaveChangesAsync();
            });
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Tests that changing a user's name updates the name successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeName_ShouldChange()
        {
            // Arrange
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                Name = "NewName" // Change Name
            };

            // Act
            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.Name, actualUser.Name); // Name should be changed
        }

        /// <summary>
        /// Tests that changing a user's surname updates the surname successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeSurname_ShouldChange()
        {
            // Arrange
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                Surname = "NewSurname" // Change Surname
            };

            // Act
            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.Surname, actualUser.Surname); // Surname should be changed
        }

        /// <summary>
        /// Tests that changing a user's email updates the email successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeEmail_ShouldChange()
        {
            // Arrange
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                Email = "new.email@spendwise.com" // Change Email
            };

            // Act
            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.Email, actualUser.Email); // Email should be changed
        }

        /// <summary>
        /// Tests that changing a user's password hash updates the password hash successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangePasswordHash_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                PasswordHash = "new_password_hash" // Change PasswordHash
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.PasswordHash, actualUser.PasswordHash); // PasswordHash should be changed
        }

        /// <summary>
        /// Tests that changing a user's date of registration updates the date of registration successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeDateOfRegistration_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                DateOfRegistration = DateTime.UtcNow.AddDays(-1) // Change DateOfRegistration
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.DateOfRegistration, actualUser.DateOfRegistration); // DateOfRegistration should be changed
        }

        /// <summary>
        /// Tests that changing a user's photo updates the photo successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangePhoto_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                Photo = new byte[] { 1, 2, 3 } // Change Photo
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.Photo, actualUser.Photo); // Photo should be changed
        }

        /// <summary>
        /// Tests that changing a user's email confirmation status updates the status successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeIsEmailConfirmed_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                IsEmailConfirmed = true // Change IsEmailConfirmed
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.IsEmailConfirmed, actualUser.IsEmailConfirmed); // IsEmailConfirmed should be changed
        }

        /// <summary>
        /// Tests that changing a user's email confirmation token updates the token successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeEmailConfirmationToken_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                EmailConfirmationToken = "new_confirmation_token" // Change EmailConfirmationToken
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.EmailConfirmationToken, actualUser.EmailConfirmationToken); // EmailConfirmationToken should be changed
        }

        /// <summary>
        /// Tests that changing a user's reset password token updates the token successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeResetPasswordToken_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                ResetPasswordToken = "new_reset_token" // Change ResetPasswordToken
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.ResetPasswordToken, actualUser.ResetPasswordToken); // ResetPasswordToken should be changed
        }

        /// <summary>
        /// Tests that changing a user's reset password token expiry updates the expiry successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeResetPasswordTokenExpiry_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                ResetPasswordTokenExpiry = DateTime.UtcNow.AddHours(1) // Change ResetPasswordTokenExpiry
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.ResetPasswordTokenExpiry, actualUser.ResetPasswordTokenExpiry); // ResetPasswordTokenExpiry should be changed
        }

        /// <summary>
        /// Tests that changing a user's two-factor authentication status updates the status successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeIsTwoFactorEnabled_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                IsTwoFactorEnabled = true, // Change IsTwoFactorEnabled
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.IsTwoFactorEnabled, actualUser.IsTwoFactorEnabled); // IsTwoFactorEnabled should be changed
        }

        /// <summary>
        /// Tests that changing a user's two-factor authentication secret updates the secret successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangeTwoFactorSecret_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                TwoFactorSecret = "new_2fa_secret" // Change TwoFactorSecret
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.TwoFactorSecret, actualUser.TwoFactorSecret); // TwoFactorSecret should be changed
        }

        /// <summary>
        /// Tests that changing a user's preferred theme updates the theme successfully.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ChangePreferredTheme_ShouldChange()
        {
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUser = existingUser with
            {
                PreferredTheme = Theme.Dark // Change PreferredTheme
            };

            await _unitOfWork.UserRepository.UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            var queryObject = new UserQueryObject().WithId(existingUser.Id);
            var actualUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.PreferredTheme, actualUser.PreferredTheme); // PreferredTheme should be changed
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Tests that deleting a user with associated group users and invitations removes all associations.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser_WithAssociatedGroupUsersAndInvitations_RemovesAssociations()
        {
            // Arrange
            var userToDelete = UserSeeds.UserDianaGreen;
            var associatedGroupUserIds = userToDelete.GroupUsers.Select(gu => gu.Id).ToList();
            var associatedInvitationIds = userToDelete.SentInvitations.Select(inv => inv.Id).ToList();

            // Verify the initial state before deletion
            var initialGroupUsers = await _unitOfWork.GroupUserRepository
                .ListAsync(new GroupUserQueryObject().WithUser(userToDelete.Id));
            Assert.NotEmpty(initialGroupUsers); // Ensure there are group users related to the user

            var initialSentInvitations = await _unitOfWork.InvitationRepository
                .ListAsync(new InvitationQueryObject().WithSender(userToDelete.Id));
            Assert.NotEmpty(initialSentInvitations); // Ensure there are sent invitations related to the user

            var initialRecievedInvitations = await _unitOfWork.InvitationRepository
                .ListAsync(new InvitationQueryObject().WithReceiver(userToDelete.Id));
            Assert.NotEmpty(initialRecievedInvitations); // Ensure there are recieved invitations related to the user

            // Act
            await _unitOfWork.UserRepository.DeleteAsync(userToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var queryObject = new UserQueryObject().WithId(userToDelete.Id);
            var deletedUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.Null(deletedUser);

            var groupUsersAfterDelete = await _unitOfWork.GroupUserRepository
                .ListAsync(new GroupUserQueryObject().WithUser(userToDelete.Id));
            Assert.Empty(groupUsersAfterDelete); // Ensure all group users related to the user are removed

            var sentInvitationsAfterDelete = await _unitOfWork.InvitationRepository
                .ListAsync(new InvitationQueryObject().WithSender(userToDelete.Id));
            Assert.Empty(sentInvitationsAfterDelete); // Ensure all sent invitations related to the user are removed

            var recievedInvitationsAfterDelete = await _unitOfWork.InvitationRepository
                .ListAsync(new InvitationQueryObject().WithReceiver(userToDelete.Id));
            Assert.Empty(recievedInvitationsAfterDelete); // Ensure all recieved invitations related to the user are removed
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Tests that after multiple user operations (insert, update, delete), the final state is consistent.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task TransactionalConsistency_AfterMultipleUserOperations()
        {
            // Arrange
            var newUserDto = new UserDto
            {
                Id = Guid.NewGuid(),
                Name = "Consistent",
                Surname = "User",
                Email = "consistent.user@spendwise.com",
                PasswordHash = "password123",
                DateOfRegistration = DateTime.UtcNow,
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                PreferredTheme = Theme.SystemDefault
            };

            var updatedUserDto = new UserDto
            {
                Id = newUserDto.Id,
                Name = newUserDto.Name,
                Surname = "UpdatedUser",
                Email = "updated.consistent.user@spendwise.com",
                PasswordHash = newUserDto.PasswordHash,
                DateOfRegistration = newUserDto.DateOfRegistration,
                Photo = newUserDto.Photo,
                IsEmailConfirmed = newUserDto.IsEmailConfirmed,
                EmailConfirmationToken = newUserDto.EmailConfirmationToken,
                ResetPasswordToken = newUserDto.ResetPasswordToken,
                ResetPasswordTokenExpiry = newUserDto.ResetPasswordTokenExpiry,
                IsTwoFactorEnabled = newUserDto.IsTwoFactorEnabled,
                TwoFactorSecret = newUserDto.TwoFactorSecret,
                PreferredTheme = newUserDto.PreferredTheme
            };

            try
            {
                // Act
                // Insert
                await _unitOfWork.UserRepository.InsertAsync(newUserDto);
                await _unitOfWork.SaveChangesAsync();

                // Update
                await _unitOfWork.UserRepository.UpdateAsync(updatedUserDto);
                await _unitOfWork.SaveChangesAsync();

                // Delete
                await _unitOfWork.UserRepository.DeleteAsync(newUserDto.Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            // Assert
            var queryObject = new UserQueryObject().WithId(newUserDto.Id);
            var deletedUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            Assert.Null(deletedUser);
        }

        #endregion
    }
}