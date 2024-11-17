using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class DeleteGroupCommandHandler : DeleteItemCommandHandler<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery>, IDeleteGroupCommandHandler
    {
        public DeleteGroupCommandHandler(IGroupService service) : base(service)
        {
        }
    }
}