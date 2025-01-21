using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetCategoryByIdQueryHandler<TDto> : IGetItemByIdQueryHandler<CategoryCreateDto, CategoryUpdateDto, ICategoryCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {

    }
}