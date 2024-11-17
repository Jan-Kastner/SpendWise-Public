using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class DeleteLimitCommandHandler : DeleteItemCommandHandler<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery>, IDeleteLimitCommandHandler
    {
        public DeleteLimitCommandHandler(ILimitService service) : base(service)
        {
        }
    }
}