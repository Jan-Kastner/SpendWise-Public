using SpendWise.DAL.Entities;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a base query object for querying entities.
    /// Provides methods for specifying ID and name-based query conditions.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TReturn">The type of the query object.</typeparam>
    public abstract class BaseQueryObject<TEntity, TReturn> : QueryObject<TEntity>
    where TEntity : class, IEntity
    where TReturn : BaseQueryObject<TEntity, TReturn>
    {
        #region IIdQueryObject

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        protected TReturn WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        protected TReturn OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        protected TReturn NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return (TReturn)this;
        }

        #endregion

        #region INamedQueryObject

        /// <summary>
        /// Filters the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IName interface.</exception>
        protected TReturn WithName(string name)
        {
            if (typeof(IName).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IName)entity).Name.Contains(name));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IName interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IName interface.</exception>
        protected TReturn OrWithName(string name)
        {
            if (typeof(IName).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IName)entity).Name.Contains(name));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IName interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified name.
        /// </summary>
        /// <param name="name">The name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IName interface.</exception>
        protected TReturn NotWithName(string name)
        {
            if (typeof(IName).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IName)entity).Name.Contains(name));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IName interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IName interface.</exception>
        protected TReturn WithNamePartialMatch(string text)
        {
            if (typeof(IName).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IName)entity).Name.Contains(text));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IName interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IName interface.</exception>
        protected TReturn OrWithNamePartialMatch(string text)
        {
            if (typeof(IName).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IName)entity).Name.Contains(text));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IName interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IName interface.</exception>
        protected TReturn NotWithNamePartialMatch(string text)
        {
            if (typeof(IName).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IName)entity).Name.Contains(text));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IName interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IDescriptionQueryObject

        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDescription interface.</exception>
        protected TReturn WithDescription(string? description)
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IDescription)entity).Description != null && ((IDescription)entity).Description == description);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDescription interface.</exception>
        protected TReturn OrWithDescription(string? description)
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IDescription)entity).Description != null && ((IDescription)entity).Description == description);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDescription interface.</exception>
        protected TReturn NotWithDescription(string? description)
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IDescription)entity).Description != null && ((IDescription)entity).Description == description);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDescription interface.</exception>
        protected TReturn WithDescriptionPartialMatch(string text)
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IDescription)entity).Description != null && ((IDescription)entity).Description!.Contains(text));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDescription interface.</exception>
        protected TReturn OrWithDescriptionPartialMatch(string text)
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IDescription)entity).Description != null && ((IDescription)entity).Description!.Contains(text));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDescription interface.</exception>
        protected TReturn NotWithDescriptionPartialMatch(string text)
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IDescription)entity).Description != null && ((IDescription)entity).Description!.Contains(text));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDescription interface.</exception>
        protected TReturn WithoutDescription()
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IDescription)entity).Description == null);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDescription interface.</exception>
        protected TReturn OrWithoutDescription()
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IDescription)entity).Description == null);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items without a description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDescription interface.</exception>
        protected TReturn NotWithoutDescription()
        {
            if (typeof(IDescription).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IDescription)entity).Description == null);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDescription interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IAmountQueryObject

        /// <summary>
        /// Filters the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IAmount interface.</exception>
        protected TReturn WithAmount(decimal amount)
        {
            if (typeof(IAmount).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IAmount)entity).Amount == amount);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IAmount interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IAmount interface.</exception>
        protected TReturn OrWithAmount(decimal amount)
        {
            if (typeof(IAmount).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IAmount)entity).Amount == amount);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IAmount interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IAmount interface.</exception>
        protected TReturn NotWithAmount(decimal amount)
        {
            if (typeof(IAmount).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IAmount)entity).Amount == amount);
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
        /// Filters the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IColor interface.</exception>
        protected TReturn WithColor(string color)
        {
            if (typeof(IColor).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IColor)entity).Color == color);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IColor interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IColor interface.</exception>
        protected TReturn OrWithColor(string color)
        {
            if (typeof(IColor).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IColor)entity).Color == color);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IColor interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified color.
        /// </summary>
        /// <param name="color">The color to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IColor interface.</exception>
        protected TReturn NotWithColor(string color)
        {
            if (typeof(IColor).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IColor)entity).Color == color);
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
        /// Filters the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIcon interface.</exception>
        protected TReturn WithIcon()
        {
            if (typeof(IIcon).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IIcon)entity).Icon.Length > 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIcon interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIcon interface.</exception>
        protected TReturn OrWithIcon()
        {
            if (typeof(IIcon).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IIcon)entity).Icon.Length > 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIcon interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIcon interface.</exception>
        protected TReturn NotWithIcon()
        {
            if (typeof(IIcon).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IIcon)entity).Icon.Length > 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIcon interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIcon interface.</exception>
        protected TReturn WithoutIcon()
        {
            if (typeof(IIcon).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IIcon)entity).Icon.Length == 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIcon interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIcon interface.</exception>
        protected TReturn OrWithoutIcon()
        {
            if (typeof(IIcon).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IIcon)entity).Icon.Length == 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIcon interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items without an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIcon interface.</exception>
        protected TReturn NotWithoutIcon()
        {
            if (typeof(IIcon).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IIcon)entity).Icon.Length == 0);
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
        /// Filters the query to include items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ISentDate interface.</exception>
        protected TReturn WithSentDate(DateTime sentDate)
        {
            if (typeof(ISentDate).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((ISentDate)entity).SentDate.Date == sentDate.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ISentDate interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ISentDate interface.</exception>
        protected TReturn OrWithSentDate(DateTime sentDate)
        {
            if (typeof(ISentDate).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((ISentDate)entity).SentDate.Date == sentDate.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ISentDate interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified sent date.
        /// </summary>
        /// <param name="sentDate">The sent date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ISentDate interface.</exception>
        protected TReturn NotWithSentDate(DateTime sentDate)
        {
            if (typeof(ISentDate).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((ISentDate)entity).SentDate.Date == sentDate.Date);
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
        /// Filters the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IResponseDate interface.</exception>
        protected TReturn WithResponseDate(DateTime? responseDate)
        {
            if (typeof(IResponseDate).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IResponseDate)entity).ResponseDate.HasValue && ((IResponseDate)entity).ResponseDate!.Value.Date == responseDate!.Value.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IResponseDate interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IResponseDate interface.</exception>
        protected TReturn OrWithResponseDate(DateTime? responseDate)
        {
            if (typeof(IResponseDate).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IResponseDate)entity).ResponseDate.HasValue && ((IResponseDate)entity).ResponseDate!.Value.Date == responseDate!.Value.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IResponseDate interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified response date.
        /// </summary>
        /// <param name="responseDate">The response date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IResponseDate interface.</exception>
        protected TReturn NotWithResponseDate(DateTime? responseDate)
        {
            if (typeof(IResponseDate).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IResponseDate)entity).ResponseDate.HasValue && ((IResponseDate)entity).ResponseDate!.Value.Date == responseDate!.Value.Date);
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
        /// Filters the query to include items with the specified acceptance status.
        /// </summary>
        /// <param name="isAccepted">The acceptance status to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsAccepted interface.</exception>
        protected TReturn WithIsAccepted(bool? isAccepted)
        {
            if (typeof(IIsAccepted).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IIsAccepted)entity).IsAccepted == isAccepted);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsAccepted interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified acceptance status.
        /// </summary>
        /// <param name="isAccepted">The acceptance status to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsAccepted interface.</exception>
        protected TReturn OrWithIsAccepted(bool? isAccepted)
        {
            if (typeof(IIsAccepted).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IIsAccepted)entity).IsAccepted == isAccepted);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsAccepted interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified acceptance status.
        /// </summary>
        /// <param name="isAccepted">The acceptance status to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsAccepted interface.</exception>
        protected TReturn NotWithIsAccepted(bool? isAccepted)
        {
            if (typeof(IIsAccepted).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IIsAccepted)entity).IsAccepted == isAccepted);
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
        /// Filters the query to include items with the specified read status.
        /// </summary>
        /// <param name="isRead">The read status to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsRead interface.</exception>
        protected TReturn WithIsRead(bool isRead)
        {
            if (typeof(IIsRead).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IIsRead)entity).IsRead == isRead);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsRead interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified read status.
        /// </summary>
        /// <param name="isRead">The read status to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsRead interface.</exception>
        protected TReturn OrWithIsRead(bool isRead)
        {
            if (typeof(IIsRead).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IIsRead)entity).IsRead == isRead);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsRead interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified read status.
        /// </summary>
        /// <param name="isRead">The read status to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsRead interface.</exception>
        protected TReturn NotWithIsRead(bool isRead)
        {
            if (typeof(IIsRead).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IIsRead)entity).IsRead == isRead);
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
        /// Filters the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement INoticeType interface.</exception>
        protected TReturn WithNoticeType(NoticeType noticeType)
        {
            if (typeof(INoticeType).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((INoticeType)entity).NoticeType == noticeType);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement INoticeType interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement INoticeType interface.</exception>
        protected TReturn OrWithNoticeType(NoticeType noticeType)
        {
            if (typeof(INoticeType).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((INoticeType)entity).NoticeType == noticeType);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement INoticeType interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified notice type.
        /// </summary>
        /// <param name="noticeType">The notice type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement INoticeType interface.</exception>
        protected TReturn NotWithNoticeType(NoticeType noticeType)
        {
            if (typeof(INoticeType).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((INoticeType)entity).NoticeType == noticeType);
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
        /// Filters the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDate interface.</exception>
        protected TReturn WithDate(DateTime date)
        {
            if (typeof(IDate).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IDate)entity).Date.Date == date.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDate interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDate interface.</exception>
        protected TReturn OrWithDate(DateTime date)
        {
            if (typeof(IDate).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IDate)entity).Date.Date == date.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDate interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified date.
        /// </summary>
        /// <param name="date">The date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDate interface.</exception>
        protected TReturn NotWithDate(DateTime date)
        {
            if (typeof(IDate).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IDate)entity).Date.Date == date.Date);
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
        /// Filters the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ITransactionType interface.</exception>
        protected TReturn WithType(TransactionType type)
        {
            if (typeof(ITransactionType).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((ITransactionType)entity).Type == type);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ITransactionType interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ITransactionType interface.</exception>
        protected TReturn OrWithType(TransactionType type)
        {
            if (typeof(ITransactionType).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((ITransactionType)entity).Type == type);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ITransactionType interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ITransactionType interface.</exception>
        protected TReturn NotWithType(TransactionType type)
        {
            if (typeof(ITransactionType).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((ITransactionType)entity).Type == type);
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
        /// Filters the query to include items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ISurname interface.</exception>
        protected TReturn WithSurname(string surname)
        {
            if (typeof(ISurname).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((ISurname)entity).Surname == surname);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ISurname interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ISurname interface.</exception>
        protected TReturn OrWithSurname(string surname)
        {
            if (typeof(ISurname).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((ISurname)entity).Surname == surname);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ISurname interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified surname.
        /// </summary>
        /// <param name="surname">The surname to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ISurname interface.</exception>
        protected TReturn NotWithSurname(string surname)
        {
            if (typeof(ISurname).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((ISurname)entity).Surname == surname);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ISurname interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ISurname interface.</exception>
        protected TReturn WithSurnamePartialMatch(string text)
        {
            if (typeof(ISurname).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((ISurname)entity).Surname.Contains(text));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ISurname interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ISurname interface.</exception>
        protected TReturn OrWithSurnamePartialMatch(string text)
        {
            if (typeof(ISurname).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((ISurname)entity).Surname.Contains(text));
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement ISurname interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the surname.
        /// </summary>
        /// <param name="text">The text to partially match in the surname.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement ISurname interface.</exception>
        protected TReturn NotWithSurnamePartialMatch(string text)
        {
            if (typeof(ISurname).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((ISurname)entity).Surname.Contains(text));
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
        /// Filters the query to include items with the specified email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IEmail interface.</exception>
        protected TReturn WithEmail(string email)
        {
            if (typeof(IEmail).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IEmail)entity).Email == email);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IEmail interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IEmail interface.</exception>
        protected TReturn OrWithEmail(string email)
        {
            if (typeof(IEmail).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IEmail)entity).Email == email);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IEmail interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified email.
        /// </summary>
        /// <param name="email">The email to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IEmail interface.</exception>
        protected TReturn NotWithEmail(string email)
        {
            if (typeof(IEmail).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IEmail)entity).Email == email);
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
        /// Filters the query to include items with the specified password hash.
        /// </summary>
        /// <param name="passwordHash">The password hash to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPasswordHash interface.</exception>
        protected TReturn WithPassword(string passwordHash)
        {
            if (typeof(IPasswordHash).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IPasswordHash)entity).PasswordHash == passwordHash);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPasswordHash interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified password hash.
        /// </summary>
        /// <param name="passwordHash">The password hash to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPasswordHash interface.</exception>
        protected TReturn OrWithPassword(string passwordHash)
        {
            if (typeof(IPasswordHash).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IPasswordHash)entity).PasswordHash == passwordHash);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPasswordHash interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified password hash.
        /// </summary>
        /// <param name="passwordHash">The password hash to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPasswordHash interface.</exception>
        protected TReturn NotWithPassword(string passwordHash)
        {
            if (typeof(IPasswordHash).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IPasswordHash)entity).PasswordHash == passwordHash);
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
        /// Filters the query to include items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDateOfRegistration interface.</exception>
        protected TReturn WithDateOfRegistration(DateTime dateOfRegistration)
        {
            if (typeof(IDateOfRegistration).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IDateOfRegistration)entity).DateOfRegistration.Date == dateOfRegistration.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDateOfRegistration interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDateOfRegistration interface.</exception>
        protected TReturn OrWithDateOfRegistration(DateTime dateOfRegistration)
        {
            if (typeof(IDateOfRegistration).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IDateOfRegistration)entity).DateOfRegistration.Date == dateOfRegistration.Date);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IDateOfRegistration interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified date of registration.
        /// </summary>
        /// <param name="dateOfRegistration">The date of registration to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IDateOfRegistration interface.</exception>
        protected TReturn NotWithDateOfRegistration(DateTime dateOfRegistration)
        {
            if (typeof(IDateOfRegistration).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IDateOfRegistration)entity).DateOfRegistration.Date == dateOfRegistration.Date);
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
        /// Filters the query to include items with a photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPhoto interface.</exception>
        protected TReturn WithPhoto()
        {
            if (typeof(IPhoto).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IPhoto)entity).Photo.Length > 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPhoto interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with a photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPhoto interface.</exception>
        protected TReturn OrWithPhoto()
        {
            if (typeof(IPhoto).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IPhoto)entity).Photo.Length > 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPhoto interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with a photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPhoto interface.</exception>
        protected TReturn NotWithPhoto()
        {
            if (typeof(IPhoto).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IPhoto)entity).Photo.Length > 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPhoto interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to include items without a photo.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPhoto interface.</exception>
        protected TReturn WithoutPhoto()
        {
            if (typeof(IPhoto).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IPhoto)entity).Photo.Length == 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPhoto interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items without a photo.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPhoto interface.</exception>
        protected TReturn OrWithoutPhoto()
        {
            if (typeof(IPhoto).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IPhoto)entity).Photo.Length == 0);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPhoto interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items without a photo.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPhoto interface.</exception>
        protected TReturn NotWithoutPhoto()
        {
            if (typeof(IPhoto).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IPhoto)entity).Photo.Length == 0);
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
        /// Filters the query to include items with the specified email confirmation status.
        /// </summary>
        /// <param name="isConfirmed">The email confirmation status to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsEmailConfirmed interface.</exception>
        protected TReturn WithEmailConfirmed(bool isConfirmed)
        {
            if (typeof(IIsEmailConfirmed).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IIsEmailConfirmed)entity).IsEmailConfirmed == isConfirmed);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsEmailConfirmed interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified email confirmation status.
        /// </summary>
        /// <param name="isConfirmed">The email confirmation status to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsEmailConfirmed interface.</exception>
        protected TReturn OrWithEmailConfirmed(bool isConfirmed)
        {
            if (typeof(IIsEmailConfirmed).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IIsEmailConfirmed)entity).IsEmailConfirmed == isConfirmed);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsEmailConfirmed interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified email confirmation status.
        /// </summary>
        /// <param name="isConfirmed">The email confirmation status to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsEmailConfirmed interface.</exception>
        protected TReturn NotWithEmailConfirmed(bool isConfirmed)
        {
            if (typeof(IIsEmailConfirmed).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IIsEmailConfirmed)entity).IsEmailConfirmed == isConfirmed);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsEmailConfirmed interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IRoleQuery

        /// <summary>
        /// Filters the query to include items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IUserRole interface.</exception>
        protected TReturn WithUserRole(UserRole role)
        {
            if (typeof(IUserRole).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IUserRole)entity).Role == role);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IUserRole interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IUserRole interface.</exception>
        protected TReturn OrWithUserRole(UserRole role)
        {
            if (typeof(IUserRole).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IUserRole)entity).Role == role);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IUserRole interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified user role.
        /// </summary>
        /// <param name="role">The user role to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IUserRole interface.</exception>
        protected TReturn NotWithUserRole(UserRole role)
        {
            if (typeof(IUserRole).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IUserRole)entity).Role == role);
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
        /// Filters the query to include items with the specified two-factor authentication status.
        /// </summary>
        /// <param name="isEnabled">The two-factor authentication status to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsTwoFactorEnabled interface.</exception>
        protected TReturn WithTwoFactorEnabled(bool isEnabled)
        {
            if (typeof(IIsTwoFactorEnabled).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IIsTwoFactorEnabled)entity).IsTwoFactorEnabled == isEnabled);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsTwoFactorEnabled interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified two-factor authentication status.
        /// </summary>
        /// <param name="isEnabled">The two-factor authentication status to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsTwoFactorEnabled interface.</exception>
        protected TReturn OrWithTwoFactorEnabled(bool isEnabled)
        {
            if (typeof(IIsTwoFactorEnabled).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IIsTwoFactorEnabled)entity).IsTwoFactorEnabled == isEnabled);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsTwoFactorEnabled interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified two-factor authentication status.
        /// </summary>
        /// <param name="isEnabled">The two-factor authentication status to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IIsTwoFactorEnabled interface.</exception>
        protected TReturn NotWithTwoFactorEnabled(bool isEnabled)
        {
            if (typeof(IIsTwoFactorEnabled).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IIsTwoFactorEnabled)entity).IsTwoFactorEnabled == isEnabled);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IIsTwoFactorEnabled interface.");
            }
            return (TReturn)this;
        }

        #endregion

        #region IResetPasswordTokenQuery

        /// <summary>
        /// Filters the query to include items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IResetPasswordToken interface.</exception>
        protected TReturn WithResetPasswordToken(string? token)
        {
            if (typeof(IResetPasswordToken).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IResetPasswordToken)entity).ResetPasswordToken == token);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IResetPasswordToken interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IResetPasswordToken interface.</exception>
        protected TReturn OrWithResetPasswordToken(string? token)
        {
            if (typeof(IResetPasswordToken).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IResetPasswordToken)entity).ResetPasswordToken == token);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IResetPasswordToken interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified reset password token.
        /// </summary>
        /// <param name="token">The reset password token to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IResetPasswordToken interface.</exception>
        protected TReturn NotWithResetPasswordToken(string? token)
        {
            if (typeof(IResetPasswordToken).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IResetPasswordToken)entity).ResetPasswordToken == token);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IResetPasswordToken interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to include items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IResetPasswordToken interface.</exception>
        protected TReturn WithoutResetPasswordToken()
        {
            if (typeof(IResetPasswordToken).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IResetPasswordToken)entity).ResetPasswordToken == null);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IResetPasswordToken interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IResetPasswordToken interface.</exception>
        protected TReturn OrWithoutResetPasswordToken()
        {
            if (typeof(IResetPasswordToken).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IResetPasswordToken)entity).ResetPasswordToken == null);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IResetPasswordToken interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items without a reset password token.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IResetPasswordToken interface.</exception>
        protected TReturn NotWithoutResetPasswordToken()
        {
            if (typeof(IResetPasswordToken).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IResetPasswordToken)entity).ResetPasswordToken == null);
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
        /// Filters the query to include items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPreferredTheme interface.</exception>
        protected TReturn WithPreferredTheme(Theme theme)
        {
            if (typeof(IPreferredTheme).IsAssignableFrom(typeof(TEntity)))
            {
                And(entity => ((IPreferredTheme)entity).PreferredTheme == theme);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPreferredTheme interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPreferredTheme interface.</exception>
        protected TReturn OrWithPreferredTheme(Theme theme)
        {
            if (typeof(IPreferredTheme).IsAssignableFrom(typeof(TEntity)))
            {
                Or(entity => ((IPreferredTheme)entity).PreferredTheme == theme);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPreferredTheme interface.");
            }
            return (TReturn)this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified preferred theme.
        /// </summary>
        /// <param name="theme">The preferred theme to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when TEntity does not implement IPreferredTheme interface.</exception>
        protected TReturn NotWithPreferredTheme(Theme theme)
        {
            if (typeof(IPreferredTheme).IsAssignableFrom(typeof(TEntity)))
            {
                Not(entity => ((IPreferredTheme)entity).PreferredTheme == theme);
            }
            else
            {
                throw new InvalidOperationException("TEntity does not implement IPreferredTheme interface.");
            }
            return (TReturn)this;
        }

        #endregion
    }
}