namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a surname.
    /// </summary>
    public interface ISurname
    {
        /// <summary>
        /// Gets or sets the surname of the entity.
        /// </summary>
        string Surname { get; init; }
    }
}