using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        /// Get the repository for a specific entity type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <typeparam name="TDto">The DTO type.</typeparam>
        /// <returns>An instance of the repository.</returns>
        IRepository<TEntity, TDto> Repository<TEntity, TDto>() where TEntity : class, IEntity where TDto : class, IDto;

        /// <summary>
        /// Asynchronously saves changes to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();
    }
}
