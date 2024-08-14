using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.dbContext
{
    /// <summary>
    /// Defines the contract for a database context that provides access to various 
    /// entities in the SpendWise application.
    /// </summary>
    public interface IDbContext : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Gets or sets the <see cref="DbSet{TransactionEntity}"/> representing the collection of 
        /// <see cref="TransactionEntity"/> entities in the context.
        /// </summary>
        DbSet<TransactionEntity> Transactions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserEntity}"/> representing the collection of 
        /// <see cref="UserEntity"/> entities in the context.
        /// </summary>
        DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{CategoryEntity}"/> representing the collection of 
        /// <see cref="CategoryEntity"/> entities in the context.
        /// </summary>
        DbSet<CategoryEntity> Categories { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{LimitEntity}"/> representing the collection of 
        /// <see cref="LimitEntity"/> entities in the context.
        /// </summary>
        DbSet<LimitEntity> Limits { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{GroupEntity}"/> representing the collection of 
        /// <see cref="GroupEntity"/> entities in the context.
        /// </summary>
        DbSet<GroupEntity> Groups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{GroupUserEntity}"/> representing the collection of 
        /// <see cref="GroupUserEntity"/> entities in the context.
        /// </summary>
        DbSet<GroupUserEntity> GroupUsers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{InvitationEntity}"/> representing the collection of 
        /// <see cref="InvitationEntity"/> entities in the context.
        /// </summary>
        DbSet<InvitationEntity> Invitations { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TransactionGroupUserEntity}"/> representing the collection of 
        /// <see cref="TransactionGroupUserEntity"/> entities in the context.
        /// </summary>
        DbSet<TransactionGroupUserEntity> TransactionGroupUsers { get; set; }

        /// <summary>
        /// Returns a <see cref="DbSet{TEntity}"/> for the given entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity to retrieve.</typeparam>
        /// <returns>A <see cref="DbSet{TEntity}"/> for the specified entity type.</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Saves all changes made in this context to the database asynchronously.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains the number of
        /// state entries written to the database.
        /// </returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the database.
        /// </returns>
        int SaveChanges();

        /// <summary>
        /// Gets the <see cref="DatabaseFacade"/> for accessing database-related operations.
        /// </summary>
        DatabaseFacade Database { get; }

        /// <summary>
        /// Gets an <see cref="EntityEntry{TEntity}"/> for the given entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity to retrieve.</typeparam>
        /// <param name="entity">The entity to get the entry for.</param>
        /// <returns>
        /// An <see cref="EntityEntry{TEntity}"/> providing access to information and operations
        /// for the given entity.
        /// </returns>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
