using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetLimitByIdQueryHandler<TDto> : IGetItemByIdQueryHandler<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}