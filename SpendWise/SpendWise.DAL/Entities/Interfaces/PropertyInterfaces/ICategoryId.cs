namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a category ID.
    /// </summary>
    public interface ICategoryId
    {
        /// <summary>
        /// Gets or sets the category ID of the entity.
        /// </summary>
        Guid? CategoryId { get; set; }
    }
}