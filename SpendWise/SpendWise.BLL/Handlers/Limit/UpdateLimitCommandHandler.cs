using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class UpdateLimitCommandHandler : UpdateItemCommandHandler<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery>, IUpdateLimitCommandHandler
    {
        public UpdateLimitCommandHandler(ILimitService service) : base(service)
        {
        }
    }
}