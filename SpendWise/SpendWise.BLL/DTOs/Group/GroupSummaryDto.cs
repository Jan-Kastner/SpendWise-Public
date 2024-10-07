namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary data transfer object (DTO) for a group.
    /// </summary>
    public record GroupSummaryDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public required string Name { get; set; }
    }
}