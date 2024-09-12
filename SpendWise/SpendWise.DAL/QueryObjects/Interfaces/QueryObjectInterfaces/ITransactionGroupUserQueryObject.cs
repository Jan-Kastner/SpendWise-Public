using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for transaction group users.
    /// Provides methods for querying transaction group users by various properties.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ITransactionGroupUserQueryObject<T> : IIdQuery<T>, IGroupUserQuery<T>, ITransactionQuery<T>, IIsReadQuery<T>
    {
    }
}