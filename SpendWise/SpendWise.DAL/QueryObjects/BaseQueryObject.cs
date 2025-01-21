using SpendWise.DAL.Entities.Interfaces;
using SpendWise.Common.Enums;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a base query object for querying entities.
    /// Provides methods for specifying various query conditions.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TReturn">The type of the query object.</typeparam>
    public abstract class BaseQueryObject<TEntity, TReturn> : QueryObject<TEntity>
    where TEntity : class, IEntity
    where TReturn : BaseQueryObject<TEntity, TReturn>
    {
        /// <summary>
        /// Applies a text filter to the query.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="value">The value to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <param name="isPartialMatch">Indicates if the filter should be a partial match.</param>
        /// <param name="isNullCheck">Indicates if the filter should check for null values.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyTextFilter<TProperty>(
            Expression<Func<TEntity, TProperty>> propertyExpression,
            TProperty value,
            Action<Expression<Func<TEntity, bool>>> filterAction,
            bool isPartialMatch = false,
            bool isNullCheck = false)
        {
            var parameter = propertyExpression.Parameters[0];
            var property = propertyExpression.Body;

            Expression<Func<TEntity, bool>> filterExpression;

            if (isNullCheck)
            {
                filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Equal(property, Expression.Constant(null, typeof(TProperty))),
                    parameter);
            }
            else if (isPartialMatch && typeof(TProperty) == typeof(string))
            {
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                if (containsMethod == null)
                {
                    throw new InvalidOperationException("The 'Contains' method could not be found.");
                }
                var containsCall = Expression.Call(property, containsMethod, Expression.Constant(value));
                filterExpression = Expression.Lambda<Func<TEntity, bool>>(containsCall, parameter);
            }
            else
            {
                filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Equal(property, Expression.Constant(value, typeof(TProperty))),
                    parameter);
            }

            filterAction(filterExpression);
            return (TReturn)this;
        }

        /// <summary>
        /// Applies a number filter to the query.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="value">The value to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <param name="comparisonType">The comparison type (Equal, GreaterThan, LessThan).</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyNumberFilter<TProperty>(
            Expression<Func<TEntity, TProperty>> propertyExpression,
            TProperty value,
            Action<Expression<Func<TEntity, bool>>> filterAction,
            string comparisonType)
        {
            var parameter = propertyExpression.Parameters[0];
            var property = propertyExpression.Body;

            Expression<Func<TEntity, bool>> filterExpression;

            switch (comparisonType)
            {
                case "Equal":
                    filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                        Expression.Equal(property, Expression.Constant(value)),
                        parameter);
                    break;
                case "GreaterThan":
                    filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                        Expression.GreaterThan(property, Expression.Constant(value)),
                        parameter);
                    break;
                case "LessThan":
                    filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                        Expression.LessThan(property, Expression.Constant(value)),
                        parameter);
                    break;
                default:
                    throw new InvalidOperationException("Invalid comparison type.");
            }

            filterAction(filterExpression);
            return (TReturn)this;
        }

        /// <summary>
        /// Applies a date filter to the query.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="date">The date to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <param name="comparisonType">The comparison type (Equal, GreaterThanOrEqual, LessThanOrEqual).</param>
        /// <param name="isNullCheck">Indicates if the filter should check for null dates.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyDateFilter<TProperty>(
            Expression<Func<TEntity, TProperty>> propertyExpression,
            DateTime? date,
            Action<Expression<Func<TEntity, bool>>> filterAction,
            string comparisonType,
            bool isNullCheck = false)
        {
            var parameter = propertyExpression.Parameters[0];
            var property = propertyExpression.Body;

            Expression<Func<TEntity, bool>> filterExpression;

            if (isNullCheck)
            {
                filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Equal(property, Expression.Constant(null, typeof(TProperty))),
                    parameter);
            }
            else
            {
                Expression dateProperty = typeof(TProperty) == typeof(DateTime?)
                    ? Expression.Property(Expression.Property(property, "Value"), nameof(DateTime.Date))
                    : Expression.Property(property, nameof(DateTime.Date));

                switch (comparisonType)
                {
                    case "Equal":
                        filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                            Expression.Equal(dateProperty, Expression.Constant(date!.Value.Date)),
                            parameter);
                        break;
                    case "GreaterThanOrEqual":
                        filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                            Expression.GreaterThanOrEqual(dateProperty, Expression.Constant(date!.Value.Date)),
                            parameter);
                        break;
                    case "LessThanOrEqual":
                        filterExpression = Expression.Lambda<Func<TEntity, bool>>(
                            Expression.LessThanOrEqual(dateProperty, Expression.Constant(date!.Value.Date)),
                            parameter);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid comparison type.");
                }
            }

            filterAction(filterExpression);
            return (TReturn)this;
        }

        /// <summary>
        /// Applies a filter to the query based on the length of a byte array.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="hasContent">Indicates if the byte array should have content.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyArrayLengthFilter(
            Expression<Func<TEntity, byte[]>> propertyExpression,
            bool hasContent,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            var parameter = propertyExpression.Parameters[0];
            var property = propertyExpression.Body;

            Expression<Func<TEntity, bool>> filterExpression = hasContent
                ? Expression.Lambda<Func<TEntity, bool>>(
                    Expression.GreaterThan(Expression.ArrayLength(property), Expression.Constant(0)),
                    parameter)
                : Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Equal(Expression.ArrayLength(property), Expression.Constant(0)),
                    parameter);

            filterAction(filterExpression);
            return (TReturn)this;
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyIdFilter(Guid id, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            filterAction(entity => entity.Id == id);
            return (TReturn)this;
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's description.
        /// </summary>
        /// <param name="text">The text to filter by.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <param name="isPartialMatch">Indicates if the filter should be a partial match.</param>
        /// <param name="isNullCheck">Indicates if the filter should check for null descriptions.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyDescriptionFilter(
            string? text,
            Expression<Func<TEntity, string?>> propertyExpression,
            Action<Expression<Func<TEntity, bool>>> filterAction,
            bool isPartialMatch = false,
            bool isNullCheck = false)
        {
            return ApplyTextFilter(propertyExpression, text, filterAction, isPartialMatch, isNullCheck);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's name.
        /// </summary>
        /// <param name="text">The text to filter by.</param>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <param name="isPartialMatch">Indicates if the filter should be a partial match.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyNameFilter(
            string text,
            Expression<Func<TEntity, string>> propertyExpression,
            Action<Expression<Func<TEntity, bool>>> filterAction,
            bool isPartialMatch = false)
        {
            return ApplyTextFilter(propertyExpression, text, filterAction, isPartialMatch);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's amount.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="amount">The amount to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <param name="comparisonType">The comparison type (Equal, GreaterThan, LessThan).</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyAmountFilter(
            Expression<Func<TEntity, decimal>> propertyExpression,
            decimal amount,
            Action<Expression<Func<TEntity, bool>>> filterAction,
            string comparisonType)
        {
            return ApplyNumberFilter(propertyExpression, amount, filterAction, comparisonType);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's color.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="color">The color to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyColorFilter(
            Expression<Func<TEntity, string>> propertyExpression,
            string color,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, color, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's icon.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="hasIcon">Indicates if the entity should have an icon.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyIconFilter(
            Expression<Func<TEntity, byte[]>> propertyExpression,
            bool hasIcon,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyArrayLengthFilter(propertyExpression, hasIcon, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's date of registration.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyDateOfRegistrationFilter(
            Expression<Func<TEntity, DateTime>> propertyExpression,
            DateTime dateOfRegistration,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, dateOfRegistration, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's photo presence.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="hasPhoto">Indicates if the entity should have a photo.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyPhotoFilter(
            Expression<Func<TEntity, byte[]>> propertyExpression,
            bool hasPhoto,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyArrayLengthFilter(propertyExpression, hasPhoto, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's email confirmation status.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isConfirmed">The email confirmation status to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyEmailConfirmedFilter(
            Expression<Func<TEntity, bool>> propertyExpression,
            bool isConfirmed,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, isConfirmed, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the reset password token.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="token">The reset password token to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyResetPasswordTokenFilter(
            Expression<Func<TEntity, string?>> propertyExpression,
            string? token,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, token, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the preferred theme.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyPreferredThemeFilter(
            Expression<Func<TEntity, Theme>> propertyExpression,
            Theme theme,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, theme, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the user's role.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="role">The user role to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyUserRoleFilter(
            Expression<Func<TEntity, UserRole>> propertyExpression,
            UserRole role,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, role, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on whether two-factor authentication is enabled.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isEnabled">Indicates if two-factor authentication is enabled.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyTwoFactorEnabledFilter(
            Expression<Func<TEntity, bool>> propertyExpression,
            bool isEnabled,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, isEnabled, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's acceptance status.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isAccepted">The acceptance status to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyIsAcceptedFilter(
            Expression<Func<TEntity, bool?>> propertyExpression,
            bool? isAccepted,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, isAccepted, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's read status.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="isRead">The read status to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyIsReadFilter(
            Expression<Func<TEntity, bool>> propertyExpression,
            bool isRead,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, isRead, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's notice type.
        /// </summary>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyNoticeTypeFilter(
            Expression<Func<TEntity, NoticeType>> propertyExpression,
            NoticeType noticeType,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, noticeType, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's transaction type.
        /// </summary>
        /// <param name="propertyExpression"></param>
        /// <param name="type"></param>
        /// <param name="filterAction"></param>
        /// <returns></returns>
        protected TReturn ApplyTransactionTypeFilter(
            Expression<Func<TEntity, TransactionType>> propertyExpression,
            TransactionType type,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, type, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's transaction status.
        /// </summary>
        /// <param name="propertyExpression"></param>
        /// <param name="text"></param>
        /// <param name="filterAction"></param>
        /// <param name="isPartialMatch"></param>
        /// <returns></returns>
        protected TReturn ApplySurnameFilter(
            Expression<Func<TEntity, string>> propertyExpression,
            string text,
            Action<Expression<Func<TEntity, bool>>> filterAction,
            bool isPartialMatch = false)
        {
            return ApplyTextFilter(propertyExpression, text, filterAction, isPartialMatch);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's email.
        /// </summary>
        /// <param name="propertyExpression"></param>
        /// <param name="email"></param>
        /// <param name="filterAction"></param>
        /// <returns></returns>
        protected TReturn ApplyEmailFilter(
            Expression<Func<TEntity, string>> propertyExpression,
            string email,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, email, filterAction);
        }

        /// <summary>
        /// Applies a filter to the query based on the entity's password hash.
        /// </summary>
        /// <param name="propertyExpression"></param>
        /// <param name="passwordHash"></param>
        /// <param name="filterAction"></param>
        /// <returns></returns>
        protected TReturn ApplyPasswordFilter(
            Expression<Func<TEntity, string>> propertyExpression,
            string passwordHash,
            Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            return ApplyTextFilter(propertyExpression, passwordHash, filterAction);
        }
    }
}