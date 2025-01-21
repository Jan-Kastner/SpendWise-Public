using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetUserByIdQueryHandler<TDto> : IGetItemByIdQueryHandler<UserCreateDto, UserUpdateDto, IUserCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}