namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has an email address.
    /// </summary>
    public interface IEmail
    {
        /// <summary>
        /// Gets or sets the email address of the entity.
        /// </summary>
        string Email { get; set; }
    }
}