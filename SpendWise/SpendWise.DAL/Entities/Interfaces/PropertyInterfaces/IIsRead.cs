namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a read status.
    /// </summary>
    public interface IIsRead
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is read.
        /// </summary>
        bool IsRead { get; set; }
    }
}