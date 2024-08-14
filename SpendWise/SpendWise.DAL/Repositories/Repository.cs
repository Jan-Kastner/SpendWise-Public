using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.dbContext;
using System.Linq.Expressions;


namespace SpendWise.DAL.Repositories
{
    /// <summary>
    /// A generic repository class that provides CRUD operations for entities and DTOs.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that the repository handles.</typeparam>
    /// <typeparam name="TDto">The type of the DTO that the repository handles.</typeparam>
    public class Repository<TEntity, TDto> : IRepository<TEntity, TDto>
        where TEntity : class, IEntity
        where TDto : class, IDto
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity, TDto}"/> class.
        /// </summary>
        /// <param name="dbContext">The DbContext instance used for database access.</param>
        /// <param name="mapper">The AutoMapper instance used for mapping between entities and DTOs.</param>
        public Repository(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
            _mapper = mapper;
        }

        public IQueryable<TDto> Get(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.Select(entity => _mapper.Map<TDto>(entity));
        }


        /// <summary>
        /// Retrieves an entity by its unique identifier and returns it as a DTO.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the DTO of the found entity.</returns>
        public async Task<TDto?> GetByIdAsync(Guid id)
        {
            // Find the entity by ID
            var entity = await _dbSet.FindAsync(id).ConfigureAwait(false);

            // Return the mapped DTO or null if entity is not found
            return entity == null ? null : _mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// Checks whether a given entity exists in the database.
        /// </summary>
        /// <param name="entity">The entity to check for existence.</param>
        /// <returns>A task representing the asynchronous operation, containing a boolean result.</returns>
        public async ValueTask<bool> ExistsAsync(TEntity entity)
            => entity.Id != Guid.Empty
               && await _dbSet.AnyAsync(e => e.Id == entity.Id).ConfigureAwait(false);

        /// <summary>
        /// Inserts a new entity into the database from a DTO.
        /// </summary>
        /// <param name="dto">The DTO representing the entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, containing the inserted DTO.</returns>
        public Task<TDto> InsertAsync(TDto dto)
        {
            // Map DTO to entity
            var entity = _mapper.Map<TEntity>(dto);
            _dbSet.Add(entity);

            // Return the inserted DTO
            return Task.FromResult(_mapper.Map<TDto>(entity));
        }

        /// <summary>
        /// Updates an existing entity in the database from a DTO.
        /// </summary>
        /// <param name="dto">The DTO representing the entity with updated data.</param>
        /// <returns>A task representing the asynchronous operation, containing the updated DTO.</returns>
        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            TEntity existingEntity = await _dbSet.SingleAsync(e => e.Id == entity.Id).ConfigureAwait(false);

            // Map updated values from entity to existing entity
            _mapper.Map(entity, existingEntity);

            // Return the updated DTO
            return _mapper.Map<TDto>(existingEntity);
        }

        /// <summary>
        /// Deletes an entity from the database by its unique identifier.
        /// </summary>
        /// <param name="entityId">The unique identifier of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid entityId)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == entityId).ConfigureAwait(false);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {entityId} not found.");
            }
            _dbSet.Remove(entity);
        }
    }
}
