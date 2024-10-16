using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IUpdateItemCommandHandler<TCreateDto, TUpdateDto, TCriteriaQuery>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : class, IUpdatableDto
        where TCriteriaQuery : ICriteriaQuery
    {
        Task Handle(UpdateCommand<TUpdateDto> command);
    }
}