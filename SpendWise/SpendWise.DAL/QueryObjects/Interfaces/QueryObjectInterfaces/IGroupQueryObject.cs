using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for groups.
    /// Provides methods for querying groups by various properties.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IGroupQueryObject<T> : IIdQuery<T>, INameQuery<T>, IDescriptionQuery<T>, IGroupUserQuery<T>, IInvitationQuery<T>
    {
    }
}