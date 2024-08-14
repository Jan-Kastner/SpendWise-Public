using SpendWise.DAL.DTOs;
using SpendWise.DAL.Entities;
using System.Linq.Expressions;
namespace SpendWise.DAL.Repositories
{
    /// <summary>
    /// Defines the contract for a generic repository handling CRUD operations
    /// with mapping between entities and DTOs.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that the repository handles.</typeparam>
    /// <typeparam name="TDto">The type of the DTO that the repository handles.</typeparam>
    public interface IRepository<TEntity, TDto>
        where TEntity : class, IEntity
        where TDto : class, IDto
    {
        /// <summary>
        /// Retrieves all entities from the database as DTOs.
        /// </summary>
        /// <returns>A queryable collection of DTOs representing all entities.</returns>
        public IQueryable<TDto> Get(Expression<Func<TEntity, bool>>? predicate = null);

        /// <summary>
        /// Retrieves an entity by its unique identifier and returns it as a DTO.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the DTO of the found entity.</returns>
        Task<TDto?> GetByIdAsync(Guid id);

        /// <summary>
        /// Checks whether a given entity exists in the database.
        /// </summary>
        /// <param name="entity">The entity to check for existence.</param>
        /// <returns>A task representing the asynchronous operation, containing a boolean result.</returns>
        ValueTask<bool> ExistsAsync(TEntity entity);

        /// <summary>
        /// Inserts a new entity into the database from a DTO.
        /// </summary>
        /// <param name="dto">The DTO representing the entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, containing the inserted DTO.</returns>
        Task<TDto> InsertAsync(TDto dto);

        /// <summary>
        /// Updates an existing entity in the database from a DTO.
        /// </summary>
        /// <param name="dto">The DTO representing the entity with updated data.</param>
        /// <returns>A task representing the asynchronous operation, containing the updated DTO.</returns>
        Task<TDto> UpdateAsync(TDto dto);

        /// <summary>
        /// Deletes an entity from the database by its unique identifier.
        /// </summary>
        /// <param name="entityId">The unique identifier of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid entityId);
    }
}
