namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a two-factor authentication secret.
    /// </summary>
    public interface ITwoFactorSecret
    {
        /// <summary>
        /// Gets or sets the two-factor authentication secret of the entity.
        /// </summary>
        string? TwoFactorSecret { get; init; }
    }
}