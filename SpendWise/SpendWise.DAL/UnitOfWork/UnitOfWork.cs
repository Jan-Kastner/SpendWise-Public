using Microsoft.Extensions.Logging;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;
using SpendWise.DAL.Repositories;
using SpendWise.DAL.dbContext;


namespace SpendWise.DAL.UnitOfWork
{
    /// <summary>
    /// Implementation of the Unit of Work pattern to manage a single DbContext and repositories.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<UnitOfWork> _logger;

        /// <summary>
        /// Repository for <see cref="CategoryEntity"/>.
        /// </summary>
        public IRepository<CategoryEntity, CategoryDto> Categories { get; }

        /// <summary>
        /// Repository for <see cref="GroupUserEntity"/>.
        /// </summary>
        public IRepository<GroupUserEntity, GroupUserDto> GroupUsers { get; }

        /// <summary>
        /// Repository for <see cref="InvitationEntity"/>.
        /// </summary>
        public IRepository<InvitationEntity, InvitationDto> Invitations { get; }

        /// <summary>
        /// Repository for <see cref="TransactionEntity"/>.
        /// </summary>
        public IRepository<TransactionEntity, TransactionDto> Transactions { get; }

        /// <summary>
        /// Repository for <see cref="UserEntity"/>.
        /// </summary>
        public IRepository<UserEntity, UserDto> Users { get; }

        /// <summary>
        /// Repository for <see cref="GroupEntity"/>.
        /// </summary>
        public IRepository<GroupEntity, GroupDto> Groups { get; }

        /// <summary>
        /// Repository for <see cref="LimitEntity"/>.
        /// </summary>
        public IRepository<LimitEntity, LimitDto> Limits { get; }

        /// <summary>
        /// Repository for <see cref="TransactionGroupUserEntity"/>.
        /// </summary>
        public IRepository<TransactionGroupUserEntity, TransactionGroupUserDto> TransactionGroupUsers { get; }

        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="categories">Repository for categories.</param>
        /// <param name="groupUsers">Repository for group users.</param>
        /// <param name="invitations">Repository for invitations.</param>
        /// <param name="transactions">Repository for transactions.</param>
        /// <param name="users">Repository for users.</param>
        /// <param name="groups">Repository for groups.</param>
        /// <param name="limits">Repository for limits.</param>
        /// <param name="transactionGroupUsers">Repository for transaction group users.</param>
        /// <param name="logger">Logger for recording events.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the parameters is null.</exception>
        public UnitOfWork(
            IDbContext dbContext,
            IRepository<CategoryEntity, CategoryDto> categories,
            IRepository<GroupUserEntity, GroupUserDto> groupUsers,
            IRepository<InvitationEntity, InvitationDto> invitations,
            IRepository<TransactionEntity, TransactionDto> transactions,
            IRepository<UserEntity, UserDto> users,
            IRepository<GroupEntity, GroupDto> groups,
            IRepository<LimitEntity, LimitDto> limits,
            IRepository<TransactionGroupUserEntity, TransactionGroupUserDto> transactionGroupUsers,
            ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
            GroupUsers = groupUsers ?? throw new ArgumentNullException(nameof(groupUsers));
            Invitations = invitations ?? throw new ArgumentNullException(nameof(invitations));
            Transactions = transactions ?? throw new ArgumentNullException(nameof(transactions));
            Users = users ?? throw new ArgumentNullException(nameof(users));
            Groups = groups ?? throw new ArgumentNullException(nameof(groups));
            Limits = limits ?? throw new ArgumentNullException(nameof(limits));
            TransactionGroupUsers = transactionGroupUsers ?? throw new ArgumentNullException(nameof(transactionGroupUsers));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
