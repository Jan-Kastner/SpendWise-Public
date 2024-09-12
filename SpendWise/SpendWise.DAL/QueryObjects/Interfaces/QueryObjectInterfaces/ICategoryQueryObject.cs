using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for categories.
    /// Provides methods for querying categories by various properties.
    /// </summary>
    /// <typeparam name="T">The type of the query object.</typeparam>
    public interface ICategoryQueryObject<T> : IIdQuery<T>, INameQuery<T>, IDescriptionQuery<T>, IColorQuery<T>, IIconQuery<T>
    {
    }
}