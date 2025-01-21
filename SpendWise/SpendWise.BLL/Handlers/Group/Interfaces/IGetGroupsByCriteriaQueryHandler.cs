using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetGroupsByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}