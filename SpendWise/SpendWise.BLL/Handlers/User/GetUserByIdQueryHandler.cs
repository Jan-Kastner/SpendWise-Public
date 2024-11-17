using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.DAL.DTOs;

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