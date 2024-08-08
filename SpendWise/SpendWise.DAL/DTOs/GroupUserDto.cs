namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a group-user.
    /// </summary>
    public record GroupUserDto : IDto
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
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public required Guid GroupId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the limit. Can be null.
        /// </summary>
        public Guid? LimitId { get; set; }
    }
}

