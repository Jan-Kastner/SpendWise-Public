using SpendWise.Common.Enums;
using SpendWise.DAL.Entities;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces;
using SpendWise.DAL.QueryObjects.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="TransactionEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class TransactionQueryObject : BaseQueryObject<TransactionEntity, TransactionQueryObject>, ITransactionQueryObject
    {
        private TransactionEntityRelationsConfig _relations = new TransactionEntityRelationsConfig();

        /// <summary>
        /// Gets the initial state for transaction relations.
        /// </summary>
        public ITransactionEntityInitialState Relations => _relations;

        /// <summary>
        /// Gets the list of include properties for the query.
        /// </summary>
        public override List<string> Includes => _relations.Includes;

        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public override ICollection<Func<TransactionEntity, object>> IncludeDirectives { get; } = new List<Func<TransactionEntity, object>>
        {
            entity => entity.Category!,
            entity => entity.TransactionGroupUsers,
            entity => entity.TransactionGroupUsers.Select(tgu => tgu.GroupUser),
            entity => entity.TransactionGroupUsers.Select(tgu => tgu.GroupUser.Group),
            entity => entity.TransactionGroupUsers.Select(tgu => tgu.GroupUser.User),
            entity => entity.TransactionGroupUsers.Select(tgu => tgu.GroupUser.Group.GroupUsers.Select(gu => gu.User)),
        };

        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region IAmountQuery

        /// <summary>
        /// Filters the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithAmountEqual(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => And(filter), "Equal");

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithAmountEqual(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Or(filter), "Equal");

        /// <summary>
        /// Filters the query to exclude items with the specified amount.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithAmountEqual(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Not(filter), "Equal");

        /// <summary>
        /// Filters the query to include items with the amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithAmountGreaterThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => And(filter), "GreaterThan");

        /// <summary>
        /// Adds an OR condition to the query to include items with the amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithAmountGreaterThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Or(filter), "GreaterThan");

        /// <summary>
        /// Filters the query to exclude items with the amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithAmountGreaterThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Not(filter), "GreaterThan");

        /// <summary>
        /// Filters the query to include items with the amount less than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithAmountLessThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => And(filter), "LessThan");

        /// <summary>
        /// Adds an OR condition to the query to include items with the amount less than the specified value.
        /// </summary>
        /// <param name="amount">The amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithAmountLessThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Or(filter), "LessThan");

        /// <summary>
        /// Filters the query to exclude items with the amount less than the specified value.
        /// </summary>
        /// <param name="amount">The amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithAmountLessThan(decimal amount) => ApplyAmountFilter(entity => entity.Amount, amount, filter => Not(filter), "LessThan");

        #endregion

        #region IDateQuery

        /// <summary>
        /// Filters the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithDate(DateTime date) => ApplyDateFilter(entity => entity.Date, date, filter => And(filter), "Equal");

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithDate(DateTime date) => ApplyDateFilter(entity => entity.Date, date, filter => Or(filter), "Equal");

        /// <summary>
        /// Filters the query to exclude items with the specified date.
        /// </summary>
        /// <param name="date">The date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithDate(DateTime date) => ApplyDateFilter(entity => entity.Date, date, filter => Not(filter), "Equal");

        /// <summary>
        /// Filters the query to include items with the specified date range.
        /// </summary>
        /// <param name="dateFrom">The start date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithDateFrom(DateTime dateFrom) => ApplyDateFilter(entity => entity.Date, dateFrom, filter => And(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date range.
        /// </summary>
        /// <param name="dateFrom">The start date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithDateFrom(DateTime dateFrom) => ApplyDateFilter(entity => entity.Date, dateFrom, filter => Or(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Filters the query to exclude items with the specified date range.
        /// </summary>
        /// <param name="dateFrom">The start date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithDateFrom(DateTime dateFrom) => ApplyDateFilter(entity => entity.Date, dateFrom, filter => Not(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Filters the query to include items with the specified date range.
        /// </summary>
        /// <param name="dateTo">The end date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithDateTo(DateTime dateTo) => ApplyDateFilter(entity => entity.Date, dateTo, filter => And(filter), "LessThanOrEqual");

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified date range.
        /// </summary>
        /// <param name="dateTo">The end date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithDateTo(DateTime dateTo) => ApplyDateFilter(entity => entity.Date, dateTo, filter => Or(filter), "LessThanOrEqual");

        /// <summary>
        /// Filters the query to exclude items with the specified date range.
        /// </summary>
        /// <param name="dateTo">The end date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithDateTo(DateTime dateTo) => ApplyDateFilter(entity => entity.Date, dateTo, filter => Not(filter), "LessThanOrEqual");

        #endregion

        #region IDescriptionQuery

        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Description, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Description, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Description, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Description, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Description, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Description, filter => Not(filter), true);

        /// <summary>
        /// Filters the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithoutDescription() => ApplyDescriptionFilter(null, entity => entity.Description, filter => And(filter), false, true);

        /// <summary>
        /// Adds an OR condition to the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithoutDescription() => ApplyDescriptionFilter(null, entity => entity.Description, filter => Or(filter), false, true);

        /// <summary>
        /// Filters the query to exclude items without a description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithoutDescription() => ApplyDescriptionFilter(null, entity => entity.Description, filter => Not(filter), false, true);

        #endregion

        #region ITypeQuery

        /// <summary>
        /// Filters the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithType(TransactionType type) => ApplyTransactionTypeFilter(entity => entity.Type, type, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithType(TransactionType type) => ApplyTransactionTypeFilter(entity => entity.Type, type, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithType(TransactionType type) => ApplyTransactionTypeFilter(entity => entity.Type, type, filter => Not(filter));

        #endregion

        #region ICategoryQuery

        /// <summary>
        /// Filters the query to include items with the specified category ID.
        /// </summary>
        /// <param name="categoryId">The category ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithCategory(Guid categoryId)
        {
            And(entity => entity.CategoryId != null && entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified category ID.
        /// </summary>
        /// <param name="categoryId">The category ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithCategory(Guid categoryId)
        {
            Or(entity => entity.CategoryId != null && entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified category ID.
        /// </summary>
        /// <param name="categoryId">The category ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithCategory(Guid categoryId)
        {
            Not(entity => entity.CategoryId != null && entity.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Filters the query to include items without a category.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithoutCategory()
        {
            And(entity => entity.CategoryId == null);
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items without a category.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithoutCategory()
        {
            Or(entity => entity.CategoryId == null);
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items without a category.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithoutCategory()
        {
            Not(entity => entity.CategoryId == null);
            return this;
        }

        #endregion

        #region ITransactionGroupUserQuery

        /// <summary>
        /// Filters the query to include items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public TransactionQueryObject WithTransactionGroupUser(Guid transactionGroupUserId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public TransactionQueryObject OrWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified transaction group user ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The transaction group user ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public TransactionQueryObject NotWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }
        #endregion

        #region IGroupQuery

        /// <summary>
        /// Filters the query to include items with the specified group ID.
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public TransactionQueryObject WithGroup(Guid GroupId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.GroupUser.GroupId == GroupId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified group ID.
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public TransactionQueryObject OrWithGroup(Guid GroupId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.GroupUser.GroupId == GroupId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified group ID.
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public TransactionQueryObject NotWithGroup(Guid GroupId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.GroupUser.GroupId == GroupId));
            return this;
        }
        #endregion

        #region IUserQuery

        /// <summary>
        /// Filters the query to include items with the specified user ID.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public TransactionQueryObject WithUser(Guid UserId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.GroupUser.UserId == UserId));
            return this;
        }

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified user ID.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public TransactionQueryObject OrWithUser(Guid UserId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.GroupUser.UserId == UserId));
            return this;
        }

        /// <summary>
        /// Filters the query to exclude items with the specified user ID.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public TransactionQueryObject NotWithUser(Guid UserId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.GroupUser.UserId == UserId));
            return this;
        }
        #endregion
    }
}