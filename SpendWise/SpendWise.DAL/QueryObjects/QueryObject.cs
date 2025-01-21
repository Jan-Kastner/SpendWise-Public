using System.Linq.Expressions;
using LinqKit;
using SpendWise.DAL.Entities.Interfaces;
using SpendWise.DAL.QueryObjects.Interfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents an abstract base class for query objects that filter entities of type <typeparamref name="TEntity"/>.
    /// This class provides methods for building queries using logical operators.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that implements the <see cref="IEntity"/> interface.</typeparam>
    public abstract class QueryObject<TEntity> : IQueryObject<TEntity> where TEntity : class, IEntity
    {
        private Expression<Func<TEntity, bool>>? _query; // Holds the current query expression

        /// <summary>
        /// Gets the list of includes to be applied to the query.
        /// </summary>
        public virtual List<string> Includes => new List<string>();

        /// <summary>
        /// Converts the query object into an expression that can be used to filter entities.
        /// </summary>
        /// <returns>
        /// An expression that defines the filter criteria for the entities of type <typeparamref name="TEntity"/>.
        /// If no query is defined, it defaults to a true expression, allowing all entities to pass through.
        /// </returns>
        public virtual Expression<Func<TEntity, bool>> ToExpression()
        {
            return _query ?? (entity => true);
        }

        /// <summary>
        /// Combines the current query with another query using a logical AND operation.
        /// </summary>
        /// <param name="query">The query to combine with.</param>
        /// <returns>
        /// An expression that represents the combined query.
        /// If there is no existing query, the new query is returned.
        /// </returns>
        public Expression<Func<TEntity, bool>> And(Expression<Func<TEntity, bool>> query)
        {
            return _query = _query == null ? query : _query.And(query.Expand());
        }

        /// <summary>
        /// Combines the current query with another query using a logical OR operation.
        /// </summary>
        /// <param name="query">The query to combine with.</param>
        /// <returns>
        /// An expression that represents the combined query.
        /// If there is no existing query, the new query is returned.
        /// </returns>
        public Expression<Func<TEntity, bool>> Or(Expression<Func<TEntity, bool>> query)
        {
            return _query = _query == null ? query : _query.Or(query.Expand());
        }

        /// <summary>
        /// Combines the current query object with another query object using a logical AND operation.
        /// </summary>
        /// <param name="queryObject">The query object to combine with.</param>
        /// <returns>
        /// An expression that represents the combined query.
        /// </returns>
        public Expression<Func<TEntity, bool>> And(IQueryObject<TEntity> queryObject)
        {
            return And(queryObject.ToExpression());
        }

        /// <summary>
        /// Combines the current query object with another query object using a logical OR operation.
        /// </summary>
        /// <param name="queryObject">The query object to combine with.</param>
        /// <returns>
        /// An expression that represents the combined query.
        /// </returns>
        public Expression<Func<TEntity, bool>> Or(IQueryObject<TEntity> queryObject)
        {
            return Or(queryObject.ToExpression());
        }

        /// <summary>
        /// Negates the current query.
        /// </summary>
        /// <param name="query">The query to negate.</param>
        /// <returns>
        /// An expression that represents the negated query.
        /// If there is no existing query, the negated query is returned.
        /// </returns>
        public Expression<Func<TEntity, bool>> Not(Expression<Func<TEntity, bool>> query)
        {
            return _query = _query == null ? query.Expand().Not() : _query.And(query.Expand().Not());
        }

        /// <summary>
        /// Negates the current query object.
        /// </summary>
        /// <param name="queryObject">The query object to negate.</param>
        /// <returns>
        /// An expression that represents the negated query.
        /// </returns>
        public Expression<Func<TEntity, bool>> Not(IQueryObject<TEntity> queryObject)
        {
            return Not(queryObject.ToExpression());
        }

        /// <summary>
        /// Clears the current query, resetting it to its initial state.
        /// </summary>
        /// <returns>
        /// The current instance of the <see cref="QueryObject{TEntity}"/> class for method chaining.
        /// </returns>
        public virtual QueryObject<TEntity> Clear()
        {
            _query = null;
            return this;
        }

        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public virtual ICollection<Func<TEntity, object>> IncludeDirectives => new List<Func<TEntity, object>>();


    }
}
