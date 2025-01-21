using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity;
using SpendWise.DAL.Entities;
using SpendWise.Common.Enums;
using SpendWise.DAL.QueryObjects.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="GroupUserEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class GroupUserQueryObject : BaseQueryObject<GroupUserEntity, GroupUserQueryObject>, IGroupUserQueryObject
    {
        private GroupUserEntityRelationsConfig _relations = new GroupUserEntityRelationsConfig();

        /// <summary>
        /// Gets the initial state for group user relations.
        /// </summary>
        public IGroupUserEntityInitialState Relations => _relations;

        /// <summary>
        /// Gets the list of include properties for the query.
        /// </summary>
        public override List<string> Includes => _relations.Includes;

        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public override ICollection<Func<GroupUserEntity, object>> IncludeDirectives { get; } = new List<Func<GroupUserEntity, object>>
        {
            entity => entity.User,
            entity => entity.Group,
            entity => entity.Limit!,
            entity => entity.TransactionGroupUsers,
            entity => entity.TransactionGroupUsers.Select(tgu => tgu.Transaction),
            entity => entity.TransactionGroupUsers.Select(tgu => tgu.Transaction.Category),
        };

        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region IRoleQuery

        /// <summary>
        /// Filters the query to include items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserRole(UserRole role) => ApplyUserRoleFilter(entity => entity.Role, role, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserRole(UserRole role) => ApplyUserRoleFilter(entity => entity.Role, role, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserRole(UserRole role) => ApplyUserRoleFilter(entity => entity.Role, role, filter => Not(filter));

        #endregion

        #region INameQuery

        /// <summary>
        /// Filters the query to include items with the specified user name.
        /// </summary>
        /// <param name="name">The user name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserName(string name) => ApplyNameFilter(name, entity => entity.User.Name, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user name.
        /// </summary>
        /// <param name="name">The user name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserName(string name) => ApplyNameFilter(name, entity => entity.User.Name, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified user name.
        /// </summary>
        /// <param name="name">The user name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserName(string name) => ApplyNameFilter(name, entity => entity.User.Name, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the user name.
        /// </summary>
        /// <param name="text">The text to partially match in the user name.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.User.Name, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the user name.
        /// </summary>
        /// <param name="text">The text to partially match in the user name.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.User.Name, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the user name.
        /// </summary>
        /// <param name="text">The text to partially match in the user name.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.User.Name, filter => Not(filter), true);

        #endregion

        #region ISurnameQuery

        /// <summary>
        /// Filters the query to include items with the specified user surname.
        /// </summary>
        /// <param name="surname">The user surname to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserSurname(string surname) => ApplySurnameFilter(entity => entity.User.Surname, surname, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user surname.
        /// </summary>
        /// <param name="surname">The user surname to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserSurname(string surname) => ApplySurnameFilter(entity => entity.User.Surname, surname, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified user surname.
        /// </summary>
        /// <param name="surname">The user surname to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserSurname(string surname) => ApplySurnameFilter(entity => entity.User.Surname, surname, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the user surname.
        /// </summary>
        /// <param name="text">The text to partially match in the user surname.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserSurnamePartialMatch(string text) => ApplySurnameFilter(entity => entity.User.Surname, text, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the user surname.
        /// </summary>
        /// <param name="text">The text to partially match in the user surname.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserSurnamePartialMatch(string text) => ApplySurnameFilter(entity => entity.User.Surname, text, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the user surname.
        /// </summary>
        /// <param name="text">The text to partially match in the user surname.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserSurnamePartialMatch(string text) => ApplySurnameFilter(entity => entity.User.Surname, text, filter => Not(filter), true);

        #endregion

        #region IEmailQuery

        /// <summary>
        /// Filters the query to include items with the specified user email.
        /// </summary>
        /// <param name="email">The user email to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserEmail(string email) => ApplyEmailFilter(entity => entity.User.Email, email, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user email.
        /// </summary>
        /// <param name="email">The user email to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserEmail(string email) => ApplyEmailFilter(entity => entity.User.Email, email, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified user email.
        /// </summary>
        /// <param name="email">The user email to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserEmail(string email) => ApplyEmailFilter(entity => entity.User.Email, email, filter => Not(filter));

        #endregion

        #region IPasswordQuery

        /// <summary>
        /// Filters the query to include items with the specified user password.
        /// </summary>
        /// <param name="password">The user password to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserPassword(string password) => ApplyPasswordFilter(entity => entity.User.PasswordHash, password, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user password.
        /// </summary>
        /// <param name="password">The user password to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserPassword(string password) => ApplyPasswordFilter(entity => entity.User.PasswordHash, password, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified user password.
        /// </summary>
        /// <param name="password">The user password to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserPassword(string password) => ApplyPasswordFilter(entity => entity.User.PasswordHash, password, filter => Not(filter));

        #endregion

        #region IDateOfRegistrationQuery

        /// <summary>
        /// Filters the query to include items with the specified user date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The user date of registration to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserDateOfRegistration(DateTime dateOfRegistration) => ApplyDateOfRegistrationFilter(entity => entity.User.DateOfRegistration, dateOfRegistration, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The user date of registration to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserDateOfRegistration(DateTime dateOfRegistration) => ApplyDateOfRegistrationFilter(entity => entity.User.DateOfRegistration, dateOfRegistration, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified user date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The user date of registration to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserDateOfRegistration(DateTime dateOfRegistration) => ApplyDateOfRegistrationFilter(entity => entity.User.DateOfRegistration, dateOfRegistration, filter => Not(filter));

        #endregion

        #region IPhotoQuery

        /// <summary>
        /// Filters the query to include items with a user photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserPhoto() => ApplyPhotoFilter(entity => entity.User.Photo, true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with a user photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserPhoto() => ApplyPhotoFilter(entity => entity.User.Photo, true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with a user photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserPhoto() => ApplyPhotoFilter(entity => entity.User.Photo, true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without a user photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithoutUserPhoto() => ApplyPhotoFilter(entity => entity.User.Photo, false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without a user photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithoutUserPhoto() => ApplyPhotoFilter(entity => entity.User.Photo, false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without a user photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithoutUserPhoto() => ApplyPhotoFilter(entity => entity.User.Photo, false, filter => Not(filter));

        #endregion

        #region IEmailConfirmedQuery

        /// <summary>
        /// Filters the query to include items with confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.User.IsEmailConfirmed, true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.User.IsEmailConfirmed, true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.User.IsEmailConfirmed, true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithoutUserEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.User.IsEmailConfirmed, false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithoutUserEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.User.IsEmailConfirmed, false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithoutUserEmailConfirmed() => ApplyEmailConfirmedFilter(entity => entity.User.IsEmailConfirmed, false, filter => Not(filter));

        #endregion

        #region ITwoFactorEnabledQuery

        /// <summary>
        /// Filters the query to include items with user two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.User.IsTwoFactorEnabled, true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with user two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.User.IsTwoFactorEnabled, true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with user two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.User.IsTwoFactorEnabled, true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without user two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithoutUserTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.User.IsTwoFactorEnabled, false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without user two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithoutUserTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.User.IsTwoFactorEnabled, false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without user two-factor authentication enabled.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithoutUserTwoFactorEnabled() => ApplyTwoFactorEnabledFilter(entity => entity.User.IsTwoFactorEnabled, false, filter => Not(filter));

        #endregion

        #region IResetPasswordTokenQuery

        /// <summary>
        /// Filters the query to include items with the specified user reset password token.
        /// </summary>
        /// <param name="token">The user reset password token to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithUserResetPasswordToken(string token) => ApplyResetPasswordTokenFilter(entity => entity.User.ResetPasswordToken, token, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user reset password token.
        /// </summary>
        /// <param name="token">The user reset password token to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithUserResetPasswordToken(string token) => ApplyResetPasswordTokenFilter(entity => entity.User.ResetPasswordToken, token, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified user reset password token.
        /// </summary>
        /// <param name="token">The user reset password token to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithUserResetPasswordToken(string token) => ApplyResetPasswordTokenFilter(entity => entity.User.ResetPasswordToken, token, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without the user reset password token.
        /// </summary>
        /// <returns></returns>
        public GroupUserQueryObject WithoutUserResetPasswordToken() => ApplyResetPasswordTokenFilter(entity => entity.User.ResetPasswordToken, null, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without the user reset password token.
        /// </summary>
        /// <returns></returns>
        public GroupUserQueryObject OrWithoutUserResetPasswordToken() => ApplyResetPasswordTokenFilter(entity => entity.User.ResetPasswordToken, null, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without the user reset password token.
        /// </summary>
        /// <returns></returns>
        public GroupUserQueryObject NotWithoutUserResetPasswordToken() => ApplyResetPasswordTokenFilter(entity => entity.User.ResetPasswordToken, null, filter => Not(filter));

        #endregion

        #region IPreferredThemeQuery

        /// <summary>
        /// Filters the query to include items with the specified user preferred theme.
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public GroupUserQueryObject WithUserPreferredTheme(Theme theme) => ApplyPreferredThemeFilter(entity => entity.User.PreferredTheme, theme, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user preferred theme.
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public GroupUserQueryObject OrWithUserPreferredTheme(Theme theme) => ApplyPreferredThemeFilter(entity => entity.User.PreferredTheme, theme, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified user preferred theme.
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public GroupUserQueryObject NotWithUserPreferredTheme(Theme theme) => ApplyPreferredThemeFilter(entity => entity.User.PreferredTheme, theme, filter => Not(filter));

        #endregion

        #region UserSentInvitation

        /// <summary>
        /// Filters the query to include items with the specified user lockout end date.
        /// </summary>
        /// <param name="invitationId"></param>
        /// <returns></returns>
        public GroupUserQueryObject WithUserSentInvitation(Guid invitationId)
        {
            And(entity => entity.User.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user sent invitation.
        /// </summary>
        /// <param name="invitationId"></param>
        /// <returns></returns>
        public GroupUserQueryObject OrWithUserSentInvitation(Guid invitationId)
        {
            Or(entity => entity.User.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified user sent invitation.
        /// </summary>
        /// <param name="invitationId"></param>
        /// <returns></returns>
        public GroupUserQueryObject NotWithUserSentInvitation(Guid invitationId)
        {
            Not(entity => entity.User.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        #endregion

        #region UserReceivedInvitation

        /// <summary>
        /// Filters the query to include items with the specified user lockout end date.
        /// </summary>
        /// <param name="invitationId"></param>
        /// <returns></returns>
        public GroupUserQueryObject WithUserReceivedInvitation(Guid invitationId)
        {
            And(entity => entity.User.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        public GroupUserQueryObject OrWithUserReceivedInvitation(Guid invitationId)
        {
            Or(entity => entity.User.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified user received invitation.
        /// </summary>
        /// <param name="invitationId"></param>
        /// <returns></returns>
        public GroupUserQueryObject NotWithUserReceivedInvitation(Guid invitationId)
        {
            Not(entity => entity.User.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        #endregion

        #region UserFullName
        /// <summary>
        /// Filters the query to include items with the specified user lockout end date.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public GroupUserQueryObject WithUserFullName(string fullName)
        {
            And(entity => (entity.User.Name + " " + entity.User.Surname).Contains(fullName));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user full name.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public GroupUserQueryObject OrWithUserFullName(string fullName)
        {
            Or(entity => (entity.User.Name + " " + entity.User.Surname).Contains(fullName));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified user full name.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public GroupUserQueryObject NotWithUserFullName(string fullName)
        {
            Not(entity => (entity.User.Name + " " + entity.User.Surname).Contains(fullName));
            return this;
        }

        #endregion

        #region UserEmailDomain

        /// <summary>
        /// Filters the query to include items with the specified user full name partial match.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public GroupUserQueryObject WithUserEmailDomain(string domain)
        {
            And(entity => entity.User.Email.EndsWith("@" + domain));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user email domain.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public GroupUserQueryObject OrWithUserEmailDomain(string domain)
        {
            Or(entity => entity.User.Email.EndsWith("@" + domain));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified user email domain.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public GroupUserQueryObject NotWithUserEmailDomain(string domain)
        {
            Not(entity => entity.User.Email.EndsWith("@" + domain));
            return this;
        }

        #endregion

        #region IGroupQuery

        /// <summary>
        /// Filters the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public GroupUserQueryObject WithGroup(Guid groupId)
        {
            And(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group ID.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public GroupUserQueryObject OrWithGroup(Guid groupId)
        {
            Or(entity => entity.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified group ID.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public GroupUserQueryObject NotWithGroup(Guid groupId)
        {
            Not(entity => entity.GroupId == groupId);
            return this;
        }

        #endregion

        #region IUserQuery

        /// <summary>
        /// Filters the query to include items with the specified user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public GroupUserQueryObject WithUser(Guid userId)
        {
            And(entity => entity.UserId == userId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public GroupUserQueryObject OrWithUser(Guid userId)
        {
            Or(entity => entity.UserId == userId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public GroupUserQueryObject NotWithUser(Guid userId)
        {
            Not(entity => entity.UserId == userId);
            return this;
        }

        #endregion

        #region ILimitQuery

        /// <summary>
        /// Filters the query to include items with the specified limit ID.
        /// </summary>
        /// <param name="limitId">The limit ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithLimit(Guid limitId)
        {
            And(entity => entity.LimitId != null && entity.LimitId == limitId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified limit ID.
        /// </summary>
        /// <param name="limitId">The limit ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithLimit(Guid limitId)
        {
            Or(entity => entity.LimitId != null && entity.LimitId == limitId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified limit ID.
        /// </summary>
        /// <param name="limitId">The limit ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithLimit(Guid limitId)
        {
            Not(entity => entity.LimitId != null && entity.LimitId == limitId);
            return this;
        }

        /// <summary>
        /// Filters the query to include items without any limit ID (null).
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithoutLimit()
        {
            And(entity => entity.LimitId == null);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items without any limit ID (null).
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithoutLimit()
        {
            Or(entity => entity.LimitId == null);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items without any limit ID (null).
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithoutLimit()
        {
            Not(entity => entity.LimitId == null);
            return this;
        }

        #endregion

        #region ITransactionGroupUserQuery

        /// <summary>
        /// Filters the query to include items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public GroupUserQueryObject WithTransactionGroupUser(Guid transactionGroupUserId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public GroupUserQueryObject OrWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public GroupUserQueryObject NotWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        #endregion
    }
}