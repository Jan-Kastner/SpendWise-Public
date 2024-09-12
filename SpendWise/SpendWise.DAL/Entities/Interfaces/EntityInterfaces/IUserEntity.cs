namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a user entity with various properties.
    /// </summary>
    public interface IUserEntity : IEntity, IName, ISurname, IEmail, IPasswordHash, IDateOfRegistration, IPhoto, IIsEmailConfirmed, IEmailConfirmationToken, IResetPasswordToken, IResetPasswordTokenExpiry, IIsTwoFactorEnabled, ITwoFactorSecret, IPreferredTheme
    {
    }
}