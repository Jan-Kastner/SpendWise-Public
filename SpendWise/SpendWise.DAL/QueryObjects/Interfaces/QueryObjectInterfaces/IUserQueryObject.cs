using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;
using SpendWise.Common.Enums;
using SpendWise.DAL.Entities;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for users.
    /// Provides methods for querying users by various properties.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IUserQueryObject<T> : IIdQuery<T>, INameQuery<T>, IGroupUserQuery<T>, ISurnameQuery<T>, IEmailQuery<T>, IPasswordQuery<T>, IPhotoQuery<T>, IEmailConfirmedQuery<T>, ITwoFactorEnabledQuery<T>, IResetPasswordTokenQuery<T>, IPreferredThemeQuery<T>, IFullNameQuery<T>, IEmailDomainQuery<T>, IDateOfRegistrationQuery<T>, ISentInvitationQuery<T>, IReceivedInvitationQuery<T>
    {
    }
}