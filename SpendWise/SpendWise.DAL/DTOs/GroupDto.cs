namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for a group.
    /// </summary>
    public record GroupDto : IDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the group. Can be null.
        /// </summary>
        public string? Description { get; set; }
    }
}
