using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.Entities;
using SpendWise.DAL.Configurations;

namespace SpendWise.DAL.dbContext
{
    /// <summary>
    /// Base class for the SpendWise database context, providing common configurations and DbSets 
    /// for the application. Inherits from <see cref="DbContext"/> and implements <see cref="IDbContext"/>.
    /// </summary>
    public abstract class SpendWiseDbContextBase : DbContext, IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpendWiseDbContextBase"/> class with the
        /// specified options.
        /// </summary>
        /// <param name="options">
        /// The options to be used by the <see cref="SpendWiseDbContextBase"/>. This is typically 
        /// provided by the dependency injection container or a factory.
        /// </param>
        protected SpendWiseDbContextBase(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TransactionEntity}"/> representing the collection of 
        /// <see cref="TransactionEntity"/> entities in the context.
        /// </summary>
        public DbSet<TransactionEntity> Transactions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserEntity}"/> representing the collection of 
        /// <see cref="UserEntity"/> entities in the context.
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{CategoryEntity}"/> representing the collection of 
        /// <see cref="CategoryEntity"/> entities in the context.
        /// </summary>
        public DbSet<CategoryEntity> Categories { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{LimitEntity}"/> representing the collection of 
        /// <see cref="LimitEntity"/> entities in the context.
        /// </summary>
        public DbSet<LimitEntity> Limits { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{GroupEntity}"/> representing the collection of 
        /// <see cref="GroupEntity"/> entities in the context.
        /// </summary>
        public DbSet<GroupEntity> Groups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{GroupUserEntity}"/> representing the collection of 
        /// <see cref="GroupUserEntity"/> entities in the context.
        /// </summary>
        public DbSet<GroupUserEntity> GroupUsers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{InvitationEntity}"/> representing the collection of 
        /// <see cref="InvitationEntity"/> entities in the context.
        /// </summary>
        public DbSet<InvitationEntity> Invitations { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TransactionGroupUserEntity}"/> representing the collection of 
        /// <see cref="TransactionGroupUserEntity"/> entities in the context.
        /// </summary>
        public DbSet<TransactionGroupUserEntity> TransactionGroupUsers { get; set; }

        /// <summary>
        /// Configures the model for the context using the specified <see cref="ModelBuilder"/>.
        /// Applies various entity configurations and then calls <see cref="ApplySeeding(ModelBuilder)"/>.
        /// </summary>
        /// <param name="modelBuilder">
        /// The <see cref="ModelBuilder"/> used to configure the model.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations for entities
            EntityConstraintsConfiguration.Configure(modelBuilder);
            EntityIndexesConfiguration.Configure(modelBuilder);
            EntityKeysConfiguration.Configure(modelBuilder);
            EntityPropertiesConfiguration.Configure(modelBuilder);
            EntityRelationshipsConfiguration.Configure(modelBuilder);

            // Seeding is left to derived classes
            ApplySeeding(modelBuilder);
        }

        /// <summary>
        /// Configures the model with seed data. This method is intended to be overridden by 
        /// derived classes to provide seeding logic specific to different environments, such as 
        /// testing or production.
        /// </summary>
        /// <param name="modelBuilder">
        /// The <see cref="ModelBuilder"/> used to configure the model.
        /// </param>
        protected abstract void ApplySeeding(ModelBuilder modelBuilder);
    }
}
