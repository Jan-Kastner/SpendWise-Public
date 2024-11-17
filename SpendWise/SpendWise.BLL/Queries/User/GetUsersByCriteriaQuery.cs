using SpendWise.BLL.Queries.Interfaces;
using SpendWise.Common.Enums;
using System;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving users based on various criteria.
    /// </summary>
    public class GetUsersByCriteriaQuery : IUserCriteriaQuery, IUserIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the user.
        /// </summary>
        public Guid? Id { get; }

        /// <summary>
        /// Gets the unique identifier of the user that should not match.
        /// </summary>
        public Guid? NotId { get; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Gets the name that should not match the user name.
        /// </summary>
        public string? NotName { get; }

        /// <summary>
        /// Gets the partial match for the user name.
        /// </summary>
        public string? NamePartialMatch { get; }

        /// <summary>
        /// Gets the partial match for the name that should not match the user name.
        /// </summary>
        public string? NotNamePartialMatch { get; }

        /// <summary>
        /// Gets the surname of the user.
        /// </summary>
        public string? Surname { get; }

        /// <summary>
        /// Gets the surname that should not match the user surname.
        /// </summary>
        public string? NotSurname { get; }

        /// <summary>
        /// Gets the partial match for the user surname.
        /// </summary>
        public string? SurnamePartialMatch { get; }

        /// <summary>
        /// Gets the partial match for the surname that should not match the user surname.
        /// </summary>
        public string? NotSurnamePartialMatch { get; }

        /// <summary>
        /// Gets the email of the user.
        /// </summary>
        public string? Email { get; }

        /// <summary>
        /// Gets the email that should not match the user email.
        /// </summary>
        public string? NotEmail { get; }

        /// <summary>
        /// Gets the password hash of the user.
        /// </summary>
        public string? PasswordHash { get; }

        /// <summary>
        /// Gets the password hash that should not match the user password hash.
        /// </summary>
        public string? NotPasswordHash { get; }

        /// <summary>
        /// Gets the date of registration of the user.
        /// </summary>
        public DateTime? DateOfRegistration { get; }

        /// <summary>
        /// Gets the date of registration that should not match the user date of registration.
        /// </summary>
        public DateTime? NotDateOfRegistration { get; }

        /// <summary>
        /// Gets a value indicating whether the user should have a photo.
        /// </summary>
        public bool? WithPhoto { get; }

        /// <summary>
        /// Gets a value indicating whether the user should not have a photo.
        /// </summary>
        public bool? NotWithPhoto { get; }

        /// <summary>
        /// Gets a value indicating whether the user's email should be confirmed.
        /// </summary>
        public bool? EmailConfirmed { get; }

        /// <summary>
        /// Gets a value indicating whether the user's email should not be confirmed.
        /// </summary>
        public bool? NotEmailConfirmed { get; }

        /// <summary>
        /// Gets a value indicating whether the user should have two-factor authentication enabled.
        /// </summary>
        public bool? TwoFactorEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the user should not have two-factor authentication enabled.
        /// </summary>
        public bool? NotTwoFactorEnabled { get; }

        /// <summary>
        /// Gets the reset password token of the user.
        /// </summary>
        public string? ResetPasswordToken { get; }

        /// <summary>
        /// Gets the reset password token that should not match the user reset password token.
        /// </summary>
        public string? NotResetPasswordToken { get; }

        /// <summary>
        /// Gets the preferred theme of the user.
        /// </summary>
        public Theme? PreferredTheme { get; }

        /// <summary>
        /// Gets the preferred theme that should not match the user preferred theme.
        /// </summary>
        public Theme? NotPreferredTheme { get; }

        /// <summary>
        /// Gets the unique identifier of the sent invitation.
        /// </summary>
        public Guid? SentInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the sent invitation that should not match.
        /// </summary>
        public Guid? NotSentInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the received invitation.
        /// </summary>
        public Guid? ReceivedInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the received invitation that should not match.
        /// </summary>
        public Guid? NotReceivedInvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the group user.
        /// </summary>
        public Guid? GroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the group user that should not match.
        /// </summary>
        public Guid? NotGroupUserId { get; }

        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        public string? FullName { get; }

        /// <summary>
        /// Gets the full name that should not match the user full name.
        /// </summary>
        public string? NotFullName { get; }

        /// <summary>
        /// Gets the email domain of the user.
        /// </summary>
        public string? EmailDomain { get; }

        /// <summary>
        /// Gets the email domain that should not match the user email domain.
        /// </summary>
        public string? NotEmailDomain { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group users in the query result.
        /// </summary>
        public bool IncludeGroupUsers { get; }

        /// <summary>
        /// Gets a value indicating whether to include the sent invitations in the query result.
        /// </summary>
        public bool IncludeSentInvitations { get; }

        /// <summary>
        /// Gets a value indicating whether to include the received invitations in the query result.
        /// </summary>
        public bool IncludeReceivedInvitations { get; }

        /// <summary>
        /// Gets a value indicating whether to include the groups in the query result.
        /// </summary>
        public bool IncludeGroups { get; }

        /// <summary>
        /// Gets a value indicating whether to include the group participants in the query result.
        /// </summary>
        public bool IncludeGroupParticipants { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="notId">The unique identifier of the user that should not match.</param>
        /// <param name="name">The name of the user.</param>
        /// <param name="notName">The name that should not match the user name.</param>
        /// <param name="namePartialMatch">The partial match for the user name.</param>
        /// <param name="notNamePartialMatch">The partial match for the name that should not match the user name.</param>
        /// <param name="surname">The surname of the user.</param>
        /// <param name="notSurname">The surname that should not match the user surname.</param>
        /// <param name="surnamePartialMatch">The partial match for the user surname.</param>
        /// <param name="notSurnamePartialMatch">The partial match for the surname that should not match the user surname.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="notEmail">The email that should not match the user email.</param>
        /// <param name="passwordHash">The password hash of the user.</param>
        /// <param name="notPasswordHash">The password hash that should not match the user password hash.</param>
        /// <param name="dateOfRegistration">The date of registration of the user.</param>
        /// <param name="notDateOfRegistration">The date of registration that should not match the user date of registration.</param>
        /// <param name="withPhoto">A value indicating whether the user should have a photo.</param>
        /// <param name="notWithPhoto">A value indicating whether the user should not have a photo.</param>
        /// <param name="emailConfirmed">A value indicating whether the user's email should be confirmed.</param>
        /// <param name="notEmailConfirmed">A value indicating whether the user's email should not be confirmed.</param>
        /// <param name="twoFactorEnabled">A value indicating whether the user should have two-factor authentication enabled.</param>
        /// <param name="notTwoFactorEnabled">A value indicating whether the user should not have two-factor authentication enabled.</param>
        /// <param name="resetPasswordToken">The reset password token of the user.</param>
        /// <param name="notResetPasswordToken">The reset password token that should not match the user reset password token.</param>
        /// <param name="preferredTheme">The preferred theme of the user.</param>
        /// <param name="notPreferredTheme">The preferred theme that should not match the user preferred theme.</param>
        /// <param name="sentInvitationId">The unique identifier of the sent invitation.</param>
        /// <param name="notSentInvitationId">The unique identifier of the sent invitation that should not match.</param>
        /// <param name="receivedInvitationId">The unique identifier of the received invitation.</param>
        /// <param name="notReceivedInvitationId">The unique identifier of the received invitation that should not match.</param>
        /// <param name="groupUserId">The unique identifier of the group user.</param>
        /// <param name="notGroupUserId">The unique identifier of the group user that should not match.</param>
        /// <param name="fullName">The full name of the user.</param>
        /// <param name="notFullName">The full name that should not match the user full name.</param>
        /// <param name="emailDomain">The email domain of the user.</param>
        /// <param name="notEmailDomain">The email domain that should not match the user email domain.</param>
        /// <param name="includeGroupUsers">A value indicating whether to include the group users in the query result. Default is false.</param>
        /// <param name="includeSentInvitations">A value indicating whether to include the sent invitations in the query result. Default is false.</param>
        /// <param name="includeReceivedInvitations">A value indicating whether to include the received invitations in the query result. Default is false.</param>
        /// <param name="includeGroups">A value indicating whether to include the groups in the query result. Default is false.</param>
        /// <param name="includeGroupParticipants">A value indicating whether to include the group participants in the query result. Default is false.</param>
        public GetUsersByCriteriaQuery(
            Guid? id = null,
            Guid? notId = null,
            string? name = null,
            string? notName = null,
            string? namePartialMatch = null,
            string? notNamePartialMatch = null,
            string? surname = null,
            string? notSurname = null,
            string? surnamePartialMatch = null,
            string? notSurnamePartialMatch = null,
            string? email = null,
            string? notEmail = null,
            string? passwordHash = null,
            string? notPasswordHash = null,
            DateTime? dateOfRegistration = null,
            DateTime? notDateOfRegistration = null,
            bool? withPhoto = null,
            bool? notWithPhoto = null,
            bool? emailConfirmed = null,
            bool? notEmailConfirmed = null,
            bool? twoFactorEnabled = null,
            bool? notTwoFactorEnabled = null,
            string? resetPasswordToken = null,
            string? notResetPasswordToken = null,
            Theme? preferredTheme = null,
            Theme? notPreferredTheme = null,
            Guid? sentInvitationId = null,
            Guid? notSentInvitationId = null,
            Guid? receivedInvitationId = null,
            Guid? notReceivedInvitationId = null,
            Guid? groupUserId = null,
            Guid? notGroupUserId = null,
            string? fullName = null,
            string? notFullName = null,
            string? emailDomain = null,
            string? notEmailDomain = null,
            bool includeGroupUsers = false,
            bool includeSentInvitations = false,
            bool includeReceivedInvitations = false,
            bool includeGroups = false,
            bool includeGroupParticipants = false)
        {
            Id = id;
            NotId = notId;
            Name = name;
            NotName = notName;
            NamePartialMatch = namePartialMatch;
            NotNamePartialMatch = notNamePartialMatch;
            Surname = surname;
            NotSurname = notSurname;
            SurnamePartialMatch = surnamePartialMatch;
            NotSurnamePartialMatch = notSurnamePartialMatch;
            Email = email;
            NotEmail = notEmail;
            PasswordHash = passwordHash;
            NotPasswordHash = notPasswordHash;
            DateOfRegistration = dateOfRegistration;
            NotDateOfRegistration = notDateOfRegistration;
            WithPhoto = withPhoto;
            NotWithPhoto = notWithPhoto;
            EmailConfirmed = emailConfirmed;
            NotEmailConfirmed = notEmailConfirmed;
            TwoFactorEnabled = twoFactorEnabled;
            NotTwoFactorEnabled = notTwoFactorEnabled;
            ResetPasswordToken = resetPasswordToken;
            NotResetPasswordToken = notResetPasswordToken;
            PreferredTheme = preferredTheme;
            NotPreferredTheme = notPreferredTheme;
            SentInvitationId = sentInvitationId;
            NotSentInvitationId = notSentInvitationId;
            ReceivedInvitationId = receivedInvitationId;
            NotReceivedInvitationId = notReceivedInvitationId;
            GroupUserId = groupUserId;
            NotGroupUserId = notGroupUserId;
            FullName = fullName;
            NotFullName = notFullName;
            EmailDomain = emailDomain;
            NotEmailDomain = notEmailDomain;
            IncludeGroupUsers = includeGroupUsers;
            IncludeSentInvitations = includeSentInvitations;
            IncludeReceivedInvitations = includeReceivedInvitations;
            IncludeGroups = includeGroups;
            IncludeGroupParticipants = includeGroupParticipants;
        }
    }
}