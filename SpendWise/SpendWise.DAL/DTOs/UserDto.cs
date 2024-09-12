﻿using System.ComponentModel.DataAnnotations;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a user.
    /// </summary>
    public record UserDto : IDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Surname { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user. Must be unique and at least 5 characters long.
        /// </summary>
        [MinLength(5)]
        [EmailAddress]
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the password hash for the user. Must be at least 8 characters long.
        /// </summary>
        [MinLength(8)]
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user registered.
        /// </summary>
        public required DateTime DateOfRegistration { get; set; }

        /// <summary>
        /// Gets or sets the photo of the user. Can be null.
        /// </summary>
        public required byte[] Photo { get; set; }

        /// <summary>
        /// Gets or sets whether the user's email has been confirmed.
        /// </summary>
        public required bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the email confirmation token used to verify the user's email address.
        /// </summary>
        public required string? EmailConfirmationToken { get; set; }

        /// <summary>
        /// Gets or sets the reset password token used to reset the user's password.
        /// </summary>
        public required string? ResetPasswordToken { get; set; }

        /// <summary>
        /// Gets or sets the expiration time of the reset password token.
        /// </summary>
        public required DateTime? ResetPasswordTokenExpiry { get; set; }

        /// <summary>
        /// Gets or sets the two-factor authentication (2FA) enabled status.
        /// </summary>
        public required bool IsTwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the two-factor authentication secret key.
        /// </summary>
        public required string? TwoFactorSecret { get; set; }

        /// <summary>
        /// Gets or sets the user's preferred theme for the application.
        /// </summary>
        public required Theme PreferredTheme { get; set; }
    }
}
