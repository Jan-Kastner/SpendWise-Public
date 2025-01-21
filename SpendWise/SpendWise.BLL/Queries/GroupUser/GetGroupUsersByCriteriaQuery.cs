using SpendWise.BLL.Queries.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.Queries
{
    internal class GetGroupUsersByCriteriaQuery : IGroupUserCriteriaQuery, IGroupUserIncludeQuery
    {
        #region Id
        /// <summary>
        /// Gets the unique identifier for the user.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        public Guid? NotId { get; set; }
        #endregion

        #region UserRole
        /// <summary>
        /// Gets the role of the user.
        /// </summary>
        public UserRole? UserRole { get; set; }

        /// <summary>
        /// Gets the role of the user that should not be included in the query result.
        /// </summary>
        public UserRole? NotUserRole { get; set; }
        #endregion

        #region GroupId
        /// <summary>
        /// Gets the unique identifier for the group.
        /// </summary>
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the group that should not be included in the query result.
        /// </summary>
        public Guid? NotGroupId { get; set; }
        #endregion

        #region UserId
        /// <summary>
        /// Gets the unique identifier for the user.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        public Guid? NotUserId { get; set; }
        #endregion

        #region Name
        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Gets the username of the user that should not be included in the query result.
        /// </summary>
        public string? NotUserName { get; set; }

        /// <summary>
        /// Gets the partial match for the username of the user.
        /// </summary>
        public string? UserNamePartialMatch { get; set; }

        /// <summary>
        /// Gets the partial match for the username of the user that should not be included in the query result.
        /// </summary>
        public string? NotUserNamePartialMatch { get; set; }
        #endregion

        #region Surname
        /// <summary>
        /// Gets the surname of the user.
        /// </summary>
        public string? UserSurname { get; set; }

        /// <summary>
        /// Gets the surname of the user that should not be included in the query result.
        /// </summary>
        public string? NotUserSurname { get; set; }

        /// <summary>
        /// Gets the partial match for the surname of the user.
        /// </summary>
        public string? UserSurnamePartialMatch { get; set; }

        /// <summary>
        /// Gets the partial match for the surname of the user that should not be included in the query result.
        /// </summary>
        public string? NotUserSurnamePartialMatch { get; set; }
        #endregion

        #region Email
        /// <summary>
        /// Gets the email of the user.
        /// </summary>
        public string? UserEmail { get; set; }

        /// <summary>
        /// Gets the email of the user that should not be included in the query result.
        /// </summary>
        public string? NotUserEmail { get; set; }
        #endregion

        #region Password
        /// <summary>
        /// Gets the password of the user.
        /// </summary>
        public string? UserPassword { get; set; }

        /// <summary>
        /// Gets the password of the user that should not be included in the query result.
        /// </summary>
        public string? NotUserPassword { get; set; }
        #endregion

        #region DateOfRegistration
        /// <summary>
        /// Gets the date of registration of the user.
        /// </summary>
        public DateTime? UserDateOfRegistration { get; set; }

        /// <summary>
        /// Gets the date of registration of the user that should not be included in the query result.
        /// </summary>
        public DateTime? NotUserDateOfRegistration { get; set; }
        #endregion

        #region Photo
        /// <summary>
        /// Indicates whether the user has a photo.
        /// </summary>
        public bool? WithUserPhoto { get; set; }
        #endregion

        #region EmailConfirmed
        /// <summary>
        /// Indicates whether the user's email is confirmed.
        /// </summary>
        public bool? WithUserEmailConfirmed { get; set; }
        #endregion

        #region TwoFactorEnabled
        /// <summary>
        /// Indicates whether the user has two-factor authentication enabled.
        /// </summary>
        public bool? WithUserTwoFactorEnabled { get; set; }
        #endregion

        #region ResetPasswordToken
        /// <summary>
        /// Gets the reset password token of the user.
        /// </summary>
        public string? UserResetPasswordToken { get; set; }

        /// <summary>
        /// Gets the reset password token of the user that should not be included in the query result.
        /// </summary>
        public string? NotUserResetPasswordToken { get; set; }

        /// <summary>
        /// Indicates whether the user does not have a reset password token.
        /// </summary>
        public bool? WithoutUserResetPasswordToken { get; set; }
        #endregion

        #region PreferredTheme
        /// <summary>
        /// Gets the preferred theme of the user.
        /// </summary>
        public Theme? UserPreferredTheme { get; set; }

        /// <summary>
        /// Gets the preferred theme of the user that should not be included in the query result.
        /// </summary>
        public Theme? NotUserPreferredTheme { get; set; }
        #endregion

        #region UserFullName
        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        public string? UserFullName { get; set; }

        /// <summary>
        /// Gets the full name of the user that should not be included in the query result.
        /// </summary>
        public string? NotUserFullName { get; set; }
        #endregion

        #region UserEmailDomain
        /// <summary>
        /// Gets the email domain of the user.
        /// </summary>
        public string? UserEmailDomain { get; set; }

        /// <summary>
        /// Gets the email domain of the user that should not be included in the query result.
        /// </summary>
        public string? NotUserEmailDomain { get; set; }
        #endregion

        #region UserSentInvitation

        /// <summary>
        /// Gets the unique identifier for the user that sent the invitation.
        /// </summary>
        public Guid? UserSentInvitationId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        public Guid? NotUserSentInvitationId { get; set; }

        #endregion

        #region UserReceivedInvitation

        /// <summary>
        /// Gets the unique identifier for the user that received the invitation.
        /// </summary>
        public Guid? UserReceivedInvitationId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the user that should not be included in the query result.
        /// </summary>
        public Guid? NotUserReceivedInvitationId { get; set; }

        #endregion

        #region Limit
        /// <summary>
        /// Gets the unique identifier for the limit.
        /// </summary>
        public Guid? LimitId { get; set; }

        /// <summary>
        /// Gets the unique identifier for the limit that should not be included in the query result.
        /// </summary>
        public Guid? NotLimitId { get; set; }

        /// <summary>
        /// Indicates whether the user does not have a limit.
        /// </summary>
        public bool? WithoutLimit { get; set; }
        #endregion

        #region IncludeOptions
        /// <summary>
        /// Indicates whether to include transactions in the query result.
        /// </summary>
        public bool IncludeTransactions { get; set; }

        /// <summary>
        /// Gets a value indicating whether to include user in the query result.
        /// </summary>
        public bool IncludeUser { get; set; }
        #endregion

        #region LogicalOperators
        /// <summary>
        /// Gets the list of query objects to combine with AND.
        /// </summary>
        public List<IGroupUserCriteriaQuery>? And { get; set; }

        /// <summary>
        /// Gets the list of query objects to combine with OR.
        /// </summary>
        public List<IGroupUserCriteriaQuery>? Or { get; set; }

        /// <summary>
        /// Gets the list of query objects to negate.
        /// </summary>
        public List<IGroupUserCriteriaQuery>? Not { get; set; }
        #endregion
    }
}