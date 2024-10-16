using SpendWise.Common.Enums;
using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a group user for listing purposes.
    /// </summary>
    public record GroupUserListDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group user.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the role of the user within the group.
        /// </summary>
        public required UserRole Role { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the group.
        /// </summary>
        public UserListDto? User { get; set; }
    }
}