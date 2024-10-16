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
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the group. Can be null.
        /// </summary>
        public required string? Description { get; init; } = null;

        public ICollection<GroupUserDto> GroupUsers { get; init; } = new List<GroupUserDto>();

        public ICollection<InvitationDto> Invitations { get; init; } = new List<InvitationDto>();
    }
}
