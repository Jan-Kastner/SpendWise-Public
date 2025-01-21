using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class GetGroupUserByIdQueryHandler<TDto> : GetItemByIdQueryHandler<GroupUserCreateDto, GroupUserUpdateDto, IGroupUserCriteriaQuery, TDto>, IGetGroupUserByIdQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetGroupUserByIdQueryHandler(IGroupUserService service) : base(service)
        {
        }
    }
}