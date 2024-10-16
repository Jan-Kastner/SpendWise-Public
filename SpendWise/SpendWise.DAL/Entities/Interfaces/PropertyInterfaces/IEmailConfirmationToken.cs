namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has an email confirmation token.
    /// </summary>
    public interface IEmailConfirmationToken
    {
        /// <summary>
        /// Gets or sets the email confirmation token of the entity.
        /// </summary>
        string? EmailConfirmationToken { get; init; }
    }
}