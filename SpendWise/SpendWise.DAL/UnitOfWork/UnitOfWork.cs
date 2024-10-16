using Microsoft.Extensions.Logging;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;
using SpendWise.DAL.Repositories;
using SpendWise.DAL.dbContext;
using AutoMapper;
using System;
using System.Threading.Tasks;

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

        public IRepository<CategoryEntity, CategoryDto> CategoryRepository { get; }
        public IRepository<GroupEntity, GroupDto> GroupRepository { get; }
        public IRepository<GroupUserEntity, GroupUserDto> GroupUserRepository { get; }
        public IRepository<InvitationEntity, InvitationDto> InvitationRepository { get; }
        public IRepository<LimitEntity, LimitDto> LimitRepository { get; }
        public IRepository<TransactionGroupUserEntity, TransactionGroupUserDto> TransactionGroupUserRepository { get; }
        public IRepository<TransactionEntity, TransactionDto> TransactionRepository { get; }
        public IRepository<UserEntity, UserDto> UserRepository { get; }

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="logger">Logger for recording events.</param>
        /// <param name="mapper">AutoMapper instance for mapping entities and DTOs.</param>
        /// <param name="categoryRepository">Category repository instance.</param>
        /// <param name="groupRepository">Group repository instance.</param>
        /// <param name="groupUserRepository">GroupUser repository instance.</param>
        /// <param name="invitationRepository">Invitation repository instance.</param>
        /// <param name="limitRepository">Limit repository instance.</param>
        /// <param name="transactionGroupUserRepository">TransactionGroupUser repository instance.</param>
        /// <param name="transactionRepository">Transaction repository instance.</param>
        /// <param name="userRepository">User repository instance.</param>
        public UnitOfWork(IDbContext dbContext, ILogger<UnitOfWork> logger, IMapper mapper,
                          IRepository<CategoryEntity, CategoryDto> categoryRepository,
                          IRepository<GroupEntity, GroupDto> groupRepository,
                          IRepository<GroupUserEntity, GroupUserDto> groupUserRepository,
                          IRepository<InvitationEntity, InvitationDto> invitationRepository,
                          IRepository<LimitEntity, LimitDto> limitRepository,
                          IRepository<TransactionGroupUserEntity, TransactionGroupUserDto> transactionGroupUserRepository,
                          IRepository<TransactionEntity, TransactionDto> transactionRepository,
                          IRepository<UserEntity, UserDto> userRepository)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            CategoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            GroupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            GroupUserRepository = groupUserRepository ?? throw new ArgumentNullException(nameof(groupUserRepository));
            InvitationRepository = invitationRepository ?? throw new ArgumentNullException(nameof(invitationRepository));
            LimitRepository = limitRepository ?? throw new ArgumentNullException(nameof(limitRepository));
            TransactionGroupUserRepository = transactionGroupUserRepository ?? throw new ArgumentNullException(nameof(transactionGroupUserRepository));
            TransactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving changes to the database.");
                throw new Exception("An error occurred while saving changes to the database.", ex);
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
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while disposing the UnitOfWork.");
                    throw new Exception("An error occurred while disposing the UnitOfWork.", ex);
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
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while disposing the DbContext.");
                    throw new Exception("An error occurred while disposing the DbContext.", ex);
                }
            }
        }
    }
}