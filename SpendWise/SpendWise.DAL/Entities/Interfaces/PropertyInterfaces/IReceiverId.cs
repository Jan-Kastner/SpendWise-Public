namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a receiver ID.
    /// </summary>
    public interface IReceiverId
    {
        /// <summary>
        /// Gets the receiver ID of the entity.
        /// </summary>
        Guid ReceiverId { get; init; }
    }
}