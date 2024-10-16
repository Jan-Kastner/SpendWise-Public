namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a reset password token expiry date.
    /// </summary>
    public interface IResetPasswordTokenExpiry
    {
        /// <summary>
        /// Gets or sets the reset password token expiry date of the entity.
        /// </summary>
        DateTime? ResetPasswordTokenExpiry { get; init; }
    }
}