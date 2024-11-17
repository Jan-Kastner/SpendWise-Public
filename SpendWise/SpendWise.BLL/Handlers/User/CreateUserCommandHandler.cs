using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Handlers
{
    public class CreateUserCommandHandler : CreateItemCommandHandler<UserCreateDto, UserUpdateDto, IUserCriteriaQuery>, ICreateUserCommandHandler
    {
        public CreateUserCommandHandler(IUserService service) : base(service)
        {
        }
    }
}