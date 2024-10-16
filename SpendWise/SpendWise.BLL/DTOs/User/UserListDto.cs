using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a user for listing purposes.
    /// </summary>
    public record UserListDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the photo of the user.
        /// </summary>
        public required byte[] Photo { get; set; } = Array.Empty<byte>();
    }
}