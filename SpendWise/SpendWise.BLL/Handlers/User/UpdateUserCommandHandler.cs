using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class UpdateUserCommandHandler : UpdateItemCommandHandler<UserCreateDto, UserUpdateDto, IUserCriteriaQuery>, IUpdateUserCommandHandler
    {
        public UpdateUserCommandHandler(IUserService service) : base(service)
        {
        }
    }
}