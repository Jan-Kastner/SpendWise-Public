using SpendWise.DAL.Entities;

namespace SpendWise.DAL.Repositories
{
    /// <summary>
    /// A generic repository interface that defines CRUD operations for entities within the SpendWise application.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that the repository handles.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Retrieves the queryable collection of all entities in the database.
        /// </summary>
        /// <returns>A queryable collection of entities.</returns>
        IQueryable<TEntity> Get();

        /// <summary>
        /// Deletes an entity from the database by its unique identifier.
        /// </summary>
        /// <param name="entityId">The unique identifier of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid entityId);

        /// <summary>
        /// Checks whether a given entity exists in the database.
        /// </summary>
        /// <param name="entity">The entity to check for existence.</param>
        /// <returns>A task representing the asynchronous operation, containing a boolean result.</returns>
        ValueTask<bool> ExistsAsync(TEntity entity);

        /// <summary>
        /// Inserts a new entity into the database.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity with updated data.</param>
        /// <returns>A task representing the asynchronous operation, containing the updated entity.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
