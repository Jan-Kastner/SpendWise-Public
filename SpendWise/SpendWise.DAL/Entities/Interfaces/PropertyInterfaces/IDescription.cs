namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a description.
    /// </summary>
    public interface IDescription
    {
        /// <summary>
        /// Gets or sets the description of the entity.
        /// </summary>
        string? Description { get; init; }
    }
}