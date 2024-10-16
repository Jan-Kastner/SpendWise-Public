namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a list of sent invitations.
    /// </summary>
    /// <typeparam name="TInvitationDto">The type of the invitation DTO.</typeparam>
    public interface ISentInvitationsDto<TInvitationDto> where TInvitationDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the list of sent invitations associated with the entity.
        /// </summary>
        IEnumerable<TInvitationDto> SentInvitations { get; set; }
    }
}