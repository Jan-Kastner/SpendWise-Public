namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a date of registration.
    /// </summary>
    public interface IDateOfRegistration
    {
        /// <summary>
        /// Gets or sets the date of registration of the entity.
        /// </summary>
        DateTime DateOfRegistration { get; init; }
    }
}