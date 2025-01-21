using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetGroupByIdQueryHandler<TDto> : IGetItemByIdQueryHandler<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}