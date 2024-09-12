namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a group ID.
    /// </summary>
    public interface IGroupId
    {
        /// <summary>
        /// Gets the group ID of the entity.
        /// </summary>
        Guid GroupId { get; init; }
    }
}