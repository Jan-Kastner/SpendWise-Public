namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a date.
    /// </summary>
    public interface IDate
    {
        /// <summary>
        /// Gets or sets the date of the entity.
        /// </summary>
        DateTime Date { get; init; }
    }
}