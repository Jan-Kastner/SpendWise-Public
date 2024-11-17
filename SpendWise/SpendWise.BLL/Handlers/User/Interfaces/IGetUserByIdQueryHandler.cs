using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetUserByIdQueryHandler<TDto> : IGetItemByIdQueryHandler<UserCreateDto, UserUpdateDto, IUserCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}