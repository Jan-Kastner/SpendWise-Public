namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a two-factor authentication enabled status.
    /// </summary>
    public interface IIsTwoFactorEnabled
    {
        /// <summary>
        /// Gets or sets a value indicating whether two-factor authentication is enabled.
        /// </summary>
        bool IsTwoFactorEnabled { get; set; }
    }
}