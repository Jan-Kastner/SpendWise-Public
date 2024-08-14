using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.Configurations
{
    /// <summary>
    /// Provides configuration for entity constraints in the SpendWise application.
    /// </summary>
    public static class EntityConstraintsConfiguration
    {
        /// <summary>
        /// Configures entity constraints using the specified <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> instance used to configure entity constraints.</param>
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Configuration for the TransactionEntity
            modelBuilder.Entity<TransactionEntity>()
                .ToTable(tb =>
                {
                    // Ensures the Amount is greater than 0
                    tb.HasCheckConstraint("CK_TransactionEntity_Amount", "\"Amount\" > 0");

                    // Ensures the Date is less than or equal to the current date and time
                    tb.HasCheckConstraint("CK_TransactionEntity_Date", "\"Date\" <= NOW()");

                    // Ensures the Type is either 1 or 2
                    tb.HasCheckConstraint("CK_TransactionEntity_Type", "\"Type\" IN (1, 2)");
                });

            // Configuration for the InvitationEntity
            modelBuilder.Entity<InvitationEntity>(entity =>
            {
                entity.ToTable(tb =>
                {
                    // Ensures the SentDate is less than or equal to the current date and time
                    tb.HasCheckConstraint("CK_InvitationEntity_SentDate", "\"SentDate\" <= NOW()");

                    // Ensures ResponseDate is either null or greater than or equal to SentDate
                    tb.HasCheckConstraint(
                        "CK_InvitationEntity_ResponseDate",
                        "\"ResponseDate\" IS NULL OR \"ResponseDate\" >= \"SentDate\"");

                    // Ensures IsAccepted is either true, false, or null
                    tb.HasCheckConstraint(
                        "CK_InvitationEntity_IsAccepted",
                        "\"IsAccepted\" IS NULL OR \"IsAccepted\" IN (true, false)");
                });
            });

            // Configuration for the LimitEntity
            modelBuilder.Entity<LimitEntity>(entity =>
            {
                entity.ToTable(tb =>
                {
                    // Ensures the Amount is greater than or equal to 0
                    tb.HasCheckConstraint("CK_Limit_Amount", "\"Amount\" >= 0");

                    // Ensures NoticeType is either 0, 1, or 2
                    tb.HasCheckConstraint("CK_Limit_NoticeType", "\"NoticeType\" IN (0, 1, 2)");
                });
            });

            // Configuration for the UserEntity
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable(tb =>
                {
                    // Ensures Date_of_registration is less than or equal to the current date and time
                    tb.HasCheckConstraint(
                        "CK_UserEntity_Date_of_registration",
                        "\"Date_of_registration\" <= NOW()");
                });
            });

            // Configuration for the GroupEntity
            modelBuilder.Entity<GroupEntity>(entity =>
            {
                entity.ToTable(tb =>
                {
                    // Ensures Name is not null and has a length greater than 0
                    tb.HasCheckConstraint(
                        "CK_GroupEntity_Name",
                        "\"Name\" IS NOT NULL AND LENGTH(\"Name\") > 0");
                });
            });
        }
    }
}
