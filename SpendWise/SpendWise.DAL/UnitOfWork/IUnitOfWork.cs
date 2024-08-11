using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;
using SpendWise.DAL.Repositories;

namespace SpendWise.DAL.UnitOfWork
{
    /// <summary>
    /// Defines the contract for a Unit of Work managing a single DbContext and its repositories.
    /// </summary>
    public interface IUnitOfWork : IAsyncDisposable
    {
        /// <summary>
        /// Repository for <see cref="CategoryEntity"/>.
        /// </summary>
        IRepository<CategoryEntity, CategoryDto> Categories { get; }

        /// <summary>
        /// Repository for <see cref="GroupUserEntity"/>.
        /// </summary>
        IRepository<GroupUserEntity, GroupUserDto> GroupUsers { get; }

        /// <summary>
        /// Repository for <see cref="InvitationEntity"/>.
        /// </summary>
        IRepository<InvitationEntity, InvitationDto> Invitations { get; }

        /// <summary>
        /// Repository for <see cref="TransactionEntity"/>.
        /// </summary>
        IRepository<TransactionEntity, TransactionDto> Transactions { get; }

        /// <summary>
        /// Repository for <see cref="UserEntity"/>.
        /// </summary>
        IRepository<UserEntity, UserDto> Users { get; }

        /// <summary>
        /// Repository for <see cref="GroupEntity"/>.
        /// </summary>
        IRepository<GroupEntity, GroupDto> Groups { get; }

        /// <summary>
        /// Repository for <see cref="LimitEntity"/>.
        /// </summary>
        IRepository<LimitEntity, LimitDto> Limits { get; }

        /// <summary>
        /// Repository for <see cref="TransactionGroupUserEntity"/>.
        /// </summary>
        IRepository<TransactionGroupUserEntity, TransactionGroupUserDto> TransactionGroupUsers { get; }

        /// <summary>
        /// Asynchronously saves changes to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();
    }
}
