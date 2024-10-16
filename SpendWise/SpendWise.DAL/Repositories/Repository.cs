using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.dbContext;
using LinqKit;
using SpendWise.DAL.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        /// <summary>
        /// Retrieves all entities from the database as DTOs asynchronously.
        /// </summary>
        /// <param name="queryObject">Optional query object for additional filtering.</param>
        /// <returns>A task representing the asynchronous operation, containing a list of DTOs.</returns>
        public async Task<List<TDto>> ListAsync(IQueryObject<TEntity>? queryObject = null)
        {
            var entities = await ExecuteQueryAsync(queryObject).ToListAsync();
            return entities.Select(entity => _mapper.Map<TDto>(entity)).ToList();
        }

        /// <summary>
        /// Retrieves a single entity from the database as a DTO asynchronously.
        /// </summary>
        /// <param name="queryObject">Optional query object for additional filtering.</param>
        /// <returns>A task representing the asynchronous operation, containing the DTO of the found entity.</returns>
        public async Task<TDto?> SingleOrDefaultAsync(IQueryObject<TEntity>? queryObject)
        {
            var entity = await ExecuteQueryAsync(queryObject).SingleOrDefaultAsync();
            return entity == null ? null : _mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// Executes the query with optional filtering and includes.
        /// </summary>
        /// <param name="queryObject">Optional query object for additional filtering and includes.</param>
        /// <returns>An IQueryable of TEntity.</returns>
        private IQueryable<TEntity> ExecuteQueryAsync(IQueryObject<TEntity>? queryObject)
        {
            IQueryable<TEntity> query = _dbSet;

            if (queryObject != null)
            {
                // Apply the filter expression from the query object
                var expression = queryObject.ToExpression();
                query = query.Where(expression);

                // Include related entities specified in the query object
                foreach (var include in queryObject.Includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        /// <summary>
        /// Checks whether a given entity exists in the database.
        /// </summary>
        /// <param name="entity">The entity to check for existence.</param>
        /// <returns>A task representing the asynchronous operation, containing a boolean result.</returns>
        public async ValueTask<bool> ExistsAsync(TEntity entity)
        {
            try
            {
                return entity.Id != Guid.Empty
                       && await _dbSet.AnyAsync(e => e.Id == entity.Id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while checking the existence of the entity.", ex);
            }
        }

        /// <summary>
        /// Inserts a new entity into the database from a DTO.
        /// </summary>
        /// <param name="dto">The DTO representing the entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, containing the inserted DTO.</returns>
        public async Task<TDto> InsertAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                await _dbSet.AddAsync(entity).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return _mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the entity.", ex);
            }
        }

        /// <summary>
        /// Updates an existing entity in the database from a DTO.
        /// </summary>
        /// <param name="dto">The DTO representing the entity with updated data.</param>
        /// <returns>A task representing the asynchronous operation, containing the updated DTO.</returns>
        public async Task<TDto> UpdateAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                TEntity existingEntity = await _dbSet.SingleAsync(e => e.Id == entity.Id).ConfigureAwait(false);
                _mapper.Map(entity, existingEntity);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return _mapper.Map<TDto>(existingEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the entity.", ex);
            }
        }

        /// <summary>
        /// Deletes an entity from the database by its unique identifier.
        /// </summary>
        /// <param name="entityId">The unique identifier of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid entityId)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == entityId).ConfigureAwait(false);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {entityId} not found.");
                }
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the entity with ID {entityId}.", ex);
            }
        }
    }
}