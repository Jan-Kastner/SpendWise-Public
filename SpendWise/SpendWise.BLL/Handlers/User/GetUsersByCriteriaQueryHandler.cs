using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Handlers
{
    public class GetUsersByCriteriaQueryHandler<TDto> : GetItemsByCriteriaQueryHandler<UserCreateDto, UserUpdateDto, IUserCriteriaQuery, TDto>, IGetUsersByCriteriaQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetUsersByCriteriaQueryHandler(IUserService service) : base(service)
        {
        }
    }
}