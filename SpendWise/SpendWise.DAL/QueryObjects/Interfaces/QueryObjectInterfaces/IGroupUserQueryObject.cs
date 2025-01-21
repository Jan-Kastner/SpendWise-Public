using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects.Interfaces
{
    /// <summary>
    /// Represents a query object interface for group users.
    /// Provides methods for querying group users by various properties.
    /// </summary>
    public interface IGroupUserQueryObject : IQueryObject, IIdQuery<GroupUserQueryObject>, IUserRoleQuery<GroupUserQueryObject>, IUserQuery<GroupUserQueryObject>, ILimitIdQuery<GroupUserQueryObject>, ITransactionGroupUserIdQuery<GroupUserQueryObject>, IGroupIdQuery<GroupUserQueryObject>
    {
    }
}