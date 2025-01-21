using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class UpdateGroupUserCommandHandler : UpdateItemCommandHandler<GroupUserCreateDto, GroupUserUpdateDto, IGroupUserCriteriaQuery>, IUpdateGroupUserCommandHandler
    {
        public UpdateGroupUserCommandHandler(IGroupUserService service) : base(service)
        {
        }
    }
}