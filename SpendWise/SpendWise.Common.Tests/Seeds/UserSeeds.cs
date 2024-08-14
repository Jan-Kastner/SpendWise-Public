using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="UserEntity"/> entity.
    /// </summary>
    public static class UserSeeds
    {
        /// <summary>
        /// A seed instance of <see cref="UserEntity"/> representing the Admin user.
        /// </summary>
        public static readonly UserEntity UserAdmin = new()
        {
            Id = Guid.NewGuid(),
            Name = "Admin",
            Surname = "Admin",
            Email = "admin@spendwise.com",
            Password = "admin",
            Date_of_registration = new DateTime(2024, 6, 1, 11, 0, 0, DateTimeKind.Utc),
            Photo = null
        };

        /// <summary>
        /// A seed instance of <see cref="UserEntity"/> representing the user John Doe.
        /// </summary>
        public static readonly UserEntity UserJohnDoe = new()
        {
            Id = Guid.NewGuid(),
            Name = "John",
            Surname = "Doe",
            Email = "john.doe@spendwise.com",
            Password = "password",
            Date_of_registration = new DateTime(2024, 6, 15, 11, 0, 0, DateTimeKind.Utc),
            Photo = null
        };

        /// <summary>
        /// A seed instance of <see cref="UserEntity"/> representing the user Jane Smith.
        /// </summary>
        public static readonly UserEntity UserJaneSmith = new()
        {
            Id = Guid.NewGuid(),
            Name = "Jane",
            Surname = "Smith",
            Email = "jane.smith@spendwise.com",
            Password = "password123",
            Date_of_registration = new DateTime(2024, 7, 1, 10, 0, 0, DateTimeKind.Utc),
            Photo = null
        };

        /// <summary>
        /// A seed instance of <see cref="UserEntity"/> representing the user Bob Johnson.
        /// </summary>
        public static readonly UserEntity UserBobJohnson = new()
        {
            Id = Guid.NewGuid(),
            Name = "Bob",
            Surname = "Johnson",
            Email = "bob.johnson@spendwise.com",
            Password = "password456",
            Date_of_registration = new DateTime(2024, 7, 20, 9, 0, 0, DateTimeKind.Utc),
            Photo = null
        };

        /// <summary>
        /// A seed instance of <see cref="UserEntity"/> representing the user Alice Brown.
        /// </summary>
        public static readonly UserEntity UserAliceBrown = new()
        {
            Id = Guid.NewGuid(),
            Name = "Alice",
            Surname = "Brown",
            Email = "alice.brown@spendwise.com",
            Password = "password789",
            Date_of_registration = new DateTime(2024, 7, 29, 14, 0, 0, DateTimeKind.Utc),
            Photo = null
        };

        /// <summary>
        /// A seed instance of <see cref="UserEntity"/> representing the Admin user with related entities.
        /// </summary>
        public static readonly UserEntity UserAdminWithRelations = UserAdmin with
        {
            ReceivedInvitations = new List<InvitationEntity>()
            {
                InvitationSeeds.InvitationJohnDoeToAdminIntoFriends
            },
            SentInvitations = new List<InvitationEntity>
            {
                InvitationSeeds.InvitationAdminToJohnDoeIntoFamily
            },
            GroupUsers = new List<GroupUserEntity>
            {
                GroupUserSeeds.GroupUserAdminInFamily
            },
        };

        /// <summary>
        /// A seed instance of <see cref="UserEntity"/> representing the user John Doe with related entities.
        /// </summary>
        public static readonly UserEntity UserJohnDoeWithRelations = UserJohnDoe with
        {
            ReceivedInvitations = new List<InvitationEntity>
            {
                InvitationSeeds.InvitationAdminToJohnDoeIntoFamily
            },
            SentInvitations = new List<InvitationEntity>
            {
                InvitationSeeds.InvitationJohnDoeToAdminIntoFriends
            },
            GroupUsers = new List<GroupUserEntity>
            {
                GroupUserSeeds.GroupUserJohnDoeInFriends,
                GroupUserSeeds.GroupUserJohnDoeInFamily
            },
        };

        /// <summary>
        /// A seed instance of <see cref="UserEntity"/> representing the user Bob Johnson with related entities.
        /// </summary>
        public static readonly UserEntity UserBobJohnsonWithRelations = UserBobJohnson;

        /// <summary>
        /// A seed instance of <see cref="UserEntity"/> representing the user Alice Brown with related entities.
        /// </summary>
        public static readonly UserEntity UserAliceBrownWithRelations = UserAliceBrown;

        /// <summary>
        /// Seeds the <see cref="UserEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to seed data.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                UserAdmin,
                UserJohnDoe,
                UserJaneSmith,
                UserBobJohnson,
                UserAliceBrown
            );
        }
    }
}
