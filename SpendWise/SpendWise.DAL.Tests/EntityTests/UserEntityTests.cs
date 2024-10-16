using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="UserEntity"/> entity.
    /// </summary>
    public class UserEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserEntityTests"/> class.
        /// </summary>
        /// <param name="output">The output helper used to log test results.</param>
        public UserEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Verifies that adding a valid user successfully persists the user in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_ValidUser_ShouldPersistSuccessfully()
        {
            // Arrange
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            var newUser = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "David",
                Surname = "Smith",
                Email = "david.smith@example.com",
                PasswordHash = "somestrongpassword",
                DateOfRegistration = baseTime,
                ReceivedInvitations = Array.Empty<InvitationEntity>(),
                SentInvitations = Array.Empty<InvitationEntity>(),
                GroupUsers = Array.Empty<GroupUserEntity>(),
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                PreferredTheme = Theme.SystemDefault,
                ReinitPasswordToken = null,
                ReinitPasswordTokenExpiry = null
            };

            // Act
            SpendWiseDbContextSUT.Users.Add(newUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbContext = await DbContextFactory.CreateDbContextAsync();
            var actualUser = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == newUser.Id);

            Assert.NotNull(actualUser);
            DeepAssert.Equal(newUser, actualUser);
        }

        /// <summary>
        /// Verifies that fetching a user by their ID returns the expected user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchUserById_ShouldReturnExpectedUser()
        {
            // Arrange
            var expectedUser = UserSeeds.UserJohnDoe;
            var userId = expectedUser.Id;

            // Act
            var actualUser = await SpendWiseDbContextSUT.Users
                .Where(u => u.Id == userId)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualUser);
            DeepAssert.Equal(expectedUser, actualUser);
        }

        /// <summary>
        /// Verifies that updating an existing user successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_ExistingUser_ShouldPersistChangesSuccessfully()
        {
            // Arrange
            var existingUser = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(u => u.Id == UserSeeds.UserJohnDoe.Id);

            var updatedUser = existingUser with
            {
                Name = existingUser.Name + " Updated",
                Surname = existingUser.Surname + " Updated",
                Email = existingUser.Email + " Updated",
                PasswordHash = existingUser.PasswordHash + " Updated",
                DateOfRegistration = existingUser.DateOfRegistration.AddHours(3),
            };

            // Act
            SpendWiseDbContextSUT.Users.Update(updatedUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbContext = await DbContextFactory.CreateDbContextAsync();
            var actualUser = await dbContext.Users.SingleAsync(u => u.Id == updatedUser.Id);
            DeepAssert.Equal(updatedUser, actualUser);
        }

        /// <summary>
        /// Verifies that deleting an existing user successfully removes them from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser_ExistingUser_ShouldRemoveSuccessfully()
        {
            // Arrange
            var userToDelete = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(u => u.Id == UserSeeds.UserJohnDoe.Id);

            Assert.NotNull(userToDelete);

            // Act
            SpendWiseDbContextSUT.Users.Remove(userToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.Users.AnyAsync(u => u.Id == userToDelete.Id));
        }

        /// <summary>
        /// Verifies that fetching a user by their email returns the expected user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchUserByEmail_ShouldReturnExpectedUser()
        {
            // Arrange
            var expectedUser = UserSeeds.UserJohnDoe;
            var userEmail = expectedUser.Email;

            // Act
            var actualUser = await SpendWiseDbContextSUT.Users
                .Where(u => u.Email == userEmail)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualUser);
            DeepAssert.Equal(expectedUser, actualUser);
        }

        /// <summary>
        /// Verifies that adding a user with maximum field length successfully stores the data correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_WithMaximumFieldLength_ShouldStoreDataCorrectly()
        {
            // Arrange
            var maxLengthName = new string('A', 100);
            var maxLengthEmail = new string('B', 243) + "@example.com";

            var userWithMaxLengthFields = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = maxLengthName,
                Surname = maxLengthName,
                Email = maxLengthEmail,
                PasswordHash = new string('C', 255),
                DateOfRegistration = DateTime.UtcNow,
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                PreferredTheme = Theme.SystemDefault,
                SentInvitations = new List<InvitationEntity>(),
                GroupUsers = new List<GroupUserEntity>(),
                ReceivedInvitations = new List<InvitationEntity>(),
                ReinitPasswordToken = null,
                ReinitPasswordTokenExpiry = null
            };

            // Act
            SpendWiseDbContextSUT.Users.Add(userWithMaxLengthFields);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbContext = await DbContextFactory.CreateDbContextAsync();
            var storedUser = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userWithMaxLengthFields.Id);

            Assert.NotNull(storedUser);
            Assert.Equal(maxLengthName, storedUser.Name);
            Assert.Equal(maxLengthName, storedUser.Surname);
            Assert.Equal(maxLengthEmail, storedUser.Email);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Verifies that attempting to add a user with a duplicate email address throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_WithDuplicateEmail_ShouldThrowDbUpdateException()
        {
            // Arrange
            var userWithDuplicateEmail = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Surname = "Smith",
                Email = "john.doe@spendwise.com", // Duplicate email
                PasswordHash = "password789",
                DateOfRegistration = DateTime.UtcNow,
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                PreferredTheme = Theme.SystemDefault,
                SentInvitations = new List<InvitationEntity>(),
                GroupUsers = new List<GroupUserEntity>(),
                ReceivedInvitations = new List<InvitationEntity>(),
                ReinitPasswordToken = null,
                ReinitPasswordTokenExpiry = null
            };

            SpendWiseDbContextSUT.Users.Add(userWithDuplicateEmail);

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChangesAsync());
        }

        /// <summary>
        /// Verifies that attempting to add a user with an invalid registration date (e.g., a future date) throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_WithInvalidRegistrationDate_ShouldThrowDbUpdateException()
        {
            // Arrange
            var userWithInvalidDate = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Surname = "Smith",
                Email = "invalid.user@example.com",
                PasswordHash = "password789",
                DateOfRegistration = DateTime.UtcNow.AddHours(1),
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                PreferredTheme = Theme.SystemDefault,
                SentInvitations = new List<InvitationEntity>(),
                GroupUsers = new List<GroupUserEntity>(),
                ReceivedInvitations = new List<InvitationEntity>(),
                ReinitPasswordToken = null,
                ReinitPasswordTokenExpiry = null
            };

            SpendWiseDbContextSUT.Users.Add(userWithInvalidDate);

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChangesAsync());
        }

        /// <summary>
        /// Verifies that attempting to update a user with an invalid email address (e.g., too long) throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_WithInvalidEmail_ShouldThrowDbUpdateException()
        {
            // Arrange
            var existingUser = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(u => u.Id == UserSeeds.UserJohnDoe.Id);

            var invalidEmail = new string('B', 244) + "@example.com"; // Email too long

            var updatedUser = existingUser with
            {
                Email = invalidEmail
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Users.Update(updatedUser);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Verifies that attempting to update a user with a future registration date throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_WithFutureRegistrationDate_ShouldThrowDbUpdateException()
        {
            // Arrange
            var existingUser = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(u => u.Id == UserSeeds.UserJohnDoe.Id);

            var futureDate = DateTime.UtcNow.AddHours(1); // Future date

            var updatedUser = existingUser with
            {
                DateOfRegistration = futureDate
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Users.Update(updatedUser);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        #endregion

        #region Data Retrieval Tests

        /// <summary>
        /// Verifies that fetching users within a specified date range returns the expected users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchUsersWithinDateRange_ShouldReturnUsersWithinRange()
        {
            // Arrange
            var startDate = new DateTime(2024, 6, 17, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2024, 6, 20, 0, 0, 0, DateTimeKind.Utc);
            var expectedUsers = new List<UserEntity>
            {
                UserSeeds.UserAliceSmith,
                UserSeeds.UserBobBrown,
                UserSeeds.UserCharlieBlack
            };

            // Act
            var usersInRange = await SpendWiseDbContextSUT.Users
                .Where(u => u.DateOfRegistration >= startDate && u.DateOfRegistration < endDate)
                .ToListAsync();

            // Assert
            Assert.NotNull(usersInRange);
            Assert.Equal(expectedUsers.Count, usersInRange.Count);
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, usersInRange);
            }
        }

        /// <summary>
        /// Verifies that fetching users who belong to multiple groups returns the expected users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchUsersInMultipleGroups_ShouldReturnExpectedUsers()
        {
            // Arrange
            var expectedUser = UserSeeds.UserJohnDoe;

            // Act
            var usersInMultipleGroups = await SpendWiseDbContextSUT.Users
                .Where(u => u.GroupUsers.Count > 1)
                .ToListAsync();

            // Assert
            Assert.NotNull(usersInMultipleGroups);
            Assert.Single(usersInMultipleGroups);
            DeepAssert.Contains(expectedUser, usersInMultipleGroups);
        }

        /// <summary>
        /// Verifies that fetching the total user count returns the correct number of users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchTotalUserCount_ShouldReturnCorrectNumber()
        {
            // Arrange
            var expectedCount = 5; // Assuming 5 users in the seed data

            // Act
            var totalUserCount = await SpendWiseDbContextSUT.Users.CountAsync();

            // Assert
            Assert.Equal(expectedCount, totalUserCount);
        }

        /// <summary>
        /// Verifies that retrieving users by a substring of their email returns the expected users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RetrieveUsersByEmailSubstring_ShouldReturnExpectedUsers()
        {
            // Arrange
            var emailSubstring = "john.doe";
            var expectedUsers = new List<UserEntity> { UserSeeds.UserJohnDoe };

            // Act
            var usersByEmail = await SpendWiseDbContextSUT.Users
                .Where(u => u.Email.Contains(emailSubstring))
                .ToListAsync();

            // Assert
            Assert.NotNull(usersByEmail);
            Assert.Equal(expectedUsers.Count, usersByEmail.Count);
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, usersByEmail);
            }
        }

        /// <summary>
        /// Verifies that retrieving users by a substring of their name or surname returns the expected users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RetrieveUsersByNameOrSurname_ShouldReturnExpectedUsers()
        {
            // Arrange
            var expectedUsers = new List<UserEntity> { UserSeeds.UserJohnDoe, UserSeeds.UserBobBrown };

            // Act
            var usersByNameOrSurname = await SpendWiseDbContextSUT.Users
                .Where(u => u.Name.Contains("John") || u.Surname.Contains("Brown"))
                .ToListAsync();

            // Assert
            Assert.NotNull(usersByNameOrSurname);
            Assert.Equal(expectedUsers.Count, usersByNameOrSurname.Count);
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, usersByNameOrSurname);
            }
        }

        /// <summary>
        /// Verifies that fetching users ordered by their registration date returns the users in the correct order.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchUsersOrderedByRegistrationDate_ShouldReturnUsersInCorrectOrder()
        {
            // Act
            var orderedUsers = await SpendWiseDbContextSUT.Users
                .OrderBy(u => u.DateOfRegistration)
                .ToListAsync();

            // Assert
            Assert.Equal(5, orderedUsers.Count);
            DeepAssert.Equal(UserSeeds.UserJohnDoe, orderedUsers[0]);
            DeepAssert.Equal(UserSeeds.UserAliceSmith, orderedUsers[1]);
            DeepAssert.Equal(UserSeeds.UserBobBrown, orderedUsers[2]);
            DeepAssert.Equal(UserSeeds.UserCharlieBlack, orderedUsers[3]);
            DeepAssert.Equal(UserSeeds.UserDianaGreen, orderedUsers[4]);
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Verifies that when the last invitation for a user is removed, the user remains in the system with no invitations left.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RemoveLastInvitation_ShouldLeaveUserWithNoInvitations()
        {
            // Arrange
            var user = UserSeeds.UserCharlieBlack;
            var invitationToRemove = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);
            var initialInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == user.Id);

            Assert.True(initialInvitationCount > 0);

            // Act
            SpendWiseDbContextSUT.Invitations.Remove(invitationToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var remainingUser = await SpendWiseDbContextSUT.Users.SingleOrDefaultAsync(u => u.Id == user.Id);
            Assert.NotNull(remainingUser);
            var remainingInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == user.Id);
            Assert.Equal(0, remainingInvitationCount);
        }

        /// <summary>
        /// Verifies that when a group association for a user is removed, the user remains in the system with no group associations left.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RemoveGroupUser_ShouldLeaveUserWithNoGroupAssociations()
        {
            // Arrange
            var user = UserSeeds.UserBobBrown;
            var groupUserToRemove = await SpendWiseDbContextSUT.GroupUsers
                .AsNoTracking()
                .FirstAsync(l => l.Id == GroupUserSeeds.GroupUserBobInFamily.Id);
            var initialGroupUserCount = await SpendWiseDbContextSUT.GroupUsers
                .CountAsync(gu => gu.UserId == user.Id);

            Assert.True(initialGroupUserCount > 0);

            // Act
            SpendWiseDbContextSUT.GroupUsers.Remove(groupUserToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var remainingUser = await SpendWiseDbContextSUT.Users.SingleOrDefaultAsync(u => u.Id == user.Id);
            Assert.NotNull(remainingUser);
            var remainingGroupUserCount = await SpendWiseDbContextSUT.GroupUsers
                .CountAsync(gu => gu.UserId == user.Id);
            Assert.Equal(0, remainingGroupUserCount);
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Verifies that when a user is removed, all associated invitations (both received and sent) are also deleted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RemoveUser_ShouldDeleteAssociatedInvitations()
        {
            // Arrange
            var userToRemove = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(l => l.Id == UserSeeds.UserJohnDoe.Id);
            var initialInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == userToRemove.Id || i.SenderId == userToRemove.Id);

            // Act
            SpendWiseDbContextSUT.Users.Remove(userToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var remainingInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == userToRemove.Id || i.SenderId == userToRemove.Id);
            Assert.Equal(0, remainingInvitationCount);
        }

        /// <summary>
        /// Verifies that when fetching a user, all related navigation properties (invitations and group associations) are correctly loaded.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchUser_ShouldLoadNavigationPropertiesCorrectly()
        {
            // Arrange
            var userId = UserSeeds.UserDianaGreen.Id;
            var expectedReceivedInvitations = new List<InvitationEntity>
    {
        InvitationSeeds.InvitationJohnToDianaIntoFamily,
        InvitationSeeds.InvitationJohnToDianaIntoWork
    };
            var expectedSentInvitations = new List<InvitationEntity>
    {
        InvitationSeeds.InvitationDianaToCharlieIntoFamily
    };
            var expectedGroupUsers = new List<GroupUserEntity>
    {
        GroupUserSeeds.GroupUserDianaInFamily
    };

            // Act
            var user = await SpendWiseDbContextSUT.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ReceivedInvitations)
                .Include(u => u.SentInvitations)
                .Include(u => u.GroupUsers)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(user);

            // Check ReceivedInvitations
            Assert.NotNull(user.ReceivedInvitations);
            foreach (var expectedInvitation in expectedReceivedInvitations)
            {
                DeepAssert.Contains(expectedInvitation, user.ReceivedInvitations);
            }

            // Check SentInvitations
            Assert.NotNull(user.SentInvitations);
            Assert.Single(user.SentInvitations);
            foreach (var expectedInvitation in expectedSentInvitations)
            {
                DeepAssert.Contains(expectedInvitation, user.SentInvitations);
            }

            // Check GroupUsers
            Assert.NotNull(user.GroupUsers);
            Assert.Single(user.GroupUsers);
            Assert.Equal(expectedGroupUsers.Count(), user.GroupUsers.Count());
            foreach (var expectedGroupUser in expectedGroupUsers)
            {
                DeepAssert.Contains(expectedGroupUser, user.GroupUsers);
            }
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Verifies that multiple users can be added concurrently, and all users are successfully persisted in the database without any data loss or corruption.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUsersConcurrently_ShouldPersistAllUsersSuccessfully()
        {
            // Arrange
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            var usersToAdd = Enumerable.Range(0, 10).Select(i => new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = $"Bob{i}",
                Surname = "Johnson",
                Email = $"bob{i}.johnson@spendwise.com",
                PasswordHash = "password456",
                DateOfRegistration = baseTime,
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                PreferredTheme = Theme.SystemDefault,
                SentInvitations = new List<InvitationEntity>(),
                GroupUsers = new List<GroupUserEntity>(),
                ReceivedInvitations = new List<InvitationEntity>(),
                ReinitPasswordToken = null,
                ReinitPasswordTokenExpiry = null
            }).ToList();

            // Act
            var addUserTasks = usersToAdd.Select(user => Task.Run(async () =>
            {
                await using var dbContext = await DbContextFactory.CreateDbContextAsync();
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }));

            await Task.WhenAll(addUserTasks);

            // Assert
            await using var finalDbContext = await DbContextFactory.CreateDbContextAsync();
            var persistedUsers = await finalDbContext.Users
                .Where(u => usersToAdd.Select(user => user.Id).Contains(u.Id))
                .ToListAsync();

            Assert.Equal(usersToAdd.Count(), persistedUsers.Count());
            foreach (var expectedUser in usersToAdd)
            {
                var actualUser = persistedUsers.SingleOrDefault(u => u.Id == expectedUser.Id);
                Assert.NotNull(actualUser);
                DeepAssert.Equal(expectedUser, actualUser);
            }
        }

        /// <summary>
        /// Checks the integrity constraints after deleting a user, ensuring that the user and all related entities (invitations, group associations) are correctly removed.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser_ShouldRemoveUserAndRelatedEntities()
        {
            // Arrange
            var userToDelete = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(u => u.Id == UserSeeds.UserJohnDoe.Id);

            Assert.NotNull(userToDelete);

            // Act
            SpendWiseDbContextSUT.Users.Remove(userToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbContext = await DbContextFactory.CreateDbContextAsync();
            var deletedUser = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userToDelete.Id);
            Assert.Null(deletedUser);

            var receivedInvitations = await dbContext.Invitations.Where(i => i.ReceiverId == userToDelete.Id).ToListAsync();
            Assert.Empty(receivedInvitations);

            var sentInvitations = await dbContext.Invitations.Where(i => i.SenderId == userToDelete.Id).ToListAsync();
            Assert.Empty(sentInvitations);

            var groupUsers = await dbContext.GroupUsers.Where(gu => gu.UserId == userToDelete.Id).ToListAsync();
            Assert.Empty(groupUsers);
        }

        #endregion
    }
}