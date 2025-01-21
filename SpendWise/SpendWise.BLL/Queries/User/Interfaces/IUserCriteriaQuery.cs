using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for user criteria-based queries.
    /// </summary>
    public interface IUserCriteriaQuery : ICriteriaQuery<IUserCriteriaQuery>
    {
        #region Name

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

        #endregion

        #region Surname

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

        #endregion

        #region Email

        /// <summary>
        /// Gets the email of the user.
        /// </summary>
        string? Email { get; }

        /// <summary>
        /// Gets the email that should not match the user email.
        /// </summary>
        string? NotEmail { get; }

        #endregion

        #region Password

        /// <summary>
        /// Gets the password hash of the user.
        /// </summary>
        string? PasswordHash { get; }

        #endregion

        #region DateOfRegistration

        /// <summary>
        /// Gets the date of registration of the user.
        /// </summary>
        DateTime? DateOfRegistration { get; }

        /// <summary>
        /// Gets the date of registration that should not match the user date of registration.
        /// </summary>
        DateTime? NotDateOfRegistration { get; }

        #endregion

        #region Photo

        /// <summary>
        /// Gets a value indicating whether the user should have a photo.
        /// </summary>
        bool? WithPhoto { get; }

        #endregion

        #region EmailConfirmed

        /// <summary>
        /// Gets a value indicating whether the user's email should be confirmed.
        /// </summary>
        bool? EmailConfirmed { get; }

        #endregion

        #region TwoFactorEnabled

        /// <summary>
        /// Gets a value indicating whether the user should have two-factor authentication enabled.
        /// </summary>
        bool? TwoFactorEnabled { get; }

        #endregion

        #region ResetPasswordToken

        /// <summary>
        /// Gets the reset password token of the user.
        /// </summary>
        string? ResetPasswordToken { get; }

        #endregion

        #region PreferredTheme

        /// <summary>
        /// Gets the preferred theme of the user.
        /// </summary>
        Theme? PreferredTheme { get; }

        /// <summary>
        /// Gets the preferred theme that should not match the user preferred theme.
        /// </summary>
        Theme? NotPreferredTheme { get; }

        #endregion

        #region SentInvitation

        /// <summary>
        /// Gets the unique identifier of the sent invitation.
        /// </summary>
        Guid? SentInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the sent invitation that should not match.
        /// </summary>
        Guid? NotSentInvitationId { get; }

        #endregion

        #region ReceivedInvitation

        /// <summary>
        /// Gets the unique identifier of the received invitation.
        /// </summary>
        Guid? ReceivedInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the received invitation that should not match.
        /// </summary>
        Guid? NotReceivedInvitationId { get; }

        #endregion

        #region Group

        /// <summary>
        /// Gets the unique identifier of the group user.
        /// </summary>
        Guid? GroupId { get; }

        /// <summary>
        /// Gets the unique identifier of the group user that should not match.
        /// </summary>
        Guid? NotGroupId { get; }

        #endregion

        #region FullName

        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        string? FullName { get; }

        /// <summary>
        /// Gets the full name that should not match the user full name.
        /// </summary>
        string? NotFullName { get; }

        #endregion

        #region EmailDomain

        /// <summary>
        /// Gets the email domain of the user.
        /// </summary>
        string? EmailDomain { get; }

        /// <summary>
        /// Gets the email domain that should not match the user email domain.
        /// </summary>
        string? NotEmailDomain { get; }

        #endregion
    }
}