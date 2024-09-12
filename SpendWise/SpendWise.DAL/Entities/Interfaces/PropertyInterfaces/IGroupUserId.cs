namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a group user ID.
    /// </summary>
    public interface IGroupUserId
    {
        /// <summary>
        /// Gets the group user ID of the entity.
        /// </summary>
        Guid GroupUserId { get; init; }
    }
}