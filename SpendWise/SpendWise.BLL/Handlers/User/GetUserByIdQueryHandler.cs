using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetUserByIdQueryHandler<TDto> : GetItemByIdQueryHandler<UserCreateDto, UserUpdateDto, IUserCriteriaQuery, TDto>, IGetUserByIdQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetUserByIdQueryHandler(IUserService service) : base(service)
        {
        }
    }
}