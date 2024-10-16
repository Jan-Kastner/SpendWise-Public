namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a response date.
    /// </summary>
    public interface IResponseDate
    {
        /// <summary>
        /// Gets or sets the response date of the entity.
        /// </summary>
        DateTime? ResponseDate { get; init; }
    }
}