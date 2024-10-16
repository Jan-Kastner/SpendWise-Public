using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class CreateCategoryCommandHandler : CreateItemCommandHandler<CategoryCreateDto, CategoryUpdateDto, ICategoryCriteriaQuery>, ICreateCategoryCommandHandler
    {
        public CreateCategoryCommandHandler(ICategoryService service) : base(service)
        {
        }
    }
}