namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a sent date.
    /// </summary>
    public interface ISentDate
    {
        /// <summary>
        /// Gets the sent date of the entity.
        /// </summary>
        DateTime SentDate { get; init; }
    }
}