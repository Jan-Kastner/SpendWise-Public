namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for updating a group.
    /// </summary>
    public record GroupUpdateDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public Guid Id { get; set; }

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