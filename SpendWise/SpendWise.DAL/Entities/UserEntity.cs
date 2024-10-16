using System.ComponentModel.DataAnnotations;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a user entity within the SpendWise application.
    /// </summary>
    public record UserEntity : IUserEntity
    {
        /// <summary>
        /// Gets or inits the unique identifier for the user.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or inits the name of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Name { get; init; }

        /// <summary>
        /// Gets or inits the surname of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Surname { get; init; }

        /// <summary>
        /// Gets or inits the email address of the user. Must be unique and at least 5 characters long.
        /// </summary>
        [MinLength(5)]
        [EmailAddress]
        public required string Email { get; init; }

        /// <summary>
        /// Gets or inits the hashed password for the user. Must be at least 8 characters long.
        /// </summary>
        [MinLength(8)]
        public required string PasswordHash { get; init; }

        /// <summary>
        /// Gets or inits the date and time when the user registered.
        /// </summary>
        public required DateTime DateOfRegistration { get; init; }

        /// <summary>
        /// Gets or inits the photo of the user. Can be null.
        /// </summary>
        public required byte[] Photo { get; init; } = Array.Empty<byte>();

        /// <summary>
        /// Gets or inits whether the user's email has been confirmed.
        /// </summary>
        public required bool IsEmailConfirmed { get; init; } = false;

        /// <summary>
        /// Gets or inits the email confirmation token used to verify the user's email address.
        /// </summary>
        public required string? EmailConfirmationToken { get; init; } = null;

        /// <summary>
        /// Gets or sets the reset password token used to reset the user's password.
        /// </summary>
        public required string? ResetPasswordToken { get; init; } = null;

        /// <summary>
        /// Gets or sets the reset password token used to reset the user's password.
        /// </summary>
        public required DateTime? ResetPasswordTokenExpiry { get; init; } = null;

        /// <summary>
        /// Gets or inits the reinit password token used to reinit the user's password.
        /// </summary>
        public required string? ReinitPasswordToken { get; init; } = null;

        /// <summary>
        /// Gets or inits the expiration time of the reinit password token.
        /// </summary>
        public required DateTime? ReinitPasswordTokenExpiry { get; init; } = null;

        /// <summary>
        /// Gets or inits the two-factor authentication (2FA) enabled status.
        /// </summary>
        public required bool IsTwoFactorEnabled { get; init; } = false;

        /// <summary>
        /// Gets or inits the two-factor authentication secret key.
        /// </summary>
        public required string? TwoFactorSecret { get; init; } = null;

        /// <summary>
        /// Gets or inits the user's preferred theme for the application.
        /// </summary>
        public required Theme PreferredTheme { get; init; } = Theme.SystemDefault;

        /// <summary>
        /// Gets the collection of invitations sent by the user.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the invitations that the user has sent.
        /// </remarks>
        public required ICollection<InvitationEntity> SentInvitations { get; init; } = new List<InvitationEntity>();

        /// <summary>
        /// Gets the collection of invitations received by the user.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the invitations that the user has received.
        /// </remarks>
        public required ICollection<InvitationEntity> ReceivedInvitations { get; init; } = new List<InvitationEntity>();

        /// <summary>
        /// Gets the collection of group-user relationships associated with the user.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the group-user relationships in which the user is involved.
        /// </remarks>
        public required ICollection<GroupUserEntity> GroupUsers { get; init; } = new List<GroupUserEntity>();
    }
}
