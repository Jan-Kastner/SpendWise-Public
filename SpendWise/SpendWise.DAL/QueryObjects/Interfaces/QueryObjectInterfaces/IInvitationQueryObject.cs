using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for invitations.
    /// Provides methods for querying invitations by various properties.
    /// </summary>
    public interface IInvitationQueryObject : IQueryObject, IIdQuery<InvitationQueryObject>, ISentDateQuery<InvitationQueryObject>, IResponseDateQuery<InvitationQueryObject>, IIsAcceptedQuery<InvitationQueryObject>, ISenderQuery<InvitationQueryObject>, IReceiverQuery<InvitationQueryObject>, IGroupQuery<InvitationQueryObject>
    {
    }
}