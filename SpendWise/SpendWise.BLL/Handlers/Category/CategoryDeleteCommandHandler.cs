using System.Threading.Tasks;
using SpendWise.BLL.Commands;
using SpendWise.BLL.Services;

namespace SpendWise.BLL.Handlers.Categories
{
    /// <summary>
    /// Handles the deletion of categories.
    /// </summary>
    public class CategoryDeleteCommandHandler : ICategoryDeleteCommandHandler
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDeleteCommandHandler"/> class.
        /// </summary>
        /// <param name="categoryService">The service used to delete categories.</param>
        public CategoryDeleteCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Handles the specified delete command.
        /// </summary>
        /// <param name="command">The delete command to handle.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Handle(DeleteCommand command)
        {
            await _categoryService.DeleteAsync(command.Id);
        }
    }
}