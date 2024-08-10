using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.Entities;
using SpendWise.DAL.Configurations;
using SpendWise.DAL.Seeds;

namespace SpendWise.DAL
{
    /// <summary>
    /// Represents the database context for the SpendWise application, including DbSets and configuration.
    /// </summary>
    public class SpendWiseDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpendWiseDbContext"/> class.
        /// </summary>
        /// <param name="contextOptions">The options to configure the context.</param>
        /// <param name="seedDemoData">Whether to seed demo data into the database.</param>
        public SpendWiseDbContext(DbContextOptions<SpendWiseDbContext> contextOptions, bool seedDemoData = false)
            : base(contextOptions)
        {
            SeedDemoData = seedDemoData;
        }

        /// <summary>
        /// Gets or sets the DbSet for transactions.
        /// </summary>
        public DbSet<TransactionEntity> Transactions { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for users.
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for categories.
        /// </summary>
        public DbSet<CategoryEntity> Categories { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for limits.
        /// </summary>
        public DbSet<LimitEntity> Limits { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for groups.
        /// </summary>
        public DbSet<GroupEntity> Groups { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for group users.
        /// </summary>
        public DbSet<GroupUserEntity> GroupUsers { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for invitations.
        /// </summary>
        public DbSet<InvitationEntity> Invitations { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for transaction group users.
        /// </summary>
        public DbSet<TransactionGroupUserEntity> TransactionGroupUsers { get; set; }

        /// <summary>
        /// Configures the model using the provided <see cref="ModelBuilder"/> instance.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the context's model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configuration for entities
            EntityConstraintsConfiguration.Configure(modelBuilder);
            EntityIndexesConfiguration.Configure(modelBuilder);
            EntityKeysConfiguration.Configure(modelBuilder);
            EntityPropertiesConfiguration.Configure(modelBuilder);
            EntityRelationshipsConfiguration.Configure(modelBuilder);

            // Seed data if specified
            if (SeedDemoData)
            {
                ApplySeeds(modelBuilder);
            }
        }

        private bool SeedDemoData { get; }

        private void ApplySeeds(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplySeeds();
        }
    }
}
