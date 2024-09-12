using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for group users.
    /// Provides methods for querying group users by various properties.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IGroupUserQueryObject<T> : IIdQuery<T>, IUserRoleQuery<T>, IUserQuery<T>, IGroupQuery<T>, ILimitQuery<T>, ITransactionGroupUserQuery<T>
    {
    }
}