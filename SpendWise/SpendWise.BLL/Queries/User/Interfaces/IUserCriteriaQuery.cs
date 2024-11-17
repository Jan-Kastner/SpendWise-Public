using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for user criteria-based queries.
    /// </summary>
    public interface IUserCriteriaQuery : ICriteriaQuery
    {
        /// <summary>
        /// Gets the unique identifier of the user that should not match.
        /// </summary>
        Guid? NotId { get; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        string? Name { get; }

        /// <summary>
        /// Gets the name that should not match the user name.
        /// </summary>
        string? NotName { get; }

        /// <summary>
        /// Gets the partial match for the user name.
        /// </summary>
        string? NamePartialMatch { get; }

        /// <summary>
        /// Gets the partial match for the name that should not match the user name.
        /// </summary>
        string? NotNamePartialMatch { get; }

        /// <summary>
        /// Gets the surname of the user.
        /// </summary>
        string? Surname { get; }

        /// <summary>
        /// Gets the surname that should not match the user surname.
        /// </summary>
        string? NotSurname { get; }

        /// <summary>
        /// Gets the partial match for the user surname.
        /// </summary>
        string? SurnamePartialMatch { get; }

        /// <summary>
        /// Gets the partial match for the surname that should not match the user surname.
        /// </summary>
        string? NotSurnamePartialMatch { get; }

        /// <summary>
        /// Gets the email of the user.
        /// </summary>
        string? Email { get; }

        /// <summary>
        /// Gets the email that should not match the user email.
        /// </summary>
        string? NotEmail { get; }

        /// <summary>
        /// Gets the password hash of the user.
        /// </summary>
        string? PasswordHash { get; }

        /// <summary>
        /// Gets the password hash that should not match the user password hash.
        /// </summary>
        string? NotPasswordHash { get; }

        /// <summary>
        /// Gets the date of registration of the user.
        /// </summary>
        DateTime? DateOfRegistration { get; }

        /// <summary>
        /// Gets the date of registration that should not match the user date of registration.
        /// </summary>
        DateTime? NotDateOfRegistration { get; }

        /// <summary>
        /// Gets a value indicating whether the user should have a photo.
        /// </summary>
        bool? WithPhoto { get; }

        /// <summary>
        /// Gets a value indicating whether the user should not have a photo.
        /// </summary>
        bool? NotWithPhoto { get; }

        /// <summary>
        /// Gets a value indicating whether the user's email should be confirmed.
        /// </summary>
        bool? EmailConfirmed { get; }

        /// <summary>
        /// Gets a value indicating whether the user's email should not be confirmed.
        /// </summary>
        bool? NotEmailConfirmed { get; }

        /// <summary>
        /// Gets a value indicating whether the user should have two-factor authentication enabled.
        /// </summary>
        bool? TwoFactorEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the user should not have two-factor authentication enabled.
        /// </summary>
        bool? NotTwoFactorEnabled { get; }

        /// <summary>
        /// Gets the reset password token of the user.
        /// </summary>
        string? ResetPasswordToken { get; }

        /// <summary>
        /// Gets the reset password token that should not match the user reset password token.
        /// </summary>
        string? NotResetPasswordToken { get; }

        /// <summary>
        /// Gets the preferred theme of the user.
        /// </summary>
        Theme? PreferredTheme { get; }

        /// <summary>
        /// Gets the preferred theme that should not match the user preferred theme.
        /// </summary>
        Theme? NotPreferredTheme { get; }

        /// <summary>
        /// Gets the unique identifier of the sent invitation.
        /// </summary>
        Guid? SentInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the sent invitation that should not match.
        /// </summary>
        Guid? NotSentInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the received invitation.
        /// </summary>
        Guid? ReceivedInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the received invitation that should not match.
        /// </summary>
        Guid? NotReceivedInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the group user.
        /// </summary>
        Guid? GroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the group user that should not match.
        /// </summary>
        Guid? NotGroupUserId { get; }

        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        string? FullName { get; }

        /// <summary>
        /// Gets the full name that should not match the user full name.
        /// </summary>
        string? NotFullName { get; }

        /// <summary>
        /// Gets the email domain of the user.
        /// </summary>
        string? EmailDomain { get; }

        /// <summary>
        /// Gets the email domain that should not match the user email domain.
        /// </summary>
        string? NotEmailDomain { get; }
    }
}