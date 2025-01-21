using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    internal interface IGetGroupUsersByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<GroupUserCreateDto, GroupUserUpdateDto, IGroupUserCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}