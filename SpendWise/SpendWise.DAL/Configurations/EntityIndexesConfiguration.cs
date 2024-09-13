using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.Configurations
{
    /// <summary>
    /// Provides configuration for entity indexes in the SpendWise application.
    /// </summary>
    public static class EntityIndexesConfiguration
    {
        /// <summary>
        /// Configures indexes for entities using the specified <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> instance used to configure entity indexes.</param>
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Configuration for CategoryEntity
            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                // Creates an index on the Name property of CategoryEntity
                entity.HasIndex(c => c.Name)
                    .HasDatabaseName("IX_CategoryEntity_Name");
            });

            // Configuration for GroupEntity
            modelBuilder.Entity<GroupEntity>(entity =>
            {
                // Creates an index on the Name property of GroupEntity
                entity.HasIndex(g => g.Name)
                    .HasDatabaseName("IX_GroupEntity_Name");
            });

            // Configuration for GroupUserEntity
            modelBuilder.Entity<GroupUserEntity>(entity =>
            {
                // Creates an index on the UserId property of GroupUserEntity
                entity.HasIndex(gu => gu.UserId)
                    .HasDatabaseName("IX_GroupUserEntity_UserId");

                // Creates an index on the GroupId property of GroupUserEntity
                entity.HasIndex(gu => gu.GroupId)
                    .HasDatabaseName("IX_GroupUserEntity_GroupId");

                // Creates a unique index on the combination of UserId and GroupId properties
                entity.HasIndex(gu => new { gu.UserId, gu.GroupId })
                    .IsUnique()
                    .HasDatabaseName("IX_GroupUserEntity_Unique_UserId_GroupId");
            });

            // Configuration for InvitationEntity
            modelBuilder.Entity<InvitationEntity>(entity =>
            {
                // Creates an index on the SenderId property of InvitationEntity
                entity.HasIndex(i => i.SenderId)
                    .HasDatabaseName("IX_InvitationEntity_SenderId");

                // Creates an index on the ReceiverId property of InvitationEntity
                entity.HasIndex(i => i.ReceiverId)
                    .HasDatabaseName("IX_InvitationEntity_ReceiverId");

                // Creates an index on the GroupId property of InvitationEntity
                entity.HasIndex(i => i.GroupId)
                    .HasDatabaseName("IX_InvitationEntity_GroupId");

                // Creates an index on the SentDate property of InvitationEntity
                entity.HasIndex(i => i.SentDate)
                    .HasDatabaseName("IX_InvitationEntity_SentDate");
            });

            // Configuration for TransactionGroupUserEntity
            modelBuilder.Entity<TransactionGroupUserEntity>(entity =>
            {
                // Creates a unique index on the combination of TransactionId and GroupUserId properties
                entity.HasIndex(tgu => new { tgu.TransactionId, tgu.GroupUserId })
                      .IsUnique()
                      .HasDatabaseName("IX_TransactionGroupUser_Unique_TransactionId_GroupUserId");
            });

            // Configuration for UserEntity
            modelBuilder.Entity<UserEntity>(entity =>
            {
                // Creates a unique index on the Email property of UserEntity
                entity.HasIndex(u => u.Email)
                    .IsUnique()
                    .HasDatabaseName("IX_UserEntity_Email");
            });
        }
    }
}