using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class GetGroupUsersByCriteriaQueryHandler<TDto> : GetItemsByCriteriaQueryHandler<GroupUserCreateDto, GroupUserUpdateDto, IGroupUserCriteriaQuery, TDto>, IGetGroupUsersByCriteriaQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetGroupUsersByCriteriaQueryHandler(IGroupUserService service) : base(service)
        {
        }
    }
}