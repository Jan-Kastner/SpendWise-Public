using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.Configurations
{
    /// <summary>
    /// Provides configuration for entity properties in the SpendWise application.
    /// </summary>
    public static class EntityPropertiesConfiguration
    {
        /// <summary>
        /// Configures the properties of entities using the specified <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> instance used to configure entity properties.</param>
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Configuration for TransactionEntity
            modelBuilder.Entity<TransactionEntity>(entity =>
            {
                // Configures Amount property: required and stored as decimal with precision 18 and scale 2
                entity.Property(t => t.Amount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                // Configures Date property: required and stored as timestamp with time zone
                entity.Property(t => t.Date)
                    .IsRequired()
                    .HasColumnType("timestamp(3) with time zone");

                // Configures Description property: optional with a maximum length of 200 characters
                entity.Property(t => t.Description)
                    .HasMaxLength(200);
            });

            // Configuration for CategoryEntity
            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                // Configures Id property: required and stored as UUID
                entity.Property(c => c.Id)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures Name property: required with a maximum length of 100 characters
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configures Description property: optional with a maximum length of 200 characters
                entity.Property(c => c.Description)
                    .HasMaxLength(200);

                // Configures Color property: required with a maximum length of 7 characters
                entity.Property(c => c.Color)
                    .IsRequired()
                    .HasMaxLength(7);

                // Configures Icon property: stored as byte array
                entity.Property(c => c.Icon)
                    .HasColumnType("bytea");
            });

            // Configuration for GroupEntity
            modelBuilder.Entity<GroupEntity>(entity =>
            {
                // Configures Id property: required and stored as UUID
                entity.Property(g => g.Id)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures Name property: required with a maximum length of 100 characters
                entity.Property(g => g.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configures Description property: optional with a maximum length of 200 characters
                entity.Property(g => g.Description)
                    .HasMaxLength(200);
            });

            // Configuration for GroupUserEntity
            modelBuilder.Entity<GroupUserEntity>(entity =>
            {
                // Configures Id property: required and stored as UUID
                entity.Property(gu => gu.Id)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures UserId property: required and stored as UUID
                entity.Property(gu => gu.UserId)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures GroupId property: required and stored as UUID
                entity.Property(gu => gu.GroupId)
                    .IsRequired()
                    .HasColumnType("uuid");
            });

            // Configuration for InvitationEntity
            modelBuilder.Entity<InvitationEntity>(entity =>
            {
                // Configures Id property: required and stored as UUID
                entity.Property(i => i.Id)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures SenderId property: required and stored as UUID
                entity.Property(i => i.SenderId)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures ReceiverId property: required and stored as UUID
                entity.Property(i => i.ReceiverId)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures GroupId property: required and stored as UUID
                entity.Property(i => i.GroupId)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures SentDate property: required and stored as timestamp with time zone
                entity.Property(i => i.SentDate)
                    .IsRequired()
                    .HasColumnType("timestamp(3) with time zone");

                // Configures ResponseDate property: optional and stored as timestamp with time zone
                entity.Property(i => i.ResponseDate)
                    .HasColumnType("timestamp(3) with time zone");

                // Configures IsAccepted property: optional and stored as boolean
                entity.Property(i => i.IsAccepted)
                    .HasColumnType("boolean");
            });

            // Configuration for LimitEntity
            modelBuilder.Entity<LimitEntity>(entity =>
            {
                // Configures Id property: required and stored as UUID
                entity.Property(l => l.Id)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures GroupUserId property: required and stored as UUID
                entity.Property(l => l.GroupUserId)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures Amount property: required and stored as decimal with precision 18 and scale 2
                entity.Property(l => l.Amount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                // Configures NoticeType property: required and stored as integer
                entity.Property(l => l.NoticeType)
                    .IsRequired();

                // Creates a unique index on GroupUserId property
                entity.HasIndex(l => l.GroupUserId)
                    .IsUnique();
            });

            // Configuration for UserEntity
            modelBuilder.Entity<UserEntity>(entity =>
            {
                // Configures Id property: required and stored as UUID
                entity.Property(u => u.Id)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures Name property: required with a minimum length of 2 characters and maximum length of 100 characters
                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configures Surname property: required with a minimum length of 2 characters and maximum length of 100 characters
                entity.Property(u => u.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configures Email property: required with a minimum length of 5 characters and maximum length of 255 characters
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                // Configures PasswordHash property: required with a minimum length of 8 characters and maximum length of 255 characters
                entity.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255);

                // Configures DateOfRegistration property: required and stored as timestamp with time zone
                entity.Property(u => u.DateOfRegistration)
                    .IsRequired()
                    .HasColumnType("timestamp(3) with time zone");

                // Configures Photo property: stored as byte array, can be null
                entity.Property(u => u.Photo)
                    .HasColumnType("bytea");

                // Configures IsEmailConfirmed property: required with default value of false
                entity.Property(u => u.IsEmailConfirmed)
                    .IsRequired();

                // Configures EmailConfirmationToken property: can be null
                entity.Property(u => u.EmailConfirmationToken)
                    .HasMaxLength(255); // You can adjust the max length as per your requirement

                // Configures ResetPasswordToken property: can be null
                entity.Property(u => u.ResetPasswordToken)
                    .HasMaxLength(255); // You can adjust the max length as per your requirement

                // Configures ResetPasswordTokenExpiry property: can be null
                entity.Property(u => u.ResetPasswordTokenExpiry)
                    .HasColumnType("timestamp(3) with time zone"); // Assuming you want to keep the same type

                // Configures IsTwoFactorEnabled property: required with default value of false
                entity.Property(u => u.IsTwoFactorEnabled)
                    .IsRequired();

                // Configures TwoFactorSecret property: can be null
                entity.Property(u => u.TwoFactorSecret)
                    .HasMaxLength(255); // You can adjust the max length as per your requirement

                // Configures Role property: required with a default value of UserRole.User
                entity.Property(u => u.Role)
                    .IsRequired();

                // Configures PreferredTheme property: required with a default value of Theme.SystemDefault
                entity.Property(u => u.PreferredTheme)
                    .IsRequired();
            });

            // Configuration for TransactionGroupUserEntity
            modelBuilder.Entity<TransactionGroupUserEntity>(entity =>
            {
                // Configures Id property: required and stored as UUID
                entity.Property(tgu => tgu.Id)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures TransactionId property: required and stored as UUID
                entity.Property(tgu => tgu.TransactionId)
                    .IsRequired()
                    .HasColumnType("uuid");

                // Configures GroupUserId property: required and stored as UUID
                entity.Property(tgu => tgu.GroupUserId)
                    .IsRequired()
                    .HasColumnType("uuid");
            });

            // Configuration for UserEntity unique index on Email property
            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
