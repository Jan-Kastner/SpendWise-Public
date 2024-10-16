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
    public interface IUserQueryObject : IQueryObject, IIdQuery<UserQueryObject>, INameQuery<UserQueryObject>, IGroupUserQuery<UserQueryObject>, ISurnameQuery<UserQueryObject>, IEmailQuery<UserQueryObject>, IPasswordQuery<UserQueryObject>, IPhotoQuery<UserQueryObject>, IEmailConfirmedQuery<UserQueryObject>, ITwoFactorEnabledQuery<UserQueryObject>, IResetPasswordTokenQuery<UserQueryObject>, IPreferredThemeQuery<UserQueryObject>, IFullNameQuery<UserQueryObject>, IEmailDomainQuery<UserQueryObject>, IDateOfRegistrationQuery<UserQueryObject>, ISentInvitationQuery<UserQueryObject>, IReceivedInvitationQuery<UserQueryObject>
    {
    }
}