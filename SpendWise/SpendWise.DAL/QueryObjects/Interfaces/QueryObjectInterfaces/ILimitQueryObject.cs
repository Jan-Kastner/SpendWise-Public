using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects.Interfaces
{
    /// <summary>
    /// Represents a query object interface for limits.
    /// Provides methods for querying limits by various properties.
    /// </summary>
    public interface ILimitQueryObject : IQueryObject, IIdQuery<LimitQueryObject>, IGroupUserIdQuery<LimitQueryObject>, IAmountQuery<LimitQueryObject>, INoticeTypeQuery<LimitQueryObject>
    {
    }
}