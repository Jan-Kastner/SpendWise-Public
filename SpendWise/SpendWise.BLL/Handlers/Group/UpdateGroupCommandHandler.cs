using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class UpdateGroupCommandHandler : UpdateItemCommandHandler<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery>, IUpdateGroupCommandHandler
    {
        public UpdateGroupCommandHandler(IGroupService service) : base(service)
        {
        }
    }
}