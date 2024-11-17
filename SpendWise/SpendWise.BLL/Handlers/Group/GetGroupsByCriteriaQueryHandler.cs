using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetGroupsByCriteriaQueryHandler<TDto> : GetItemsByCriteriaQueryHandler<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery, TDto>, IGetGroupsByCriteriaQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetGroupsByCriteriaQueryHandler(IGroupService service) : base(service)
        {
        }
    }
}