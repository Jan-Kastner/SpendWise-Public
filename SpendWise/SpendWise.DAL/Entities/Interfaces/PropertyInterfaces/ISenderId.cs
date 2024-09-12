namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a sender ID.
    /// </summary>
    public interface ISenderId
    {
        /// <summary>
        /// Gets the sender ID of the entity.
        /// </summary>
        Guid SenderId { get; init; }
    }
}