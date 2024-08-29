using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="UserEntity"/>.
    /// Enables query construction using methods for AND operations.
    /// </summary>
    public class UserQueryObject : QueryObject<UserEntity>
    {
        #region AND

        /// <summary>
        /// Adds a condition to compare the user ID using an AND operation.
        /// </summary>
        /// <param name="id">The user ID to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's name using an AND operation.
        /// </summary>
        /// <param name="name">The name to search for within the user's name.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithName(string name)
        {
            And(entity => entity.Name.Contains(name));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's surname using an AND operation.
        /// </summary>
        /// <param name="surname">The surname to search for within the user's surname.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithSurname(string surname)
        {
            And(entity => entity.Surname.Contains(surname));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's email using an AND operation.
        /// </summary>
        /// <param name="email">The email to search for within the user's email.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithEmail(string email)
        {
            And(entity => entity.Email.Contains(email));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's password using an AND operation.
        /// </summary>
        /// <param name="password">The password to search for within the user's password.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithPassword(string password)
        {
            And(entity => entity.PasswordHash.Contains(password));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's registration date using an AND operation.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithDateOfRegistration(DateTime dateOfRegistration)
        {
            And(entity => entity.DateOfRegistration.Date == dateOfRegistration.Date);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user has a photo using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithPhoto()
        {
            And(entity => entity.Photo.Length > 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user does not have a photo using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithoutPhoto()
        {
            And(entity => entity.Photo.Length == 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare if the user sent a specific invitation using an AND operation.
        /// </summary>
        /// <param name="invitationId">The ID of the invitation to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithSentInvitation(Guid invitationId)
        {
            And(entity => entity.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare if the user received a specific invitation using an AND operation.
        /// </summary>
        /// <param name="invitationId">The ID of the invitation to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithReceivedInvitation(Guid invitationId)
        {
            And(entity => entity.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare if the user is part of a specific group using an AND operation.
        /// </summary>
        /// <param name="groupUserId">The ID of the group user to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithGroupUser(Guid groupUserId)
        {
            And(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        #endregion

        /// <summary>
        /// Adds a condition to check if the user's email is confirmed using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithEmailConfirmed()
        {
            And(entity => entity.IsEmailConfirmed);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user's email is not confirmed using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithoutEmailConfirmed()
        {
            And(entity => !entity.IsEmailConfirmed);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's role using an AND operation.
        /// </summary>
        /// <param name="role">The role to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithRole(UserRole role)
        {
            And(entity => entity.Role == role);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if two-factor authentication is enabled using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithTwoFactorEnabled()
        {
            And(entity => entity.IsTwoFactorEnabled);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if two-factor authentication is not enabled using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithoutTwoFactorEnabled()
        {
            And(entity => !entity.IsTwoFactorEnabled);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user has a reset password token using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithResetPasswordToken()
        {
            And(entity => !string.IsNullOrEmpty(entity.ResetPasswordToken));
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user does not have a reset password token using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithoutResetPasswordToken()
        {
            And(entity => string.IsNullOrEmpty(entity.ResetPasswordToken));
            return this;
        }

        /// <summary>
        /// Adds a condition to check the user's preferred theme using an AND operation.
        /// </summary>
        /// <param name="theme">The theme to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithPreferredTheme(Theme theme)
        {
            And(entity => entity.PreferredTheme == theme);
            return this;
        }

        #region OR

        /// <summary>
        /// Adds a condition to compare the user ID using an OR operation.
        /// </summary>
        /// <param name="id">The user ID to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's name using an OR operation.
        /// </summary>
        /// <param name="name">The name to search for within the user's name.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithName(string name)
        {
            Or(entity => entity.Name.Contains(name));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's surname using an OR operation.
        /// </summary>
        /// <param name="surname">The surname to search for within the user's surname.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithSurname(string surname)
        {
            Or(entity => entity.Surname.Contains(surname));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's email using an OR operation.
        /// </summary>
        /// <param name="email">The email to search for within the user's email.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithEmail(string email)
        {
            Or(entity => entity.Email.Contains(email));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's password using an OR operation.
        /// </summary>
        /// <param name="password">The password to search for within the user's password.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithPassword(string password)
        {
            Or(entity => entity.PasswordHash.Contains(password));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's registration date using an OR operation.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithDateOfRegistration(DateTime dateOfRegistration)
        {
            Or(entity => entity.DateOfRegistration.Date == dateOfRegistration.Date);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user has a photo using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithPhoto()
        {
            Or(entity => entity.Photo.Length > 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user does not have a photo using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithoutPhoto()
        {
            Or(entity => entity.Photo.Length == 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare if the user sent a specific invitation using an OR operation.
        /// </summary>
        /// <param name="invitationId">The ID of the invitation to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithSentInvitation(Guid invitationId)
        {
            Or(entity => entity.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare if the user received a specific invitation using an OR operation.
        /// </summary>
        /// <param name="invitationId">The ID of the invitation to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithReceivedInvitation(Guid invitationId)
        {
            Or(entity => entity.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare if the user is part of a specific group using an OR operation.
        /// </summary>
        /// <param name="groupUserId">The ID of the group user to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithGroupUser(Guid groupUserId)
        {
            Or(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }


        /// <summary>
        /// Adds a condition to check if the user's email is confirmed using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithEmailConfirmed()
        {
            Or(entity => entity.IsEmailConfirmed);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user's email is not confirmed using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithoutEmailConfirmed()
        {
            Or(entity => !entity.IsEmailConfirmed);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's role using an OR operation.
        /// </summary>
        /// <param name="role">The role to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithRole(UserRole role)
        {
            Or(entity => entity.Role == role);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if two-factor authentication is enabled using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithTwoFactorEnabled()
        {
            Or(entity => entity.IsTwoFactorEnabled);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if two-factor authentication is not enabled using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithoutTwoFactorEnabled()
        {
            Or(entity => !entity.IsTwoFactorEnabled);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user has a reset password token using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithResetPasswordToken()
        {
            Or(entity => !string.IsNullOrEmpty(entity.ResetPasswordToken));
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user does not have a reset password token using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithoutResetPasswordToken()
        {
            Or(entity => string.IsNullOrEmpty(entity.ResetPasswordToken));
            return this;
        }

        /// <summary>
        /// Adds a condition to check the user's preferred theme using an OR operation.
        /// </summary>
        /// <param name="theme">The theme to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithPreferredTheme(Theme theme)
        {
            Or(entity => entity.PreferredTheme == theme);
            return this;
        }

        #endregion

        #region NOT

        /// <summary>
        /// Adds a condition to compare the user ID using a NOT operation.
        /// </summary>
        /// <param name="id">The user ID to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's name using a NOT operation.
        /// </summary>
        /// <param name="name">The name to search for within the user's name.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithName(string name)
        {
            Not(entity => entity.Name.Contains(name));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's surname using a NOT operation.
        /// </summary>
        /// <param name="surname">The surname to search for within the user's surname.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithSurname(string surname)
        {
            Not(entity => entity.Surname.Contains(surname));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's email using a NOT operation.
        /// </summary>
        /// <param name="email">The email to search for within the user's email.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithEmail(string email)
        {
            Not(entity => entity.Email.Contains(email));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's password using a NOT operation.
        /// </summary>
        /// <param name="password">The password to search for within the user's password.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithPassword(string password)
        {
            Not(entity => entity.PasswordHash.Contains(password));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's registration date using a NOT operation.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithDateOfRegistration(DateTime dateOfRegistration)
        {
            Not(entity => entity.DateOfRegistration.Date == dateOfRegistration.Date);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user has a photo using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithPhoto()
        {
            Not(entity => entity.Photo.Length > 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user does not have a photo using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithoutPhoto()
        {
            Not(entity => entity.Photo.Length == 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare if the user sent a specific invitation using a NOT operation.
        /// </summary>
        /// <param name="invitationId">The ID of the invitation to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithSentInvitation(Guid invitationId)
        {
            Not(entity => entity.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare if the user received a specific invitation using a NOT operation.
        /// </summary>
        /// <param name="invitationId">The ID of the invitation to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithReceivedInvitation(Guid invitationId)
        {
            Not(entity => entity.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare if the user is part of a specific group using a NOT operation.
        /// </summary>
        /// <param name="groupUserId">The ID of the group user to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithGroupUser(Guid groupUserId)
        {
            Not(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user's email is confirmed using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithEmailConfirmed()
        {
            Not(entity => entity.IsEmailConfirmed);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user's email is not confirmed using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithoutEmailConfirmed()
        {
            Not(entity => !entity.IsEmailConfirmed);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the user's role using a NOT operation.
        /// </summary>
        /// <param name="role">The role to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithRole(UserRole role)
        {
            Not(entity => entity.Role == role);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if two-factor authentication is enabled using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithTwoFactorEnabled()
        {
            Not(entity => entity.IsTwoFactorEnabled);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if two-factor authentication is not enabled using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithoutTwoFactorEnabled()
        {
            Not(entity => !entity.IsTwoFactorEnabled);
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user has a reset password token using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithResetPasswordToken()
        {
            Not(entity => !string.IsNullOrEmpty(entity.ResetPasswordToken));
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user does not have a reset password token using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithoutResetPasswordToken()
        {
            Not(entity => string.IsNullOrEmpty(entity.ResetPasswordToken));
            return this;
        }

        /// <summary>
        /// Adds a condition to check the user's preferred theme using a NOT operation.
        /// </summary>
        /// <param name="theme">The theme to compare.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithPreferredTheme(Theme theme)
        {
            Not(entity => entity.PreferredTheme == theme);
            return this;
        }

        #endregion

        #region FULL NAME AND EMAIL DOMAIN FILTERS

        /// <summary>
        /// Adds a condition to check if the user's full name contains the specified string using an AND operation.
        /// </summary>
        /// <param name="fullName">The full name to search for, which includes both the user's name and surname.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithFullName(string fullName)
        {
            And(entity => (entity.Name + " " + entity.Surname).Contains(fullName));
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user's email ends with the specified domain using an AND operation.
        /// </summary>
        /// <param name="domain">The email domain to check for.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject WithEmailDomain(string domain)
        {
            And(entity => entity.Email.EndsWith("@" + domain));
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user's full name contains the specified string using an OR operation.
        /// </summary>
        /// <param name="fullName">The full name to search for, which includes both the user's name and surname.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithFullName(string fullName)
        {
            Or(entity => (entity.Name + " " + entity.Surname).Contains(fullName));
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user's email ends with the specified domain using an OR operation.
        /// </summary>
        /// <param name="domain">The email domain to check for.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject OrWithEmailDomain(string domain)
        {
            Or(entity => entity.Email.EndsWith("@" + domain));
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user's full name does not contain the specified string using a NOT operation.
        /// </summary>
        /// <param name="fullName">The full name to search for, which includes both the user's name and surname.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithFullName(string fullName)
        {
            Not(entity => (entity.Name + " " + entity.Surname).Contains(fullName));
            return this;
        }

        /// <summary>
        /// Adds a condition to check if the user's email does not end with the specified domain using a NOT operation.
        /// </summary>
        /// <param name="domain">The email domain to check for.</param>
        /// <returns>The current instance of <see cref="UserQueryObject"/>.</returns>
        public UserQueryObject NotWithEmailDomain(string domain)
        {
            Not(entity => entity.Email.EndsWith("@" + domain));
            return this;
        }

        #endregion
    }
}