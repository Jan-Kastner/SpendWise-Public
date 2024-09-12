using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for transactions.
    /// Provides methods for querying transactions by various properties.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ITransactionQueryObject<T> : IIdQuery<T>, IDescriptionQuery<T>, IAmountQuery<T>, ITransactionGroupUserQuery<T>, IDateQuery<T>, ITransactionTypeQuery<T>, ICategoryQuery<T>
    {
    }
}