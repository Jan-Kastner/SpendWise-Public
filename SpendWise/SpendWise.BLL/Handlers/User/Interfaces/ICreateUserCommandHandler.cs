using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface ICreateUserCommandHandler : ICreateItemCommandHandler<UserCreateDto, UserUpdateDto, IUserCriteriaQuery>
    {
    }
}