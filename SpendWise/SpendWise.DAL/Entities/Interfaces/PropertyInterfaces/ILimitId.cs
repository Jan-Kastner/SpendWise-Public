namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a limit ID.
    /// </summary>
    public interface ILimitId
    {
        /// <summary>
        /// Gets or sets the limit ID of the entity.
        /// </summary>
        Guid? LimitId { get; set; }
    }
}