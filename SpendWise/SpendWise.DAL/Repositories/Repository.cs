using AutoMapper;
using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SpendWise.DAL.Repositories
{
    /// <summary>
    /// A generic repository class that provides CRUD operations for entities within the SpendWise application.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that the repository handles.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// The DbSet representing the collection of entities in the database.
        /// </summary>
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// The AutoMapper instance used for mapping between entities.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The DbContext instance used for database access.</param>
        /// <param name="mapper">The AutoMapper instance used for mapping entities.</param>
        public Repository(DbContext dbContext, IMapper mapper)
        {
            _dbSet = dbContext.Set<TEntity>();
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves the queryable collection of all entities in the database.
        /// </summary>
        /// <returns>A queryable collection of entities.</returns>
        public IQueryable<TEntity> Get() => _dbSet;

        /// <summary>
        /// Checks whether a given entity exists in the database.
        /// </summary>
        /// <param name="entity">The entity to check for existence.</param>
        /// <returns>A task representing the asynchronous operation, containing a boolean result.</returns>
        public async ValueTask<bool> ExistsAsync(TEntity entity)
            => entity.Id != Guid.Empty
               && await _dbSet.AnyAsync(e => e.Id == entity.Id).ConfigureAwait(false);

        /// <summary>
        /// Inserts a new entity into the database.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        public TEntity Insert(TEntity entity)
            => _dbSet.Add(entity).Entity;

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity with updated data.</param>
        /// <returns>A task representing the asynchronous operation, containing the updated entity.</returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity existingEntity = await _dbSet.SingleAsync(e => e.Id == entity.Id).ConfigureAwait(false);
            
            _mapper.Map(entity, existingEntity);
            
            return existingEntity;
        }

        /// <summary>
        /// Deletes an entity from the database by its unique identifier.
        /// </summary>
        /// <param name="entityId">The unique identifier of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid entityId)
            => _dbSet.Remove(await _dbSet.SingleAsync(i => i.Id == entityId).ConfigureAwait(false));
    }
}
