using System;
using System.Linq;
using SpendWise.Common.Enums;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="UserEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class UserQueryObject : BaseQueryObject<UserEntity, UserQueryObject>, IUserQueryObject<UserQueryObject>
    {
        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithId(Guid id) => base.WithId(id);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithId(Guid id) => base.OrWithId(id);

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithId(Guid id) => base.NotWithId(id);

        #endregion

        #region INameQuery

        /// <summary>
        /// Filters the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithName(string name) => base.WithName(name);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithName(string name) => base.OrWithName(name);

        /// <summary>
        /// Filters the query to exclude items with the specified name.
        /// </summary>
        /// <param name="name">The name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithName(string name) => base.NotWithName(name);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithNamePartialMatch(string text) => base.WithNamePartialMatch(text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithNamePartialMatch(string text) => base.OrWithNamePartialMatch(text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithNamePartialMatch(string text) => base.NotWithNamePartialMatch(text);

        #endregion

        #region ISurnameQuery

        /// <summary>
        /// Filters the query to include items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithSurname(string surname) => base.WithSurname(surname);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithSurname(string surname) => base.OrWithSurname(surname);

        /// <summary>
        /// Filters the query to exclude items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithSurname(string surname) => base.NotWithSurname(surname);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithSurnamePartialMatch(string text) => base.WithSurnamePartialMatch(text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithSurnamePartialMatch(string text) => base.OrWithSurnamePartialMatch(text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithSurnamePartialMatch(string text) => base.NotWithSurnamePartialMatch(text);

        #endregion

        #region IEmailQuery

        /// <summary>
        /// Filters the query to include items with the specified email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithEmail(string email) => base.WithEmail(email);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithEmail(string email) => base.OrWithEmail(email);

        /// <summary>
        /// Filters the query to exclude items with the specified email.
        /// </summary>
        /// <param name="email">The email to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithEmail(string email) => base.NotWithEmail(email);

        #endregion

        #region IPasswordQuery

        /// <summary>
        /// Filters the query to include items with the specified password.
        /// </summary>
        /// <param name="password">The password to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithPassword(string password) => base.WithPassword(password);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified password.
        /// </summary>
        /// <param name="password">The password to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithPassword(string password) => base.OrWithPassword(password);

        /// <summary>
        /// Filters the query to exclude items with the specified password.
        /// </summary>
        /// <param name="password">The password to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithPassword(string password) => base.NotWithPassword(password);

        #endregion

        #region IDateOfRegistrationQuery

        /// <summary>
        /// Filters the query to include items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithDateOfRegistration(DateTime dateOfRegistration) => base.WithDateOfRegistration(dateOfRegistration);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithDateOfRegistration(DateTime dateOfRegistration) => base.OrWithDateOfRegistration(dateOfRegistration);

        /// <summary>
        /// Filters the query to exclude items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithDateOfRegistration(DateTime dateOfRegistration) => base.NotWithDateOfRegistration(dateOfRegistration);

        #endregion

        #region IPhotoQuery

        /// <summary>
        /// Filters the query to include items with a photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithPhoto() => base.WithPhoto();

        /// <summary>
        /// Adds an OR condition to the query to include items with a photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithPhoto() => base.OrWithPhoto();

        /// <summary>
        /// Filters the query to exclude items with a photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithPhoto() => base.NotWithPhoto();

        /// <summary>
        /// Filters the query to include items without a photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithoutPhoto() => base.WithoutPhoto();

        /// <summary>
        /// Adds an OR condition to the query to include items without a photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithoutPhoto() => base.OrWithoutPhoto();

        /// <summary>
        /// Filters the query to exclude items without a photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithoutPhoto() => base.NotWithoutPhoto();

        #endregion

        #region IEmailConfirmedQuery

        /// <summary>
        /// Filters the query to include items with confirmed email.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithEmailConfirmed() => base.WithEmailConfirmed(true);

        /// <summary>
        /// Adds an OR condition to the query to include items with confirmed email.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithEmailConfirmed() => base.OrWithEmailConfirmed(true);

        /// <summary>
        /// Filters the query to exclude items with confirmed email.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithEmailConfirmed() => base.NotWithEmailConfirmed(true);

        /// <summary>
        /// Filters the query to include items without confirmed email.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithoutEmailConfirmed() => base.WithEmailConfirmed(false);

        /// <summary>
        /// Adds an OR condition to the query to include items without confirmed email.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithoutEmailConfirmed() => base.OrWithEmailConfirmed(false);

        /// <summary>
        /// Filters the query to exclude items without confirmed email.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithoutEmailConfirmed() => base.NotWithEmailConfirmed(false);

        #endregion

        #region ITwoFactorEnabledQuery

        /// <summary>
        /// Filters the query to include items with two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithTwoFactorEnabled() => base.WithTwoFactorEnabled(true);

        /// <summary>
        /// Adds an OR condition to the query to include items with two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithTwoFactorEnabled() => base.OrWithTwoFactorEnabled(true);

        /// <summary>
        /// Filters the query to exclude items with two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithTwoFactorEnabled() => base.NotWithTwoFactorEnabled(true);

        /// <summary>
        /// Filters the query to include items without two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithoutTwoFactorEnabled() => base.WithTwoFactorEnabled(false);

        /// <summary>
        /// Adds an OR condition to the query to include items without two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithoutTwoFactorEnabled() => base.OrWithTwoFactorEnabled(false);

        /// <summary>
        /// Filters the query to exclude items without two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithoutTwoFactorEnabled() => base.NotWithTwoFactorEnabled(false);

        #endregion

        #region IResetPasswordTokenQuery

        /// <summary>
        /// Filters the query to include items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithResetPasswordToken(string token) => base.WithResetPasswordToken(token);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithResetPasswordToken(string token) => base.OrWithResetPasswordToken(token);

        /// <summary>
        /// Filters the query to exclude items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithResetPasswordToken(string token) => base.NotWithResetPasswordToken(token);

        /// <summary>
        /// Filters the query to include items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithoutResetPasswordToken() => base.WithoutResetPasswordToken();

        /// <summary>
        /// Adds an OR condition to the query to include items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithoutResetPasswordToken() => base.OrWithoutResetPasswordToken();

        /// <summary>
        /// Filters the query to exclude items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithoutResetPasswordToken() => base.NotWithoutResetPasswordToken();

        #endregion

        #region IPreferredThemeQuery

        /// <summary>
        /// Filters the query to include items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new UserQueryObject WithPreferredTheme(Theme theme) => base.WithPreferredTheme(theme);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new UserQueryObject OrWithPreferredTheme(Theme theme) => base.OrWithPreferredTheme(theme);

        /// <summary>
        /// Filters the query to exclude items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new UserQueryObject NotWithPreferredTheme(Theme theme) => base.NotWithPreferredTheme(theme);

        #endregion

        #region ISentInvitationQuery

        /// <summary>
        /// Filters the query to include items with the specified sent invitation ID.
        /// </summary>
        /// <param name="invitationId">The sent invitation ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithSentInvitation(Guid invitationId)
        {
            And(entity => entity.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified sent invitation ID.
        /// </summary>
        /// <param name="invitationId">The sent invitation ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithSentInvitation(Guid invitationId)
        {
            Or(entity => entity.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified sent invitation ID.
        /// </summary>
        /// <param name="invitationId">The sent invitation ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithSentInvitation(Guid invitationId)
        {
            Not(entity => entity.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        #endregion

        #region IReceivedInvitationQuery

        /// <summary>
        /// Filters the query to include items with the specified received invitation ID.
        /// </summary>
        /// <param name="invitationId">The received invitation ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithReceivedInvitation(Guid invitationId)
        {
            And(entity => entity.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified received invitation ID.
        /// </summary>
        /// <param name="invitationId">The received invitation ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithReceivedInvitation(Guid invitationId)
        {
            Or(entity => entity.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified received invitation ID.
        /// </summary>
        /// <param name="invitationId">The received invitation ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithReceivedInvitation(Guid invitationId)
        {
            Not(entity => entity.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        #endregion

        #region IGroupUserQuery

        /// <summary>
        /// Filters the query to include items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithGroupUser(Guid groupUserId)
        {
            And(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithGroupUser(Guid groupUserId)
        {
            Or(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified group user ID.
        /// </summary>
        /// <param name="groupUserId">The group user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithGroupUser(Guid groupUserId)
        {
            Not(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        #endregion

        #region FULL NAME AND EMAIL DOMAIN FILTERS

        /// <summary>
        /// Filters the query to include items with the specified full name.
        /// </summary>
        /// <param name="fullName">The full name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithFullName(string fullName)
        {
            And(entity => (entity.Name + " " + entity.Surname).Contains(fullName));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified full name.
        /// </summary>
        /// <param name="fullName">The full name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithFullName(string fullName)
        {
            Or(entity => (entity.Name + " " + entity.Surname).Contains(fullName));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified full name.
        /// </summary>
        /// <param name="fullName">The full name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithFullName(string fullName)
        {
            Not(entity => (entity.Name + " " + entity.Surname).Contains(fullName));
            return this;
        }

        /// <summary>
        /// Filters the query to include items with the specified email domain.
        /// </summary>
        /// <param name="domain">The email domain to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithEmailDomain(string domain)
        {
            And(entity => entity.Email.EndsWith("@" + domain));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified email domain.
        /// </summary>
        /// <param name="domain">The email domain to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithEmailDomain(string domain)
        {
            Or(entity => entity.Email.EndsWith("@" + domain));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified email domain.
        /// </summary>
        /// <param name="domain">The email domain to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithEmailDomain(string domain)
        {
            Not(entity => entity.Email.EndsWith("@" + domain));
            return this;
        }

        #endregion
    }
}