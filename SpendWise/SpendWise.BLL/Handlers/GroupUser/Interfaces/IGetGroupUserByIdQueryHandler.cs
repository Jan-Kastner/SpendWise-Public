using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    internal interface IGetGroupUserByIdQueryHandler<TDto> : IGetItemByIdQueryHandler<GroupUserCreateDto, GroupUserUpdateDto, IGroupUserCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}