using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects.Interfaces
{
    /// <summary>
    /// Represents a query object interface for groups.
    /// Provides methods for querying groups by various properties.
    /// </summary>
    public interface IGroupQueryObject : IQueryObject, IIdQuery<GroupQueryObject>, INameQuery<GroupQueryObject>, IDescriptionQuery<GroupQueryObject>, IGroupUserIdQuery<GroupQueryObject>, IInvitationIdQuery<GroupQueryObject>, IUserIdQuery<GroupQueryObject>
    {
    }
}