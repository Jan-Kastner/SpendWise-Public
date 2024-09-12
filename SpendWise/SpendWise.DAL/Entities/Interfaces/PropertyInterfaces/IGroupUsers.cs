namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a collection of group users.
    /// </summary>
    public interface IGroupUsers
    {
        /// <summary>
        /// Gets the collection of group users of the entity.
        /// </summary>
        ICollection<GroupUserEntity> GroupUsers { get; init; }
    }
}