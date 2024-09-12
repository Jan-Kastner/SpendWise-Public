namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an invitation entity with various properties and behaviors.
    /// </summary>
    public interface IInvitationEntity : IEntity, ISenderId, IReceiverId, IGroupId, ISentDate, IResponseDate, IIsAccepted
    {
    }
}