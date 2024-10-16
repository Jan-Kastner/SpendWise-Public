using System;
using System.Threading.Tasks;
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
        /// Gets the repository for Category entities.
        /// </summary>
        IRepository<CategoryEntity, CategoryDto> CategoryRepository { get; }

        /// <summary>
        /// Gets the repository for Group entities.
        /// </summary>
        IRepository<GroupEntity, GroupDto> GroupRepository { get; }

        /// <summary>
        /// Gets the repository for GroupUser entities.
        /// </summary>
        IRepository<GroupUserEntity, GroupUserDto> GroupUserRepository { get; }

        /// <summary>
        /// Gets the repository for Invitation entities.
        /// </summary>
        IRepository<InvitationEntity, InvitationDto> InvitationRepository { get; }

        /// <summary>
        /// Gets the repository for Limit entities.
        /// </summary>
        IRepository<LimitEntity, LimitDto> LimitRepository { get; }

        /// <summary>
        /// Gets the repository for TransactionGroupUser entities.
        /// </summary>
        IRepository<TransactionGroupUserEntity, TransactionGroupUserDto> TransactionGroupUserRepository { get; }

        /// <summary>
        /// Gets the repository for Transaction entities.
        /// </summary>
        IRepository<TransactionEntity, TransactionDto> TransactionRepository { get; }

        /// <summary>
        /// Gets the repository for User entities.
        /// </summary>
        IRepository<UserEntity, UserDto> UserRepository { get; }

        /// <summary>
        /// Asynchronously saves changes to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();
    }
}