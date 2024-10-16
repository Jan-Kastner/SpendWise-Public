namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a list of received invitations.
    /// </summary>
    /// <typeparam name="TInvitationDto">The type of the invitation DTO.</typeparam>
    public interface IReceivedInvitationsDto<TInvitationDto> where TInvitationDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the list of received invitations associated with the entity.
        /// </summary>
        IEnumerable<TInvitationDto> ReceivedInvitations { get; set; }
    }
}