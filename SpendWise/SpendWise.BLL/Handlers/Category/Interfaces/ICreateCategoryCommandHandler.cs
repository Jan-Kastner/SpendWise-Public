using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    /// <summary>
    /// Interface for handling the create category command.
    /// </summary>
    public interface ICreateCategoryCommandHandler : ICreateItemCommandHandler<CategoryCreateDto, CategoryUpdateDto, ICategoryCriteriaQuery>
    {
    }
}