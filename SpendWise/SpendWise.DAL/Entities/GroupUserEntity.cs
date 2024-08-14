namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a group-user relationship entity within the SpendWise application.
    /// </summary>
    public record GroupUserEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the group-user relationship.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public required Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user entity associated with this group-user relationship.
        /// </summary>
        public required UserEntity User { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public required Guid GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group entity associated with this group-user relationship.
        /// </summary>
        public required GroupEntity Group { get; init; }

        /// <summary>
        /// Gets or sets the limit entity associated with this group-user relationship. Can be null.
        /// </summary>
        public LimitEntity? Limit { get; init; }

        /// <summary>
        /// Gets the collection of transaction group-user relationships associated with this group-user relationship.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the transaction group-user relationships related to this group-user relationship.
        /// </remarks>
        public ICollection<TransactionGroupUserEntity> TransactionGroupUsers { get; init; } = new List<TransactionGroupUserEntity>();
    }
}
