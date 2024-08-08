using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.Configurations
{
    /// <summary>
    /// Provides configuration for primary keys of entities in the SpendWise application.
    /// </summary>
    public static class EntityKeysConfiguration
    {
        /// <summary>
        /// Configures the primary keys for entities using the specified <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> instance used to configure entity keys.</param>
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Configuration for TransactionEntity
            modelBuilder.Entity<TransactionEntity>()
                // Sets Id as the primary key for TransactionEntity
                .HasKey(t => t.Id);

            // Configuration for UserEntity
            modelBuilder.Entity<UserEntity>()
                // Sets Id as the primary key for UserEntity
                .HasKey(u => u.Id);

            // Configuration for CategoryEntity
            modelBuilder.Entity<CategoryEntity>()
                // Sets Id as the primary key for CategoryEntity
                .HasKey(c => c.Id);

            // Configuration for LimitEntity
            modelBuilder.Entity<LimitEntity>() 
                // Sets Id as the primary key for LimitEntity
                .HasKey(l => l.Id);

            // Configuration for GroupEntity
            modelBuilder.Entity<GroupEntity>()
                // Sets Id as the primary key for GroupEntity
                .HasKey(g => g.Id);

            // Configuration for GroupUserEntity
            modelBuilder.Entity<GroupUserEntity>()
                // Sets Id as the primary key for GroupUserEntity
                .HasKey(gu => gu.Id);

            // Configuration for InvitationEntity
            modelBuilder.Entity<InvitationEntity>()
                // Sets Id as the primary key for InvitationEntity
                .HasKey(i => i.Id);

            // Configuration for TransactionGroupUserEntity
            modelBuilder.Entity<TransactionGroupUserEntity>()
                // Sets Id as the primary key for TransactionGroupUserEntity
                .HasKey(tgu => tgu.Id);
        }
    }
}
