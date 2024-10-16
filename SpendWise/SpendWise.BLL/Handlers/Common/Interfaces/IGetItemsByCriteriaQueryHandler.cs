using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.BLL.DTOs;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetItemsByCriteriaQueryHandler<TCreateDto, TUpdateDto, TCriteriaQuery, TDto>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : class, IUpdatableDto
        where TCriteriaQuery : ICriteriaQuery
        where TDto : class, IQueryableDto
    {
        Task<IEnumerable<TDto>> Handle(TCriteriaQuery queryObject);
    }
}