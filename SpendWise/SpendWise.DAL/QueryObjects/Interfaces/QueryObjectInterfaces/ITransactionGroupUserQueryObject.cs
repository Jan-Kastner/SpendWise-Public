using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for transaction group users.
    /// Provides methods for querying transaction group users by various properties.
    /// </summary>
    public interface ITransactionGroupUserQueryObject : IQueryObject, IIdQuery<TransactionGroupUserQueryObject>, IGroupUserQuery<TransactionGroupUserQueryObject>, ITransactionQuery<TransactionGroupUserQueryObject>, IIsReadQuery<TransactionGroupUserQueryObject>
    {
    }
}