using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetCategoryByIdQueryHandler<TDto> : GetItemByIdQueryHandler<CategoryCreateDto, CategoryUpdateDto, ICategoryCriteriaQuery, TDto>, IGetCategoryByIdQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetCategoryByIdQueryHandler(ICategoryService service) : base(service)
        {
        }
    }
}