namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a list of invitations.
    /// </summary>
    /// <typeparam name="TInvitationDto">The type of the invitation DTO.</typeparam>
    public interface IInvitationsDto<TInvitationDto> where TInvitationDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the list of invitations associated with the entity.
        /// </summary>
        IEnumerable<TInvitationDto> Invitations { get; set; }
    }
}