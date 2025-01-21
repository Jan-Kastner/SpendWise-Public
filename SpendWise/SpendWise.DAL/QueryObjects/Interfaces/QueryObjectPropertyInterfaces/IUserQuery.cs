using System;
using SpendWise.Common.Enums;
namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents an extended query interface for filtering by user.
    /// Provides methods for specifying user-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IUserQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        T WithUser(Guid userId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        T OrWithUser(Guid userId);

        /// <summary>
        /// Filters the query to exclude items with the specified user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        T NotWithUser(Guid userId);

        /// <summary>
        /// Filters the query to include items with the specified user name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T WithUserName(string name);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T OrWithUserName(string name);

        /// <summary>
        /// Filters the query to exclude items with the specified user name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T NotWithUserName(string name);

        /// <summary>
        /// Filters the query to include items with the specified user name.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        T WithUserNamePartialMatch(string text);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user name.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        T OrWithUserNamePartialMatch(string text);

        /// <summary>
        /// Filters the query to exclude items with the specified user name.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        T NotWithUserNamePartialMatch(string text);

        /// <summary>
        /// Filters the query to include items with the specified user surname.
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        T WithUserSurname(string surname);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user surname.
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        T OrWithUserSurname(string surname);

        /// <summary>
        /// Filters the query to exclude items with the specified user surname.
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        T NotWithUserSurname(string surname);

        /// <summary>
        /// Filters the query to include items with the specified user surname.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        T WithUserSurnamePartialMatch(string text);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user surname.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        T OrWithUserSurnamePartialMatch(string text);

        /// <summary>
        /// Filters the query to exclude items with the specified user surname.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        T NotWithUserSurnamePartialMatch(string text);

        /// <summary>
        /// Filters the query to include items with the specified user email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        T WithUserEmail(string email);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        T OrWithUserEmail(string email);

        /// <summary>
        /// Filters the query to exclude items with the specified user email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        T NotWithUserEmail(string email);

        /// <summary>
        /// Filters the query to include items with the specified user email.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        T WithUserPassword(string password);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user email.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        T OrWithUserPassword(string password);

        /// <summary>
        /// Filters the query to exclude items with the specified user email.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        T NotWithUserPassword(string password);

        /// <summary>
        /// Filters the query to include items with the specified user role.
        /// </summary>
        /// <param name="dateOfRegistration"></param>
        /// <returns></returns>
        T WithUserDateOfRegistration(DateTime dateOfRegistration);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user role.
        /// </summary>
        /// <param name="dateOfRegistration"></param>
        /// <returns></returns>
        T OrWithUserDateOfRegistration(DateTime dateOfRegistration);

        /// <summary>
        /// Filters the query to exclude items with the specified user role.
        /// </summary>
        /// <param name="dateOfRegistration"></param>
        /// <returns></returns>
        T NotWithUserDateOfRegistration(DateTime dateOfRegistration);

        /// <summary>
        /// Filters the query to include items with a user photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithUserPhoto();

        /// <summary>
        /// Adds an OR condition to the query to include items with a user photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithUserPhoto();

        /// <summary>
        /// Filters the query to exclude items with a user photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithUserPhoto();

        /// <summary>
        /// Filters the query to include items without a user photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutUserPhoto();

        /// <summary>
        /// Adds an OR condition to the query to include items without a user photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutUserPhoto();

        /// <summary>
        /// Filters the query to exclude items without a user photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutUserPhoto();

        /// <summary>
        /// Filters the query to include items with a confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithUserEmailConfirmed();

        /// <summary>
        /// Adds an OR condition to the query to include items with a confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithUserEmailConfirmed();

        /// <summary>
        /// Filters the query to exclude items with a confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithUserEmailConfirmed();

        /// <summary>
        /// Filters the query to include items without a confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutUserEmailConfirmed();

        /// <summary>
        /// Adds an OR condition to the query to include items without a confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutUserEmailConfirmed();

        /// <summary>
        /// Filters the query to exclude items without a confirmed user email.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutUserEmailConfirmed();

        /// <summary>
        /// Filters the query to include items with two-factor authentication enabled for the user.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithUserTwoFactorEnabled();

        /// <summary>
        /// Adds an OR condition to the query to include items with two-factor authentication enabled for the user.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithUserTwoFactorEnabled();

        /// <summary>
        /// Filters the query to exclude items with two-factor authentication enabled for the user.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithUserTwoFactorEnabled();

        /// <summary>
        /// Filters the query to include items without two-factor authentication enabled for the user.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutUserTwoFactorEnabled();

        /// <summary>
        /// Adds an OR condition to the query to include items without two-factor authentication enabled for the user.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutUserTwoFactorEnabled();

        /// <summary>
        /// Filters the query to exclude items without two-factor authentication enabled for the user.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutUserTwoFactorEnabled();

        /// <summary>
        /// Filters the query to include items with the specified user reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithUserResetPasswordToken(string token);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithUserResetPasswordToken(string token);

        /// <summary>
        /// Filters the query to exclude items with the specified user reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithUserResetPasswordToken(string token);

        /// <summary>
        /// Filters the query to include items without a user reset password token.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutUserResetPasswordToken();

        /// <summary>
        /// Adds an OR condition to the query to include items without a user reset password token.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutUserResetPasswordToken();

        /// <summary>
        /// Filters the query to exclude items without a user reset password token.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutUserResetPasswordToken();

        /// <summary>
        /// Filters the query to include items with the specified user preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithUserPreferredTheme(Theme theme);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithUserPreferredTheme(Theme theme);

        /// <summary>
        /// Filters the query to exclude items with the specified user preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithUserPreferredTheme(Theme theme);

        /// <summary>
        /// Filters the query to include items with the specified user full name.
        /// </summary>
        /// <param name="fullName">The full name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithUserFullName(string fullName);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user full name.
        /// </summary>
        /// <param name="fullName">The full name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithUserFullName(string fullName);

        /// <summary>
        /// Filters the query to exclude items with the specified user full name.
        /// </summary>
        /// <param name="fullName">The full name to filter by.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithUserFullName(string fullName);

        /// <summary>
        /// Filters the query to include items with the specified user email domain.
        /// </summary>
        /// <param name="domain">The email domain to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithUserEmailDomain(string domain);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user email domain.
        /// </summary>
        /// <param name="domain">The email domain to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithUserEmailDomain(string domain);

        /// <summary>
        /// Filters the query to exclude items with the specified user email domain.
        /// </summary>
        /// <param name="domain">The email domain to filter by.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithUserEmailDomain(string domain);
    }
}