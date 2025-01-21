using System;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces
{
    /// <summary>
    /// Represents an extended query interface for filtering by transaction.
    /// Provides methods for specifying transaction-based query conditions.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ITransactionQuery<T>
    {
        /// <summary>
        /// Filters the query to include items with the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The transaction ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransaction(Guid transactionId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The transaction ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransaction(Guid transactionId);

        /// <summary>
        /// Filters the query to exclude items with the specified transaction ID.
        /// </summary>
        /// <param name="transactionId">The transaction ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransaction(Guid transactionId);

        /// <summary>
        /// Filters the query to include items with the specified transaction amount.
        /// </summary>
        /// <param name="amount">The transaction amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionAmountEqual(decimal amount);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction amount.
        /// </summary>
        /// <param name="amount">The transaction amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionAmountEqual(decimal amount);

        /// <summary>
        /// Filters the query to exclude items with the specified transaction amount.
        /// </summary>
        /// <param name="amount">The transaction amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionAmountEqual(decimal amount);

        /// <summary>
        /// Filters the query to include items with the transaction amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The transaction amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionAmountGreaterThan(decimal amount);

        /// <summary>
        /// Adds an OR condition to the query to include items with the transaction amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The transaction amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionAmountGreaterThan(decimal amount);

        /// <summary>
        /// Filters the query to exclude items with the transaction amount greater than the specified value.
        /// </summary>
        /// <param name="amount">The transaction amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionAmountGreaterThan(decimal amount);

        /// <summary>
        /// Filters the query to include items with the transaction amount less than the specified value.
        /// </summary>
        /// <param name="amount">The transaction amount to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionAmountLessThan(decimal amount);

        /// <summary>
        /// Adds an OR condition to the query to include items with the transaction amount less than the specified value.
        /// </summary>
        /// <param name="amount">The transaction amount to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionAmountLessThan(decimal amount);

        /// <summary>
        /// Filters the query to exclude items with the transaction amount less than the specified value.
        /// </summary>
        /// <param name="amount">The transaction amount to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionAmountLessThan(decimal amount);

        /// <summary>
        /// Filters the query to include items with the specified transaction date.
        /// </summary>
        /// <param name="date">The transaction date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionDate(DateTime date);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction date.
        /// </summary>
        /// <param name="date">The transaction date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionDate(DateTime date);

        /// <summary>
        /// Filters the query to exclude items with the specified transaction date.
        /// </summary>
        /// <param name="date">The transaction date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionDate(DateTime date);

        /// <summary>
        /// Filters the query to include items with the transaction date from the specified date.
        /// </summary>
        /// <param name="dateFrom">The start date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionDateFrom(DateTime dateFrom);

        /// <summary>
        /// Adds an OR condition to the query to include items with the transaction date from the specified date.
        /// </summary>
        /// <param name="dateFrom">The start date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionDateFrom(DateTime dateFrom);

        /// <summary>
        /// Filters the query to exclude items with the transaction date from the specified date.
        /// </summary>
        /// <param name="dateFrom">The start date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionDateFrom(DateTime dateFrom);

        /// <summary>
        /// Filters the query to include items with the transaction date to the specified date.
        /// </summary>
        /// <param name="dateTo">The end date to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionDateTo(DateTime dateTo);

        /// <summary>
        /// Adds an OR condition to the query to include items with the transaction date to the specified date.
        /// </summary>
        /// <param name="dateTo">The end date to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionDateTo(DateTime dateTo);

        /// <summary>
        /// Filters the query to exclude items with the transaction date to the specified date.
        /// </summary>
        /// <param name="dateTo">The end date to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionDateTo(DateTime dateTo);

        /// <summary>
        /// Filters the query to include items with the specified transaction description.
        /// </summary>
        /// <param name="description">The transaction description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionDescription(string? description);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction description.
        /// </summary>
        /// <param name="description">The transaction description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionDescription(string? description);

        /// <summary>
        /// Filters the query to exclude items with the specified transaction description.
        /// </summary>
        /// <param name="description">The transaction description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionDescription(string? description);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the transaction description.
        /// </summary>
        /// <param name="text">The text to partially match in the transaction description.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionDescriptionPartialMatch(string text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the transaction description.
        /// </summary>
        /// <param name="text">The text to partially match in the transaction description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionDescriptionPartialMatch(string text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the transaction description.
        /// </summary>
        /// <param name="text">The text to partially match in the transaction description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionDescriptionPartialMatch(string text);

        /// <summary>
        /// Filters the query to include items without a transaction description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutTransactionDescription();

        /// <summary>
        /// Adds an OR condition to the query to include items without a transaction description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutTransactionDescription();

        /// <summary>
        /// Filters the query to exclude items without a transaction description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutTransactionDescription();

        /// <summary>
        /// Filters the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionType(TransactionType type);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionType(TransactionType type);

        /// <summary>
        /// Filters the query to exclude items with the specified transaction type.
        /// </summary>
        /// <param name="type">The transaction type to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionType(TransactionType type);

        /// <summary>
        /// Filters the query to include items with the specified transaction category.
        /// </summary>
        /// <param name="categoryId">The transaction category ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        T WithTransactionCategory(Guid categoryId);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified transaction category.
        /// </summary>
        /// <param name="categoryId">The transaction category ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithTransactionCategory(Guid categoryId);

        /// <summary>
        /// Filters the query to exclude items with the specified transaction category.
        /// </summary>
        /// <param name="categoryId">The transaction category ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithTransactionCategory(Guid categoryId);

        /// <summary>
        /// Filters the query to include items without a transaction category.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        T WithoutTransactionCategory();

        /// <summary>
        /// Adds an OR condition to the query to include items without a transaction category.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        T OrWithoutTransactionCategory();

        /// <summary>
        /// Filters the query to exclude items without a transaction category.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        T NotWithoutTransactionCategory();
    }
}