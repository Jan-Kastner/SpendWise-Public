using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects.Interfaces
{
    /// <summary>
    /// Represents a query object interface for categories.
    /// Provides methods for querying categories by various properties.
    /// </summary>
    public interface ICategoryQueryObject : IQueryObject, IIdQuery<CategoryQueryObject>, INameQuery<CategoryQueryObject>, IDescriptionQuery<CategoryQueryObject>, IColorQuery<CategoryQueryObject>, IIconQuery<CategoryQueryObject>
    {
    }
}