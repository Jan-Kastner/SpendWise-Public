namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a base interface for all data transfer objects (DTOs) in the SpendWise application.
    /// </summary>
    public interface IDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        Guid Id { get; init; }
    }
}
