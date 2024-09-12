namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a user ID.
    /// </summary>
    public interface IUserId
    {
        /// <summary>
        /// Gets the user ID of the entity.
        /// </summary>
        Guid UserId { get; init; }
    }
}