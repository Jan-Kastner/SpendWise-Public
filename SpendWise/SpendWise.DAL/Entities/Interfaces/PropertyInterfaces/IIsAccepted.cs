namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has an acceptance status.
    /// </summary>
    public interface IIsAccepted
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is accepted.
        /// </summary>
        bool? IsAccepted { get; set; }
    }
}