using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for filtering entities of type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that implements the <see cref="IEntity"/> interface.</typeparam>
    public interface IQueryObject<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Converts the query object into an expression that can be used to filter entities.
        /// </summary>
        /// <returns>An expression that defines the filter criteria for the entities of type <typeparamref name="TEntity"/>.</returns>
        Expression<Func<TEntity, bool>> ToExpression();

        /// <summary>
        /// Combines the current query with another query using a logical AND operation.
        /// </summary>
        /// <param name="query">The query to combine with.</param>
        /// <returns>An expression that represents the combined query.</returns>
        Expression<Func<TEntity, bool>> And(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Combines the current query with another query using a logical OR operation.
        /// </summary>
        /// <param name="query">The query to combine with.</param>
        /// <returns>An expression that represents the combined query.</returns>
        Expression<Func<TEntity, bool>> Or(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Negates the current query.
        /// </summary>
        /// <param name="query">The query to negate.</param>
        /// <returns>An expression that represents the negated query.</returns>
        Expression<Func<TEntity, bool>> Not(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Combines the current query object with another query object using a logical AND operation.
        /// </summary>
        /// <param name="queryObject">The query object to combine with.</param>
        /// <returns>An expression that represents the combined query.</returns>
        Expression<Func<TEntity, bool>> And(IQueryObject<TEntity> queryObject);

        /// <summary>
        /// Combines the current query object with another query object using a logical OR operation.
        /// </summary>
        /// <param name="queryObject">The query object to combine with.</param>
        /// <returns>An expression that represents the combined query.</returns>
        Expression<Func<TEntity, bool>> Or(IQueryObject<TEntity> queryObject);

        /// <summary>
        /// Negates the current query object.
        /// </summary>
        /// <param name="queryObject">The query object to negate.</param>
        /// <returns>An expression that represents the negated query.</returns>
        Expression<Func<TEntity, bool>> Not(IQueryObject<TEntity> queryObject);
    }
}
