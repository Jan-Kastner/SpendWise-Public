using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for invitations.
    /// Provides methods for querying invitations by various properties.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface IInvitationQueryObject<T> : IIdQuery<T>, ISentDateQuery<T>, IResponseDateQuery<T>, IIsAcceptedQuery<T>, ISenderQuery<T>, IReceiverQuery<T>, IGroupQuery<T>
    {
    }
}