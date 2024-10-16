using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service managing categories.
    /// </summary>
    public interface ICategoryService : IService<CategoryCreateDto, CategoryUpdateDto, ICategoryCriteriaQuery>
    {
    }
}