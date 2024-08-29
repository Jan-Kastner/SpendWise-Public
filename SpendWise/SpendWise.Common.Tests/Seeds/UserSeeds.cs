using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SpendWise.Common.Enums;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="UserEntity"/> entity.
    /// </summary>
    public static class UserSeeds
    {
        private static bool _relationsInitialized = false;

        /// <summary>
        /// Gets the seed data for user John Doe.
        /// </summary>
        public static readonly UserEntity UserJohnDoe = new()
        {
            Id = Guid.NewGuid(),
            Name = "John",
            Surname = "Doe",
            Email = "john.doe@spendwise.com",
            PasswordHash = "hashed_password_1",
            DateOfRegistration = new DateTime(2024, 6, 15, 11, 0, 0, DateTimeKind.Utc),
            Photo = Array.Empty<byte>(),
            IsEmailConfirmed = false,
            EmailConfirmationToken = null,
            ResetPasswordToken = null,
            ResetPasswordTokenExpiry = null,
            IsTwoFactorEnabled = false,
            TwoFactorSecret = null,
            Role = UserRole.User,
            PreferredTheme = Theme.SystemDefault
        };

        /// <summary>
        /// Gets the seed data for user Alice Smith.
        /// </summary>
        public static readonly UserEntity UserAliceSmith = new()
        {
            Id = Guid.NewGuid(),
            Name = "Alice",
            Surname = "Smith",
            Email = "alice.smith@spendwise.com",
            PasswordHash = "hashed_password_2",
            DateOfRegistration = new DateTime(2024, 6, 17, 11, 0, 0, DateTimeKind.Utc),
            Photo = Array.Empty<byte>(),
            IsEmailConfirmed = false,
            EmailConfirmationToken = null,
            ResetPasswordToken = null,
            ResetPasswordTokenExpiry = null,
            IsTwoFactorEnabled = false,
            TwoFactorSecret = null,
            Role = UserRole.User,
            PreferredTheme = Theme.SystemDefault
        };

        /// <summary>
        /// Gets the seed data for user Bob Brown.
        /// </summary>
        public static readonly UserEntity UserBobBrown = new()
        {
            Id = Guid.NewGuid(),
            Name = "Bob",
            Surname = "Brown",
            Email = "bob.brown@spendwise.com",
            PasswordHash = "hashed_password_3",
            DateOfRegistration = new DateTime(2024, 6, 18, 11, 0, 0, DateTimeKind.Utc),
            Photo = Array.Empty<byte>(),
            IsEmailConfirmed = false,
            EmailConfirmationToken = null,
            ResetPasswordToken = null,
            ResetPasswordTokenExpiry = null,
            IsTwoFactorEnabled = false,
            TwoFactorSecret = null,
            Role = UserRole.User,
            PreferredTheme = Theme.SystemDefault
        };

        /// <summary>
        /// Gets the seed data for user Charlie Black.
        /// </summary>
        public static readonly UserEntity UserCharlieBlack = new()
        {
            Id = Guid.NewGuid(),
            Name = "Charlie",
            Surname = "Black",
            Email = "charlie.black@spendwise.com",
            PasswordHash = "hashed_password_4",
            DateOfRegistration = new DateTime(2024, 6, 19, 11, 0, 0, DateTimeKind.Utc),
            Photo = Array.Empty<byte>(),
            IsEmailConfirmed = false,
            EmailConfirmationToken = null,
            ResetPasswordToken = null,
            ResetPasswordTokenExpiry = null,
            IsTwoFactorEnabled = false,
            TwoFactorSecret = null,
            Role = UserRole.User,
            PreferredTheme = Theme.SystemDefault
        };

        /// <summary>
        /// Gets the seed data for user Diana Green.
        /// </summary>
        public static readonly UserEntity UserDianaGreen = new()
        {
            Id = Guid.NewGuid(),
            Name = "Diana",
            Surname = "Green",
            Email = "diana.green@spendwise.com",
            PasswordHash = "hashed_password_5",
            DateOfRegistration = new DateTime(2024, 6, 20, 11, 0, 0, DateTimeKind.Utc),
            Photo = Array.Empty<byte>(),
            IsEmailConfirmed = false,
            EmailConfirmationToken = null,
            ResetPasswordToken = null,
            ResetPasswordTokenExpiry = null,
            IsTwoFactorEnabled = false,
            TwoFactorSecret = null,
            Role = UserRole.User,
            PreferredTheme = Theme.SystemDefault
        };

        /// <summary>
        /// Initializes relationships between users and other entities.
        /// </summary>
        public static void InitializeRelations()
        {
            if (!_relationsInitialized)
            {
                UserJohnDoe.SentInvitations.Add(InvitationSeeds.InvitationJohnToDianaIntoFamily);
                UserJohnDoe.SentInvitations.Add(InvitationSeeds.InvitationJohnToDianaIntoWork);
                UserJohnDoe.GroupUsers.Add(GroupUserSeeds.GroupUserJohnInFamily);
                UserJohnDoe.GroupUsers.Add(GroupUserSeeds.GroupUserJohnInFriends);
                UserJohnDoe.GroupUsers.Add(GroupUserSeeds.GroupUserJohnInWork);

                UserBobBrown.GroupUsers.Add(GroupUserSeeds.GroupUserBobInFamily);

                UserCharlieBlack.ReceivedInvitations.Add(InvitationSeeds.InvitationDianaToCharlieIntoFamily);
                UserCharlieBlack.GroupUsers.Add(GroupUserSeeds.GroupUserCharlieInFamily);

                UserDianaGreen.ReceivedInvitations.Add(InvitationSeeds.InvitationJohnToDianaIntoFamily);
                UserDianaGreen.ReceivedInvitations.Add(InvitationSeeds.InvitationJohnToDianaIntoWork);
                UserDianaGreen.SentInvitations.Add(InvitationSeeds.InvitationDianaToCharlieIntoFamily);
                UserDianaGreen.GroupUsers.Add(GroupUserSeeds.GroupUserDianaInFamily);

                _relationsInitialized = true;
            }
        }

        /// <summary>
        /// Seeds the <see cref="UserEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder to seed data into.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                UserAliceSmith with
                {
                    SentInvitations = Array.Empty<InvitationEntity>(),
                    GroupUsers = Array.Empty<GroupUserEntity>(),
                    ReceivedInvitations = Array.Empty<InvitationEntity>()
                },

                UserBobBrown with
                {
                    SentInvitations = Array.Empty<InvitationEntity>(),
                    GroupUsers = Array.Empty<GroupUserEntity>(),
                    ReceivedInvitations = Array.Empty<InvitationEntity>()
                },

                UserCharlieBlack with
                {
                    SentInvitations = Array.Empty<InvitationEntity>(),
                    GroupUsers = Array.Empty<GroupUserEntity>(),
                    ReceivedInvitations = Array.Empty<InvitationEntity>()
                },

                UserDianaGreen with
                {
                    SentInvitations = Array.Empty<InvitationEntity>(),
                    GroupUsers = Array.Empty<GroupUserEntity>(),
                    ReceivedInvitations = Array.Empty<InvitationEntity>()
                },

                UserJohnDoe with
                {
                    SentInvitations = Array.Empty<InvitationEntity>(),
                    GroupUsers = Array.Empty<GroupUserEntity>(),
                    ReceivedInvitations = Array.Empty<InvitationEntity>()
                }
            );
            InitializeRelations();
        }
    }
}
