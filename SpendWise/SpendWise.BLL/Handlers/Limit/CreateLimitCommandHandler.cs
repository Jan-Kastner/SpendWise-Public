using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class CreateLimitCommandHandler : CreateItemCommandHandler<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery>, ICreateLimitCommandHandler
    {
        public CreateLimitCommandHandler(ILimitService service) : base(service)
        {
        }
    }
}