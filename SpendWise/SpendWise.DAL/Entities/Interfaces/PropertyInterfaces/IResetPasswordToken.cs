namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a reset password token.
    /// </summary>
    public interface IResetPasswordToken
    {
        /// <summary>
        /// Gets or sets the reset password token of the entity.
        /// </summary>
        string? ResetPasswordToken { get; init; }
    }
}