using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.BLL.DTOs;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetItemByIdQueryHandler<TCreateDto, TUpdateDto, TCriteriaQuery, TDto>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : class, IUpdatableDto
        where TCriteriaQuery : class, ICriteriaQuery<TCriteriaQuery>
        where TDto : class, IQueryableDto
    {
        Task<TDto> Handle(IIdQuery query);
    }
}