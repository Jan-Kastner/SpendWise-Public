namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a limit entity within the SpendWise application.
    /// </summary>
    public record LimitEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the limit.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated group-user relationship.
        /// </summary>
        public required Guid GroupUserId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the group-user associated with the limit. Can be null.
        /// </summary>
        public required GroupUserEntity GroupUser { get; init; }

        /// <summary>
        /// Gets or sets the amount of the limit.
        /// </summary>
        public required decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the type of notice associated with the limit.
        /// </summary>
        public required int NoticeType { get; set; }
    }
}
