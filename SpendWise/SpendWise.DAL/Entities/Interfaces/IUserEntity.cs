using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Entities.Interfaces
{
    /// <summary>
    /// Represents an interface for user entities within the SpendWise application.
    /// </summary>
    public interface IUserEntity : IEntity
    {
        /// <summary>
        /// Gets or inits the name of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        string Name { get; init; }

        /// <summary>
        /// Gets or inits the surname of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        string Surname { get; init; }

        /// <summary>
        /// Gets or inits the email address of the user. Must be unique and at least 5 characters long.
        /// </summary>
        [MinLength(5)]
        [EmailAddress]
        string Email { get; init; }

        /// <summary>
        /// Gets or inits the hashed password for the user. Must be at least 8 characters long.
        /// </summary>
        [MinLength(8)]
        string PasswordHash { get; init; }

        /// <summary>
        /// Gets or inits the date and time when the user registered.
        /// </summary>
        DateTime DateOfRegistration { get; init; }

        /// <summary>
        /// Gets or inits the photo of the user. Can be null.
        /// </summary>
        byte[] Photo { get; init; }

        /// <summary>
        /// Gets or inits whether the user's email has been confirmed.
        /// </summary>
        bool IsEmailConfirmed { get; init; }

        /// <summary>
        /// Gets or inits the email confirmation token used to verify the user's email address.
        /// </summary>
        string? EmailConfirmationToken { get; init; }

        /// <summary>
        /// Gets or sets the reset password token used to reset the user's password.
        /// </summary>
        string? ResetPasswordToken { get; init; }

        /// <summary>
        /// Gets or sets the reset password token expiry date.
        /// </summary>
        DateTime? ResetPasswordTokenExpiry { get; init; }

        /// <summary>
        /// Gets or inits the reinit password token used to reinit the user's password.
        /// </summary>
        string? ReinitPasswordToken { get; init; }

        /// <summary>
        /// Gets or inits the expiration time of the reinit password token.
        /// </summary>
        DateTime? ReinitPasswordTokenExpiry { get; init; }

        /// <summary>
        /// Gets or inits the two-factor authentication (2FA) enabled status.
        /// </summary>
        bool IsTwoFactorEnabled { get; init; }

        /// <summary>
        /// Gets or inits the two-factor authentication secret key.
        /// </summary>
        string? TwoFactorSecret { get; init; }

        /// <summary>
        /// Gets or inits the user's preferred theme for the application.
        /// </summary>
        Theme PreferredTheme { get; init; }

        /// <summary>
        /// Gets the collection of invitations sent by the user.
        /// </summary>
        ICollection<InvitationEntity> SentInvitations { get; init; }

        /// <summary>
        /// Gets the collection of invitations received by the user.
        /// </summary>
        ICollection<InvitationEntity> ReceivedInvitations { get; init; }

        /// <summary>
        /// Gets the collection of group-user relationships associated with the user.
        /// </summary>
        ICollection<GroupUserEntity> GroupUsers { get; init; }
    }
}