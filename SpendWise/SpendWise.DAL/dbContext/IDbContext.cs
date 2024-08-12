using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using SpendWise.DAL.Entities;

namespace SpendWise.DAL.dbContext
{
    public interface IDbContext : IDisposable, IAsyncDisposable
    {
        DbSet<TransactionEntity> Transactions { get; set; }
        DbSet<UserEntity> Users { get; set; }
        DbSet<CategoryEntity> Categories { get; set; }
        DbSet<LimitEntity> Limits { get; set; }
        DbSet<GroupEntity> Groups { get; set; }
        DbSet<GroupUserEntity> GroupUsers { get; set; }
        DbSet<InvitationEntity> Invitations { get; set; }
        DbSet<TransactionGroupUserEntity> TransactionGroupUsers { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        DatabaseFacade Database { get; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
