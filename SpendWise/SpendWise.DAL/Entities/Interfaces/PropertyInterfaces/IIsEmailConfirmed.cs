namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has an email confirmation status.
    /// </summary>
    public interface IIsEmailConfirmed
    {
        /// <summary>
        /// Gets or sets a value indicating whether the email is confirmed.
        /// </summary>
        bool IsEmailConfirmed { get; set; }
    }
}