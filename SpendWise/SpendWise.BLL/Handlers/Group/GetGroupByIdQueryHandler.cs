using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetGroupByIdQueryHandler<TDto> : GetItemByIdQueryHandler<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery, TDto>, IGetGroupByIdQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetGroupByIdQueryHandler(IGroupService service) : base(service)
        {
        }
    }
}