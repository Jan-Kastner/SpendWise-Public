using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a group for listing purposes.
    /// </summary>
    public record GroupListDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the group.
        /// </summary>
        public string? Description { get; set; }
    }
}