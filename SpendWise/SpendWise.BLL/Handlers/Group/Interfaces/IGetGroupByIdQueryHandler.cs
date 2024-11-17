using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetGroupByIdQueryHandler<TDto> : IGetItemByIdQueryHandler<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}