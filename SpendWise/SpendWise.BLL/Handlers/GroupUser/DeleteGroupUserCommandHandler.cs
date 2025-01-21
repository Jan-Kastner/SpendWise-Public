using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class DeleteGroupUserCommandHandler : DeleteItemCommandHandler<GroupUserCreateDto, GroupUserUpdateDto, IGroupUserCriteriaQuery>, IDeleteGroupUserCommandHandler
    {
        public DeleteGroupUserCommandHandler(IGroupUserService service) : base(service)
        {
        }
    }
}