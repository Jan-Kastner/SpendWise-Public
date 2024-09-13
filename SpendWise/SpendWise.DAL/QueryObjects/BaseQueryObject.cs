using SpendWise.DAL.Entities;
using SpendWise.Common.Enums;
using System;
using System.Linq.Expressions;

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

        #region IDescriptionQueryObject

        /// <summary>
        /// Applies a filter to the query based on the entity's description.
        /// </summary>
        /// <param name="text">The text to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <param name="isPartialMatch">Indicates if the filter should be a partial match.</param>
        /// <param name="isNullCheck">Indicates if the filter should check for null descriptions.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyDescriptionFilter(string? text, Action<Expression<Func<TEntity, bool>>> filterAction, bool isPartialMatch, bool isNullCheck = false)
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                if (isNullCheck)
                {
                    filterAction(entity => ((IDescription)entity).Description == null);
                }
                else if (isPartialMatch)
                {
                    filterAction(entity => ((IDescription)entity).Description != null && ((IDescription)entity).Description!.Contains(text!));
                }
                else
                {
                    filterAction(entity => ((IDescription)entity).Description != null && ((IDescription)entity).Description == text);
                }
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region INameQueryObject

        /// <summary>
        /// Applies a filter to the query based on the entity's name.
        /// </summary>
        /// <param name="text">The text to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <param name="isPartialMatch">Indicates if the filter should be a partial match.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyNameFilter(string text, Action<Expression<Func<TEntity, bool>>> filterAction, bool isPartialMatch = false)
        {
            if (isPartialMatch)
            {
                filterAction(entity => ((IName)entity).Name.Contains(text));
            }
            else
            {
                filterAction(entity => ((IName)entity).Name == text);
            }
            return (TReturn)this;
        }

        #endregion

        #region IAmountQueryObject

        /// <summary>
        /// Applies a filter to the query based on the entity's amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyAmountFilter(decimal amount, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IAmount).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IAmount)entity).Amount == amount);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IAmount interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IColorQueryObject

        /// <summary>
        /// Applies a filter to the query based on the entity's color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyColorFilter(string color, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IColor).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IColor)entity).Color == color);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IColor interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IIconQueryObject

        /// <summary>
        /// Applies a filter to the query based on the entity's icon presence.
        /// </summary>
        /// <param name="hasIcon">Indicates if the entity should have an icon.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyIconFilter(bool hasIcon, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IIcon).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IIcon)entity).Icon.Length > 0 == hasIcon);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIcon interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region ISentDateQueryObject

        /// <summary>
        /// Applies a filter to the query based on the entity's sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplySentDateFilter(DateTime sentDate, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(ISentDate).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((ISentDate)entity).SentDate.Date == sentDate.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ISentDate interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IResponseDateQueryObject

        /// <summary>
        /// Applies a filter to the query based on the entity's response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyResponseDateFilter(DateTime? responseDate, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IResponseDate).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IResponseDate)entity).ResponseDate.HasValue && ((IResponseDate)entity).ResponseDate!.Value.Date == responseDate!.Value.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IResponseDate interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IIsAcceptedQueryObject

        /// <summary>
        /// Applies a filter to the query based on the entity's acceptance status.
        /// </summary>
        /// <param name="isAccepted">The acceptance status to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyIsAcceptedFilter(bool? isAccepted, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IIsAccepted).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IIsAccepted)entity).IsAccepted == isAccepted);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsAccepted interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IIsReadQueryObject

        /// <summary>
        /// Applies a filter to the query based on the entity's read status.
        /// </summary>
        /// <param name="isRead">The read status to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyIsReadFilter(bool isRead, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IIsRead).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IIsRead)entity).IsRead == isRead);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsRead interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region INoticeTypeQuery

        /// <summary>
        /// Applies a filter to the query based on the entity's notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyNoticeTypeFilter(NoticeType noticeType, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(INoticeType).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((INoticeType)entity).NoticeType == noticeType);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement INoticeType interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IDateQuery

        /// <summary>
        /// Applies a filter to the query based on the entity's date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyDateFilter(DateTime date, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IDate).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IDate)entity).Date.Date == date.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDate interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region ITransactionTypeQuery

        /// <summary>
        /// Applies a filter to the query based on the entity's transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyTransactionTypeFilter(TransactionType type, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(ITransactionType).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((ITransactionType)entity).Type == type);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ITransactionType interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region ISurnameQuery

        /// <summary>
        /// Applies a filter to the query based on the entity's surname.
        /// </summary>
        /// <param name="text">The text to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <param name="isPartialMatch">Indicates if the filter should be a partial match.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplySurnameFilter(string text, Action<Expression<Func<TEntity, bool>>> filterAction, bool isPartialMatch = false)
        {
            if (typeof(ISurname).IsAssignableFrom(typeof(TEntity)))
            {
                if (isPartialMatch)
                {
                    filterAction(entity => ((ISurname)entity).Surname.Contains(text));
                }
                else
                {
                    filterAction(entity => ((ISurname)entity).Surname == text);
                }
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ISurname interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IEmailQuery

        /// <summary>
        /// Applies a filter to the query based on the entity's email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyEmailFilter(string email, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IEmail).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IEmail)entity).Email == email);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IEmail interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IPasswordQuery

        /// <summary>
        /// Applies a filter to the query based on the entity's password hash.
        /// </summary>
        /// <param name="passwordHash">The password hash to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyPasswordFilter(string passwordHash, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IPasswordHash).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IPasswordHash)entity).PasswordHash == passwordHash);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPasswordHash interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IDateOfRegistrationQuery

        /// <summary>
        /// Applies a filter to the query based on the entity's date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyDateOfRegistrationFilter(DateTime dateOfRegistration, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IDateOfRegistration).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IDateOfRegistration)entity).DateOfRegistration.Date == dateOfRegistration.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDateOfRegistration interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IPhotoQuery

        /// <summary>
        /// Applies a filter to the query based on the entity's photo presence.
        /// </summary>
        /// <param name="hasPhoto">Indicates if the entity should have a photo.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyPhotoFilter(bool hasPhoto, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IPhoto).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IPhoto)entity).Photo.Length > 0 == hasPhoto);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPhoto interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IEmailConfirmedQuery

        /// <summary>
        /// Applies a filter to the query based on the entity's email confirmation status.
        /// </summary>
        /// <param name="isConfirmed">The email confirmation status to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn ApplyEmailConfirmedFilter(bool isConfirmed, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IIsEmailConfirmed).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IIsEmailConfirmed)entity).IsEmailConfirmed == isConfirmed);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsEmailConfirmed interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IResetPasswordTokenQuery

        /// <summary>
        /// Applies a filter to the query based on the reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown if TEntity does not implement IResetPasswordToken interface.</exception>
        protected TReturn ApplyResetPasswordTokenFilter(string? token, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IResetPasswordToken).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IResetPasswordToken)entity).ResetPasswordToken == token);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IResetPasswordToken interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IPreferredThemeQuery

        /// <summary>
        /// Applies a filter to the query based on the preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown if TEntity does not implement IPreferredTheme interface.</exception>
        protected TReturn ApplyPreferredThemeFilter(Theme theme, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IPreferredTheme).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IPreferredTheme)entity).PreferredTheme == theme);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPreferredTheme interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IRoleQuery

        /// <summary>
        /// Applies a filter to the query based on the user's role.
        /// </summary>
        /// <param name="role">The user role to filter by.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown if TEntity does not implement IUserRole interface.</exception>
        protected TReturn ApplyUserRoleFilter(UserRole role, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IUserRole).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IUserRole)entity).Role == role);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IUserRole interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region ITwoFactorEnabledQuery

        /// <summary>
        /// Applies a filter to the query based on whether two-factor authentication is enabled.
        /// </summary>
        /// <param name="isEnabled">Indicates if two-factor authentication is enabled.</param>
        /// <param name="filterAction">The action to apply the filter.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown if TEntity does not implement IIsTwoFactorEnabled interface.</exception>
        protected TReturn ApplyTwoFactorEnabledFilter(bool isEnabled, Action<Expression<Func<TEntity, bool>>> filterAction)
        {
            if (typeof(IIsTwoFactorEnabled).IsAssignableFrom(typeof(TEntity)))
            {
                filterAction(entity => ((IIsTwoFactorEnabled)entity).IsTwoFactorEnabled == isEnabled);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsTwoFactorEnabled interface.");
            }
            return (TReturn)this;
        }

        #endregion
    }
}