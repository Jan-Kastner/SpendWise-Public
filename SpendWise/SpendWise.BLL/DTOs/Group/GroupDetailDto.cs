namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about a group.
    /// </summary>
    public record GroupDetailDto
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

        /// <summary>
        /// Gets or sets the list of users associated with the group.
        /// </summary>
        public IEnumerable<GroupUserListDto> GroupUsers { get; set; } = new List<GroupUserListDto>();

        /// <summary>
        /// Gets or sets the list of invitations associated with the group.
        /// </summary>
        public IEnumerable<InvitationListDto> Invitations { get; set; } = new List<InvitationListDto>();
    }
}