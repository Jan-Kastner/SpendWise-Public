using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class CreateGroupUserCommandHandler : CreateItemCommandHandler<GroupUserCreateDto, GroupUserUpdateDto, IGroupUserCriteriaQuery>, ICreateGroupUserCommandHandler
    {
        public CreateGroupUserCommandHandler(IGroupUserService service) : base(service)
        {
        }
    }
}