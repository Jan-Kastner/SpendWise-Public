namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a base interface for all entities in the SpendWise application.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        Guid Id { get; set; }
    }
}