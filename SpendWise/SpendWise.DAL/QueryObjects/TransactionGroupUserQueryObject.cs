using SpendWise.DAL.Entities;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionGroupUserEntity.Interfaces;
using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionGroupUserEntity;
using SpendWise.DAL.QueryObjects.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="TransactionGroupUserEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class TransactionGroupUserQueryObject : BaseQueryObject<TransactionGroupUserEntity, TransactionGroupUserQueryObject>, ITransactionGroupUserQueryObject
    {
        private TransactionGroupUserEntityRelationsConfig _relations = new TransactionGroupUserEntityRelationsConfig();

        /// <summary>
        /// Gets the initial state for transaction group user relations.
        /// </summary>
        public ITransactionGroupUserEntityInitialState Relations => _relations;

        /// <summary>
        /// Gets the list of include properties for the query.
        /// </summary>
        public override List<string> Includes => _relations.Includes;

        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public override ICollection<Func<TransactionGroupUserEntity, object>> IncludeDirectives { get; } = new List<Func<TransactionGroupUserEntity, object>>
        {
            entity => entity.Transaction,
            entity => entity.Transaction.Category!,
        };

        #region IIdQuery

        /// <summary>
        /// Filters the query by the specified transaction-group-user relationship ID.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction-group-user relationship.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction-group-user relationship ID.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction-group-user relationship.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction-group-user relationship ID.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction-group-user relationship.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region IIsReadQuery

        /// <summary>
        /// Filters the query to include only read transactions.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject IsRead() => ApplyIsReadFilter(entity => entity.IsRead, true, filter => And(filter));

        /// <summary>
        /// Adds an OR filter to the query to include only read transactions.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrIsRead() => ApplyIsReadFilter(entity => entity.IsRead, true, filter => Or(filter));

        /// <summary>
        /// Adds a NOT filter to the query to include only read transactions.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotIsRead() => ApplyIsReadFilter(entity => entity.IsRead, true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include only unread transactions.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject IsNotRead() => ApplyIsReadFilter(entity => entity.IsRead, false, filter => And(filter));

        /// <summary>
        /// Adds an OR filter to the query to include only unread transactions.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrIsNotRead() => ApplyIsReadFilter(entity => entity.IsRead, false, filter => Or(filter));

        /// <summary>
        /// Adds a NOT filter to the query to include only unread transactions.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotIsNotRead() => ApplyIsReadFilter(entity => entity.IsRead, false, filter => Not(filter));

        #endregion

        #region IUserQuery

        /// <summary>
        /// Filters the query by the specified user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithUser(Guid userId)
        {
            And(entity => entity.GroupUser.UserId == userId);
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query by the specified user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithUser(Guid userId)
        {
            Or(entity => entity.GroupUser.UserId == userId);
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query by the specified user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithUser(Guid userId)
        {
            Not(entity => entity.GroupUser.UserId == userId);
            return this;
        }

        #endregion

        #region IGroupQuery

        /// <summary>
        /// Filters the query by the specified group ID.
        /// </summary>
        /// <param name="groupId">The unique identifier of the group.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithGroup(Guid groupId)
        {
            And(entity => entity.GroupUser.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query by the specified group ID.
        /// </summary>
        /// <param name="groupId">The unique identifier of the group.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithGroup(Guid groupId)
        {
            Or(entity => entity.GroupUser.GroupId == groupId);
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query by the specified group ID.
        /// </summary>
        /// <param name="groupId">The unique identifier of the group.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithGroup(Guid groupId)
        {
            Not(entity => entity.GroupUser.GroupId == groupId);
            return this;
        }

        #endregion

        #region IGroupUserIdQuery

        /// <summary>
        /// Filters the query by the specified group-user relationship ID.
        /// </summary>
        /// <param name="groupUserId">The unique identifier of the group-user relationship.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithGroupUser(Guid groupUserId)
        {
            And(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query by the specified group-user relationship ID.
        /// </summary>
        /// <param name="groupUserId">The unique identifier of the group-user relationship.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithGroupUser(Guid groupUserId)
        {
            Or(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query by the specified group-user relationship ID.
        /// </summary>
        /// <param name="groupUserId">The unique identifier of the group-user relationship.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithGroupUser(Guid groupUserId)
        {
            Not(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        #endregion

        #region ITransactionQuery

        /// <summary>
        /// Filters the query by the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The unique identifier of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransaction(Guid transactionId)
        {
            And(entity => entity.TransactionId == transactionId);
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The unique identifier of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransaction(Guid transactionId)
        {
            Or(entity => entity.TransactionId == transactionId);
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The unique identifier of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransaction(Guid transactionId)
        {
            Not(entity => entity.TransactionId == transactionId);
            return this;
        }

        /// <summary>
        /// Filters the query by the specified transaction date.
        /// </summary>
        /// <param name="date">The date of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionDate(DateTime date)
        {
            And(entity => entity.Transaction.Date == date);
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction date.
        /// </summary>
        /// <param name="date">The date of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionDate(DateTime date)
        {
            Or(entity => entity.Transaction.Date == date);
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction date.
        /// </summary>
        /// <param name="date">The date of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionDate(DateTime date)
        {
            Not(entity => entity.Transaction.Date == date);
            return this;
        }

        /// <summary>
        /// Filters the query by the specified transaction amount (equal).
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionAmountEqual(decimal amount) => ApplyAmountFilter(entity => entity.Transaction.Amount, amount, filter => And(filter), "Equal");

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction amount (equal).
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionAmountEqual(decimal amount) => ApplyAmountFilter(entity => entity.Transaction.Amount, amount, filter => Or(filter), "Equal");

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction amount (equal).
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionAmountEqual(decimal amount) => ApplyAmountFilter(entity => entity.Transaction.Amount, amount, filter => Not(filter), "Equal");

        /// <summary>
        /// Filters the query by the specified transaction amount (greater than).
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionAmountGreaterThan(decimal amount) => ApplyAmountFilter(entity => entity.Transaction.Amount, amount, filter => And(filter), "GreaterThan");

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction amount (greater than).
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionAmountGreaterThan(decimal amount) => ApplyAmountFilter(entity => entity.Transaction.Amount, amount, filter => Or(filter), "GreaterThan");

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction amount (greater than).
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionAmountGreaterThan(decimal amount) => ApplyAmountFilter(entity => entity.Transaction.Amount, amount, filter => Not(filter), "GreaterThan");

        /// <summary>
        /// Filters the query by the specified transaction amount (less than).
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionAmountLessThan(decimal amount) => ApplyAmountFilter(entity => entity.Transaction.Amount, amount, filter => And(filter), "LessThan");

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction amount (less than).
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionAmountLessThan(decimal amount) => ApplyAmountFilter(entity => entity.Transaction.Amount, amount, filter => Or(filter), "LessThan");

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction amount (less than).
        /// </summary>
        /// <param name="amount">The amount of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionAmountLessThan(decimal amount) => ApplyAmountFilter(entity => entity.Transaction.Amount, amount, filter => Not(filter), "LessThan");

        /// <summary>
        /// Filters the query by the specified transaction date from.
        /// </summary>
        /// <param name="dateFrom">The start date of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionDateFrom(DateTime dateFrom) => ApplyDateFilter(entity => entity.Transaction.Date, dateFrom, filter => And(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction date from.
        /// </summary>
        /// <param name="dateFrom">The start date of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionDateFrom(DateTime dateFrom) => ApplyDateFilter(entity => entity.Transaction.Date, dateFrom, filter => Or(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction date from.
        /// </summary>
        /// <param name="dateFrom">The start date of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionDateFrom(DateTime dateFrom) => ApplyDateFilter(entity => entity.Transaction.Date, dateFrom, filter => Not(filter), "GreaterThanOrEqual");

        /// <summary>
        /// Filters the query by the specified transaction date to.
        /// </summary>
        /// <param name="dateTo">The end date of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionDateTo(DateTime dateTo) => ApplyDateFilter(entity => entity.Transaction.Date, dateTo, filter => And(filter), "LessThanOrEqual");

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction date to.
        /// </summary>
        /// <param name="dateTo">The end date of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionDateTo(DateTime dateTo) => ApplyDateFilter(entity => entity.Transaction.Date, dateTo, filter => Or(filter), "LessThanOrEqual");

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction date to.
        /// </summary>
        /// <param name="dateTo">The end date of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionDateTo(DateTime dateTo) => ApplyDateFilter(entity => entity.Transaction.Date, dateTo, filter => Not(filter), "LessThanOrEqual");

        /// <summary>
        /// Filters the query by the specified transaction description.
        /// </summary>
        /// <param name="description">The description of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Transaction.Description, filter => And(filter));

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction description.
        /// </summary>
        /// <param name="description">The description of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Transaction.Description, filter => Or(filter));

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction description.
        /// </summary>
        /// <param name="description">The description of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Transaction.Description, filter => Not(filter));

        /// <summary>
        /// Filters the query by a partial match of the transaction description.
        /// </summary>
        /// <param name="text">The partial text to match in the transaction description.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Transaction.Description, filter => And(filter), true);

        /// <summary>
        /// Adds an OR filter to the query by a partial match of the transaction description.
        /// </summary>
        /// <param name="text">The partial text to match in the transaction description.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Transaction.Description, filter => Or(filter), true);

        /// <summary>
        /// Adds a NOT filter to the query by a partial match of the transaction description.
        /// </summary>
        /// <param name="text">The partial text to match in the transaction description.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Transaction.Description, filter => Not(filter), true);

        /// <summary>
        /// Filters the query to include only transactions without a description.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithoutTransactionDescription() => ApplyDescriptionFilter(null, entity => entity.Transaction.Description, filter => And(filter), false, true);

        /// <summary>
        /// Adds an OR filter to the query to include only transactions without a description.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithoutTransactionDescription() => ApplyDescriptionFilter(null, entity => entity.Transaction.Description, filter => Or(filter), false, true);

        /// <summary>
        /// Adds a NOT filter to the query to include only transactions without a description.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithoutTransactionDescription() => ApplyDescriptionFilter(null, entity => entity.Transaction.Description, filter => Not(filter), false, true);

        /// <summary>
        /// Filters the query by the specified transaction type.
        /// </summary>
        /// <param name="type">The type of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionType(TransactionType type) => ApplyTransactionTypeFilter(entity => entity.Transaction.Type, type, filter => And(filter));

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction type.
        /// </summary>
        /// <param name="type">The type of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionType(TransactionType type) => ApplyTransactionTypeFilter(entity => entity.Transaction.Type, type, filter => Or(filter));

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction type.
        /// </summary>
        /// <param name="type">The type of the transaction.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionType(TransactionType type) => ApplyTransactionTypeFilter(entity => entity.Transaction.Type, type, filter => Not(filter));

        /// <summary>
        /// Filters the query by the specified transaction category ID.
        /// </summary>
        /// <param name="categoryId">The unique identifier of the transaction category.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionCategory(Guid categoryId)
        {
            And(entity => entity.Transaction.CategoryId != null && entity.Transaction.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction category ID.
        /// </summary>
        /// <param name="categoryId">The unique identifier of the transaction category.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionCategory(Guid categoryId)
        {
            Or(entity => entity.Transaction.CategoryId != null && entity.Transaction.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction category ID.
        /// </summary>
        /// <param name="categoryId">The unique identifier of the transaction category.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionCategory(Guid categoryId)
        {
            Not(entity => entity.Transaction.CategoryId != null && entity.Transaction.CategoryId == categoryId);
            return this;
        }

        /// <summary>
        /// Filters the query to include only transactions without a category.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithoutTransactionCategory()
        {
            And(entity => entity.Transaction.CategoryId == null);
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query to include only transactions without a category.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithoutTransactionCategory()
        {
            Or(entity => entity.Transaction.CategoryId == null);
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query to include only transactions without a category.
        /// </summary>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithoutTransactionCategory()
        {
            Not(entity => entity.Transaction.CategoryId == null);
            return this;
        }

        /// <summary>
        /// Filters the query by the specified transaction-group-user relationship ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The unique identifier of the transaction-group-user relationship.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionGroupUser(Guid transactionGroupUserId)
        {
            And(entity => entity.Transaction.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query by the specified transaction-group-user relationship ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The unique identifier of the transaction-group-user relationship.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Or(entity => entity.Transaction.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query by the specified transaction-group-user relationship ID.
        /// </summary>
        /// <param name="transactionGroupUserId">The unique identifier of the transaction-group-user relationship.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Not(entity => entity.Transaction.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        /// <summary>
        /// Filters the query by the specified group ID within the transaction.
        /// </summary>
        /// <param name="GroupId">The unique identifier of the group.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionGroup(Guid GroupId)
        {
            And(entity => entity.Transaction.TransactionGroupUsers.Any(tgu => tgu.GroupUser.GroupId == GroupId));
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query by the specified group ID within the transaction.
        /// </summary>
        /// <param name="GroupId">The unique identifier of the group.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionGroup(Guid GroupId)
        {
            Or(entity => entity.Transaction.TransactionGroupUsers.Any(tgu => tgu.GroupUser.GroupId == GroupId));
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query by the specified group ID within the transaction.
        /// </summary>
        /// <param name="GroupId">The unique identifier of the group.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionGroup(Guid GroupId)
        {
            Not(entity => entity.Transaction.TransactionGroupUsers.Any(tgu => tgu.GroupUser.GroupId == GroupId));
            return this;
        }

        /// <summary>
        /// Filters the query by the specified user ID within the transaction.
        /// </summary>
        /// <param name="UserId">The unique identifier of the user.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject WithTransactionUser(Guid UserId)
        {
            And(entity => entity.Transaction.TransactionGroupUsers.Any(tgu => tgu.GroupUser.UserId == UserId));
            return this;
        }

        /// <summary>
        /// Adds an OR filter to the query by the specified user ID within the transaction.
        /// </summary>
        /// <param name="UserId">The unique identifier of the user.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject OrWithTransactionUser(Guid UserId)
        {
            Or(entity => entity.Transaction.TransactionGroupUsers.Any(tgu => tgu.GroupUser.UserId == UserId));
            return this;
        }

        /// <summary>
        /// Adds a NOT filter to the query by the specified user ID within the transaction.
        /// </summary>
        /// <param name="UserId">The unique identifier of the user.</param>
        /// <returns>The current query object with the applied filter.</returns>
        public TransactionGroupUserQueryObject NotWithTransactionUser(Guid UserId)
        {
            Not(entity => entity.Transaction.TransactionGroupUsers.Any(tgu => tgu.GroupUser.UserId == UserId));
            return this;
        }

        #endregion
    }
}