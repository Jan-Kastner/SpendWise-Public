using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Handlers
{
    public class DeleteUserCommandHandler : DeleteItemCommandHandler<UserCreateDto, UserUpdateDto, IUserCriteriaQuery>, IDeleteUserCommandHandler
    {
        public DeleteUserCommandHandler(IUserService service) : base(service)
        {
        }
    }
}