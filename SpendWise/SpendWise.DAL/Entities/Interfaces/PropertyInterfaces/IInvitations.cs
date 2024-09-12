namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a collection of invitations.
    /// </summary>
    public interface IInvitations
    {
        /// <summary>
        /// Gets the collection of invitations of the entity.
        /// </summary>
        ICollection<InvitationEntity> Invitations { get; init; }
    }
}