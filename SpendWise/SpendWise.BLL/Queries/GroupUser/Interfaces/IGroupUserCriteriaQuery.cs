using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for group user criteria-based queries.
    /// </summary>
    internal interface IGroupUserCriteriaQuery : ICriteriaQuery<IGroupUserCriteriaQuery>
    {
        #region Id
        /// <summary>
        /// Gets the unique identifier for the user.
        /// </summary>
        Guid? Id { get; set; }

        /// <summary>
        /// Gets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        Guid? NotId { get; set; }

        #endregion

        #region UserRole

        /// <summary>
        /// Gets the role of the user.
        /// </summary>
        UserRole? UserRole { get; set; }

        /// <summary>
        /// Gets the role of the user that should not be included in the query result.
        /// </summary>
        UserRole? NotUserRole { get; set; }

        #endregion

        #region GroupId

        /// <summary>
        /// Gets the unique identifier for the group.
        /// </summary>
        Guid? GroupId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the group that should not be included in the query result.
        /// </summary>
        Guid? NotGroupId { get; set; }

        #endregion

        #region UserId

        /// <summary>
        /// Gets the unique identifier for the user.
        /// </summary>
        Guid? UserId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        Guid? NotUserId { get; set; }

        #endregion

        #region Name

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        string? UserName { get; set; }

        /// <summary>
        /// Gets the username of the user that should not be included in the query result.
        /// </summary>
        string? NotUserName { get; set; }

        /// <summary>
        /// Gets the partial match for the username of the user.
        /// </summary>
        string? UserNamePartialMatch { get; set; }

        /// <summary>
        /// Gets the partial match for the username of the user that should not be included in the query result.
        /// </summary>
        string? NotUserNamePartialMatch { get; set; }

        #endregion

        #region Surname

        /// <summary>
        /// Gets the surname of the user.
        /// </summary>
        string? UserSurname { get; set; }

        /// <summary>
        /// Gets the surname of the user that should not be included in the query result.
        /// </summary>
        string? NotUserSurname { get; set; }

        /// <summary>
        /// Gets the partial match for the surname of the user.
        /// </summary>
        string? UserSurnamePartialMatch { get; set; }

        /// <summary>
        /// Gets the partial match for the surname of the user that should not be included in the query result.
        /// </summary>
        string? NotUserSurnamePartialMatch { get; set; }

        #endregion

        #region Email

        /// <summary>
        /// Gets the email of the user.
        /// </summary>
        string? UserEmail { get; set; }

        /// <summary>
        /// Gets the email of the user that should not be included in the query result.
        /// </summary>
        string? NotUserEmail { get; set; }

        #endregion

        #region Password

        /// <summary>
        /// Gets the password of the user.
        /// </summary>
        string? UserPassword { get; set; }

        /// <summary>
        /// Gets the password of the user that should not be included in the query result.
        /// </summary>
        string? NotUserPassword { get; set; }

        #endregion

        #region DateOfRegistration

        /// <summary>
        /// Gets the date of registration of the user.
        /// </summary>
        DateTime? UserDateOfRegistration { get; set; }

        /// <summary>
        /// Gets the date of registration of the user that should not be included in the query result.
        /// </summary>
        DateTime? NotUserDateOfRegistration { get; set; }

        #endregion

        #region WithPhoto

        /// <summary>
        /// Indicates whether the user has a photo.
        /// </summary>
        bool? WithUserPhoto { get; set; }

        #endregion

        #region WithEmailConfirmed
        /// <summary>
        /// Indicates whether the user's email is confirmed.
        /// </summary>
        bool? WithUserEmailConfirmed { get; set; }

        #endregion

        #region WitTwoFactorEnabled

        /// <summary>
        /// Indicates whether the user has two-factor authentication enabled.
        /// </summary>
        bool? WithUserTwoFactorEnabled { get; set; }

        #endregion

        #region ResetPasswordToken

        /// <summary>
        /// Gets the reset password token of the user.
        /// </summary>
        string? UserResetPasswordToken { get; set; }

        /// <summary>
        /// Indicates whether the user does not have a reset password token.
        /// </summary>
        bool? WithoutUserResetPasswordToken { get; set; }

        #endregion

        #region PreferredTheme

        /// <summary>
        /// Gets the preferred theme of the user.
        /// </summary>
        Theme? UserPreferredTheme { get; set; }

        /// <summary>
        /// Gets the preferred theme of the user that should not be included in the query result.
        /// </summary>
        Theme? NotUserPreferredTheme { get; set; }

        #endregion

        #region UserSentInvitation

        /// <summary>
        /// Gets the unique identifier for the user that sent the invitation.
        /// </summary>
        Guid? UserSentInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        Guid? NotUserSentInvitationId { get; }

        #endregion

        #region UserReceivedInvitation

        /// <summary>
        /// Gets the unique identifier for the user that received the invitation.
        /// </summary>
        Guid? UserReceivedInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        Guid? NotUserReceivedInvitationId { get; }

        #endregion

        #region UserFullName

        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        string? UserFullName { get; set; }

        /// <summary>
        /// Gets the full name of the user that should not be included in the query result.
        /// </summary>
        string? NotUserFullName { get; set; }

        #endregion

        #region UserEmailDomain

        /// <summary>
        /// Gets the email domain of the user.
        /// </summary>
        string? UserEmailDomain { get; set; }

        /// <summary>
        /// Gets the email domain of the user that should not be included in the query result.
        /// </summary>
        string? NotUserEmailDomain { get; set; }

        #endregion

        #region Limit
        /// <summary>
        /// Gets the unique identifier for the limit.
        /// </summary>
        Guid? LimitId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the limit that should not be included in the query result.
        /// </summary>
        Guid? NotLimitId { get; set; }

        /// <summary>
        /// Indicates whether the user does not have a limit.
        /// </summary>
        bool? WithoutLimit { get; set; }
        #endregion
    }
}