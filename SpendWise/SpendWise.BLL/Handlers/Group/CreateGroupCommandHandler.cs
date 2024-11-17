using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class CreateGroupCommandHandler : CreateItemCommandHandler<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery>, ICreateGroupCommandHandler
    {
        public CreateGroupCommandHandler(IGroupService service) : base(service)
        {
        }
    }
}