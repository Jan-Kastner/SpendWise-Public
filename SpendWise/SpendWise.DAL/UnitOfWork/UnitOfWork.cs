using Microsoft.Extensions.Logging;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;
using SpendWise.DAL.Repositories;
using SpendWise.DAL.dbContext;
using AutoMapper;

namespace SpendWise.DAL.UnitOfWork
{
    /// <summary>
    /// Generic implementation of the Unit of Work pattern to manage a single DbContext and repositories.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly IMapper _mapper;
        private readonly Dictionary<(Type, Type), object> _repositories = new();

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="logger">Logger for recording events.</param>
        /// <param name="mapper">AutoMapper instance for mapping entities and DTOs.</param>
        public UnitOfWork(IDbContext dbContext, ILogger<UnitOfWork> logger, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get the repository for a specific entity type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <typeparam name="TDto">The DTO type.</typeparam>
        /// <returns>An instance of the repository.</returns>
        public IRepository<TEntity, TDto> Repository<TEntity, TDto>()
            where TEntity : class, IEntity
            where TDto : class, IDto
        {
            var typeKey = (typeof(TEntity), typeof(TDto));
            if (!_repositories.ContainsKey(typeKey))
            {
                var repositoryInstance = new Repository<TEntity, TDto>(_dbContext, _mapper);
                _repositories[typeKey] = repositoryInstance;
            }

            return (IRepository<TEntity, TDto>)_repositories[typeKey];
        }

        /// <summary>
        /// Asynchronously saves changes to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Asynchronously releases the resources used by this instance.
        /// </summary>
        /// <returns>A task representing the asynchronous dispose operation.</returns>
        public async ValueTask DisposeAsync()
        {
            if (!_disposed)
            {
                try
                {
                    await DisposeAsyncCore().ConfigureAwait(false);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    _disposed = true;
                    GC.SuppressFinalize(this);
                }
            }
        }

        /// <summary>
        /// Core asynchronous disposal logic.
        /// </summary>
        /// <returns>A task representing the asynchronous dispose operation.</returns>
        protected virtual async Task DisposeAsyncCore()
        {
            if (_dbContext != null)
            {
                try
                {
                    await _dbContext.DisposeAsync().ConfigureAwait(false);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}

