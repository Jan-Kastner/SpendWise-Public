using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetUsersByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<UserCreateDto, UserUpdateDto, IUserCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}