using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class DeleteCategoryCommandHandler : DeleteItemCommandHandler<CategoryCreateDto, CategoryUpdateDto, ICategoryCriteriaQuery>, IDeleteCategoryCommandHandler
    {
        public DeleteCategoryCommandHandler(ICategoryService service) : base(service)
        {
        }
    }
}