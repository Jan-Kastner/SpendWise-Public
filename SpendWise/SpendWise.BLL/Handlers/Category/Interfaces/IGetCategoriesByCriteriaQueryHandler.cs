using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetCategoriesByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<CategoryCreateDto, CategoryUpdateDto, ICategoryCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}