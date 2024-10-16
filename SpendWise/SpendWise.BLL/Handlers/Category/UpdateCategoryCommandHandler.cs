using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class UpdateCategoryCommandHandler : UpdateItemCommandHandler<CategoryCreateDto, CategoryUpdateDto, ICategoryCriteriaQuery>, IUpdateCategoryCommandHandler
    {
        public UpdateCategoryCommandHandler(ICategoryService service) : base(service)
        {
        }
    }
}