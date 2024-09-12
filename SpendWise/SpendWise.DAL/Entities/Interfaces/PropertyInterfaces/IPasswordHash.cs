namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a password hash.
    /// </summary>
    public interface IPasswordHash
    {
        /// <summary>
        /// Gets or sets the password hash of the entity.
        /// </summary>
        string PasswordHash { get; set; }
    }
}