using SpendWise.Common.Enums;
using SpendWise.DAL.Entities;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces;
using SpendWise.DAL.QueryObjects.Interfaces;
using System.Linq.Expressions;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="UserEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class UserQueryObject : BaseQueryObject<UserEntity, UserQueryObject>, IUserQueryObject
    {
        private UserEntityRelationsConfig _relations = new UserEntityRelationsConfig();

        /// <summary>
        /// Gets the initial state for user relations.
        /// </summary>
        public IUserEntityInitialState Relations => _relations;

        /// <summary>
        /// Gets the list of include properties for the query.
        /// </summary>
        public override List<string> Includes => _relations.Includes;

        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public override ICollection<Func<UserEntity, object>> IncludeDirectives { get; } = new List<Func<UserEntity, object>>
        {
            entity => entity.GroupUsers,
            entity => entity.SentInvitations,
            entity => entity.ReceivedInvitations,
            entity => entity.GroupUsers.Select(gu => gu.Group),
            entity => entity.GroupUsers.Select(gu => gu.Group.GroupUsers.Select(ggu => ggu.User)),
            entity => entity.GroupUsers.Select(gu => gu.TransactionGroupUsers.Select(tgu => tgu.Transaction)),
        };

        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region INameQuery

        /// <summary>
        /// Filters the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithName(string name) => ApplyNameFilter(name, entity => entity.Name, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithName(string name) => ApplyNameFilter(name, entity => entity.Name, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified name.
        /// </summary>
        /// <param name="name">The name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithName(string name) => ApplyNameFilter(name, entity => entity.Name, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.Name, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.Name, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.Name, filter => Not(filter), true);

        #endregion

        #region ISurnameQuery

        /// <summary>
        /// Filters the query to include items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithSurname(string surname) => ApplySurnameFilter(entity => entity.Surname, surname, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithSurname(string surname) => ApplySurnameFilter(entity => entity.Surname, surname, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithSurname(string surname) => ApplySurnameFilter(entity => entity.Surname, surname, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithSurnamePartialMatch(string text) => ApplySurnameFilter(entity => entity.Surname, text, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithSurnamePartialMatch(string text) => ApplySurnameFilter(entity => entity.Surname, text, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithSurnamePartialMatch(string text) => ApplySurnameFilter(entity => entity.Surname, text, filter => Not(filter), true);

        #endregion

        #region IEmailQuery

        /// <summary>
        /// Filters the query to include items with the specified email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithEmail(string email) => ApplyEmailFilter(entity => entity.Email, email, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithEmail(string email) => ApplyEmailFilter(entity => entity.Email, email, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified email.
        /// </summary>
        /// <param name="email">The email to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithEmail(string email) => ApplyEmailFilter(entity => entity.Email, email, filter => Not(filter));

        #endregion

        #region IPasswordQuery

        /// <summary>
        /// Filters the query to include items with the specified password.
        /// </summary>
        /// <param name="password">The password to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithPassword(string password) => ApplyPasswordFilter(entity => entity.PasswordHash, password, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified password.
        /// </summary>
        /// <param name="password">The password to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithPassword(string password) => ApplyPasswordFilter(entity => entity.PasswordHash, password, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified password.
        /// </summary>
        /// <param name="password">The password to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithPassword(string password) => ApplyPasswordFilter(entity => entity.PasswordHash, password, filter => Not(filter));

        #endregion

        #region IDateOfRegistrationQuery

        /// <summary>
        /// Filters the query to include items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithDateOfRegistration(DateTime dateOfRegistration) => ApplyDateOfRegistrationFilter(entity => entity.DateOfRegistration, dateOfRegistration, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithDateOfRegistration(DateTime dateOfRegistration) => ApplyDateOfRegistrationFilter(entity => entity.DateOfRegistration, dateOfRegistration, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithDateOfRegistration(DateTime dateOfRegistration) => ApplyDateOfRegistrationFilter(entity => entity.DateOfRegistration, dateOfRegistration, filter => Not(filter));

        #endregion

        #region IPhotoQuery

        /// <summary>
        /// Filters the query to include items with a photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithPhoto() => ApplyPhotoFilter(entity => entity.Photo, true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with a photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithPhoto() => ApplyPhotoFilter(entity => entity.Photo, true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with a photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithPhoto() => ApplyPhotoFilter(entity => entity.Photo, true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without a photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithoutPhoto() => ApplyPhotoFilter(entity => entity.Photo, false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without a photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithoutPhoto() => ApplyPhotoFilter(entity => entity.Photo, false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without a photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithoutPhoto() => ApplyPhotoFilter(entity => entity.Photo, false, filter => Not(filter));

        #endregion

        #region IEmailConfirmedQuery

        /// <summary>
        /// Filters the query to include items with confirmed email.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.IsEmailConfirmed, true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with confirmed email.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.IsEmailConfirmed, true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with confirmed email.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.IsEmailConfirmed, true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without confirmed email.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithoutEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.IsEmailConfirmed, false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without confirmed email.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithoutEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.IsEmailConfirmed, false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without confirmed email.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithoutEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.IsEmailConfirmed, false, filter => Not(filter));

        #endregion

        #region ITwoFactorEnabledQuery

        /// <summary>
        /// Filters the query to include items with two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.IsTwoFactorEnabled, true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.IsTwoFactorEnabled, true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.IsTwoFactorEnabled, true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithoutTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.IsTwoFactorEnabled, false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithoutTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.IsTwoFactorEnabled, false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithoutTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.IsTwoFactorEnabled, false, filter => Not(filter));

        #endregion

        #region IResetPasswordTokenQuery

        /// <summary>
        /// Filters the query to include items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithResetPasswordToken(string token) => ApplyResetPasswordTokenFilter(entity => entity.ResetPasswordToken, token, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithResetPasswordToken(string token) => ApplyResetPasswordTokenFilter(entity => entity.ResetPasswordToken, token, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithResetPasswordToken(string token) => ApplyResetPasswordTokenFilter(entity => entity.ResetPasswordToken, token, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithoutResetPasswordToken() => ApplyResetPasswordTokenFilter(entity => entity.ResetPasswordToken, null, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithoutResetPasswordToken() => ApplyResetPasswordTokenFilter(entity => entity.ResetPasswordToken, null, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithoutResetPasswordToken() => ApplyResetPasswordTokenFilter(entity => entity.ResetPasswordToken, null, filter => Not(filter));

        #endregion

        #region IPreferredThemeQuery

        /// <summary>
        /// Filters the query to include items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public UserQueryObject WithPreferredTheme(Theme theme) => ApplyPreferredThemeFilter(entity => entity.PreferredTheme, theme, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public UserQueryObject OrWithPreferredTheme(Theme theme) => ApplyPreferredThemeFilter(entity => entity.PreferredTheme, theme, filter => Or(filter));
        /// <summary>
        /// Filters the query to exclude items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public UserQueryObject NotWithPreferredTheme(Theme theme) => ApplyPreferredThemeFilter(entity => entity.PreferredTheme, theme, filter => Not(filter));

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

        #region IGroupQuery

        /// <summary>
        /// Filters the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public UserQueryObject WithGroup(Guid groupId)
        {
            And(entity => entity.GroupUsers.Any(gu => gu.GroupId == groupId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public UserQueryObject OrWithGroup(Guid groupId)
        {
            Or(entity => entity.GroupUsers.Any(gu => gu.GroupId == groupId));
            return this;
        }
        #endregion

        /// <summary>
        /// Filters the query to exclude items with the specified group ID.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public UserQueryObject NotWithGroup(Guid groupId)
        {
            Not(entity => entity.GroupUsers.Any(gu => gu.GroupId == groupId));
            return this;
        }

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