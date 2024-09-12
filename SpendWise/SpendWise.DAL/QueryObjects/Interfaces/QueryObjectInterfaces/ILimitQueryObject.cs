using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for limits.
    /// Provides methods for querying limits by various properties.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ILimitQueryObject<T> : IIdQuery<T>, IGroupUserQuery<T>, IAmountQuery<T>, INoticeTypeQuery<T>
    {
    }
}