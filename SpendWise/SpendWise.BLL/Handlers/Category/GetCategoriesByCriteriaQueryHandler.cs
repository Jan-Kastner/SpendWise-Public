using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetCategoriesByCriteriaQueryHandler<TDto> : GetItemsByCriteriaQueryHandler<CategoryCreateDto, CategoryUpdateDto, ICategoryCriteriaQuery, TDto>, IGetCategoriesByCriteriaQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetCategoriesByCriteriaQueryHandler(ICategoryService service) : base(service)
        {
        }
    }
}