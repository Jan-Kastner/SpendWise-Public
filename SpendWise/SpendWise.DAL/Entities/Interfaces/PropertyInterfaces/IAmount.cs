namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has an amount.
    /// </summary>
    public interface IAmount
    {
        /// <summary>
        /// Gets or sets the amount of the entity.
        /// </summary>
        decimal Amount { get; set; }
    }
}