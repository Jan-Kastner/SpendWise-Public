using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.Entities;
using SpendWise.DAL.Configurations;

namespace SpendWise.DAL.dbContext
{
    /// <summary>
    /// Base class for SpendWise DbContext, containing common configurations and DbSets.
    /// </summary>
    public abstract class SpendWiseDbContextBase : DbContext, IDbContext
    {
        protected SpendWiseDbContextBase(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<LimitEntity> Limits { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<GroupUserEntity> GroupUsers { get; set; }
        public DbSet<InvitationEntity> Invitations { get; set; }
        public DbSet<TransactionGroupUserEntity> TransactionGroupUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configuration for entities
            EntityConstraintsConfiguration.Configure(modelBuilder);
            EntityIndexesConfiguration.Configure(modelBuilder);
            EntityKeysConfiguration.Configure(modelBuilder);
            EntityPropertiesConfiguration.Configure(modelBuilder);
            EntityRelationshipsConfiguration.Configure(modelBuilder);

            // The seeding is left to the derived classes
            ApplySeeding(modelBuilder);
        }

        protected abstract void ApplySeeding(ModelBuilder modelBuilder);
    }
}
