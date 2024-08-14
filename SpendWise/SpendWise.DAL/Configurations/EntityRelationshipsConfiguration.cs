using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.Configurations
{
    /// <summary>
    /// Configures the relationships between entities in the SpendWise application.
    /// </summary>
    public static class EntityRelationshipsConfiguration
    {
        /// <summary>
        /// Configures the relationships between entities using the specified <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> instance used to configure entity relationships.</param>
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Configuration for TransactionEntity
            modelBuilder.Entity<TransactionEntity>(entity =>
            {
                // Configures one-to-many relationship with CategoryEntity
                entity.HasOne(t => t.Category)
                    .WithMany(c => c.Transactions)
                    .HasForeignKey(t => t.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);

                // Configures one-to-many relationship with TransactionGroupUserEntity
                entity.HasMany(t => t.TransactionGroupUsers)
                    .WithOne(tgu => tgu.Transaction)
                    .HasForeignKey(tgu => tgu.TransactionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            // Configuration for UserEntity
            modelBuilder.Entity<UserEntity>(entity =>
            {
                // Configures one-to-many relationship with SentInvitations
                entity.HasMany(u => u.SentInvitations)
                    .WithOne(i => i.Sender)
                    .HasForeignKey(i => i.SenderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configures one-to-many relationship with ReceivedInvitations
                entity.HasMany(u => u.ReceivedInvitations)
                    .WithOne(i => i.Receiver)
                    .HasForeignKey(i => i.ReceiverId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configures one-to-many relationship with GroupUsers
                entity.HasMany(u => u.GroupUsers)
                    .WithOne(gu => gu.User)
                    .HasForeignKey(gu => gu.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuration for CategoryEntity
            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                // Configures one-to-many relationship with TransactionEntity
                entity.HasMany(c => c.Transactions)
                    .WithOne(t => t.Category)
                    .HasForeignKey(t => t.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuration for GroupEntity
            modelBuilder.Entity<GroupEntity>(entity =>
            {
                // Configures one-to-many relationship with GroupUserEntity
                entity.HasMany(g => g.GroupUsers)
                    .WithOne(gu => gu.Group)
                    .HasForeignKey(gu => gu.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configures one-to-many relationship with InvitationEntity
                entity.HasMany(g => g.Invitations)
                    .WithOne(i => i.Group)
                    .HasForeignKey(i => i.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuration for GroupUserEntity
            modelBuilder.Entity<GroupUserEntity>(entity =>
            {
                // Configures one-to-many relationship with UserEntity
                entity.HasOne(gu => gu.User)
                    .WithMany(u => u.GroupUsers)
                    .HasForeignKey(gu => gu.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configures one-to-many relationship with GroupEntity
                entity.HasOne(gu => gu.Group)
                    .WithMany(g => g.GroupUsers)
                    .HasForeignKey(gu => gu.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configures one-to-many relationship with TransactionGroupUserEntity
                entity.HasMany(gu => gu.TransactionGroupUsers)
                    .WithOne(tgu => tgu.GroupUser)
                    .HasForeignKey(tgu => tgu.GroupUserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configures one-to-one relationship with LimitEntity
                entity.HasOne(gu => gu.Limit)
                    .WithOne(l => l.GroupUser)
                    .HasForeignKey<LimitEntity>(l => l.GroupUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuration for InvitationEntity
            modelBuilder.Entity<InvitationEntity>(entity =>
            {
                // Configures one-to-one relationship with Sender UserEntity
                entity.HasOne(i => i.Sender)
                    .WithMany(u => u.SentInvitations)
                    .HasForeignKey(i => i.SenderId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configures one-to-one relationship with Receiver UserEntity
                entity.HasOne(i => i.Receiver)
                    .WithMany(u => u.ReceivedInvitations)
                    .HasForeignKey(i => i.ReceiverId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configures one-to-many relationship with GroupEntity
                entity.HasOne(i => i.Group)
                    .WithMany(g => g.Invitations)
                    .HasForeignKey(i => i.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuration for TransactionGroupUserEntity
            modelBuilder.Entity<TransactionGroupUserEntity>(entity =>
            {
                // Configures one-to-many relationship with TransactionEntity
                entity.HasOne(tgu => tgu.Transaction)
                    .WithMany(t => t.TransactionGroupUsers)
                    .HasForeignKey(tgu => tgu.TransactionId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configures one-to-many relationship with GroupUserEntity
                entity.HasOne(tgu => tgu.GroupUser)
                    .WithMany(gu => gu.TransactionGroupUsers)
                    .HasForeignKey(tgu => tgu.GroupUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuration for LimitEntity
            modelBuilder.Entity<LimitEntity>(entity =>
            {
                // Creates a unique index on GroupUserId property
                entity.HasIndex(l => l.GroupUserId)
                    .IsUnique();

                // Configures one-to-one relationship with GroupUserEntity
                entity.HasOne(l => l.GroupUser)
                    .WithOne(gu => gu.Limit)
                    .HasForeignKey<LimitEntity>(l => l.GroupUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
