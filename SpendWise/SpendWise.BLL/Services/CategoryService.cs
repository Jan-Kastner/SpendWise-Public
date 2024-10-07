using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;
using SpendWise.DAL.UnitOfWork;
using AutoMapper;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.BLL.Services
{
    /// <summary>
    /// Provides services for managing categories, including creating, updating, deleting, and retrieving categories.
    /// </summary>
    public class CategoryService : BaseService<CategoryDto, CategoryEntity, CategoryCreateDto, CategoryUpdateDto>, ICategoryService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Retrieves a category by its identifier.
        /// </summary>
        /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the category. Must implement <see cref="IQueryableDto"/>.</typeparam>
        /// <param name="categoryId">The unique identifier of the category to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <typeparamref name="TDto"/>.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while retrieving the category by ID.</exception>
        public async Task<TDto> GetCategoryByIdAsync<TDto>(Guid categoryId) where TDto : class, IQueryableDto
        {
            try
            {
                var dalCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(categoryId);
                if (typeof(TDto) == typeof(CategoryDetailDto) && dalCategory != null)
                {
                    return (TDto)(object)await MapToCategoryDetailDto(dalCategory);
                }

                return _mapper.Map<TDto>(dalCategory);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the category by ID.", ex);
            }
        }

        /// <summary>
        /// Retrieves all categories based on the specified query.
        /// </summary>
        /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the categories. Must implement <see cref="IQueryableDto"/>.</typeparam>
        /// <param name="queryObject">The query object used to filter categories.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of <typeparamref name="TDto"/>.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while retrieving the categories.</exception>
        public async Task<IEnumerable<TDto>> GetCategoriesAsync<TDto>(GetAllItemsQuery queryObject) where TDto : class, IQueryableDto
        {
            var query = new CategoryQueryObject();
            try
            {
                var dalCategories = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetAsync(query);
                if (typeof(TDto) == typeof(CategoryDetailDto) && dalCategories != null)
                {
                    var categoryDetailDtos = new List<CategoryDetailDto>();
                    foreach (var dalCategory in dalCategories)
                    {
                        categoryDetailDtos.Add(await MapToCategoryDetailDto(dalCategory));
                    }
                    return (IEnumerable<TDto>)(object)categoryDetailDtos;
                }

                return _mapper.Map<IEnumerable<TDto>>(dalCategories);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the categories.", ex);
            }
        }

        /// <summary>
        /// Maps a <see cref="CategoryDto"/> to a <see cref="CategoryDetailDto"/>, including related transactions.
        /// </summary>
        /// <param name="dalCategory">The category DTO to map.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="CategoryDetailDto"/>.</returns>
        private async Task<CategoryDetailDto> MapToCategoryDetailDto(CategoryDto dalCategory)
        {
            var queryObject = new TransactionQueryObject().WithCategory(dalCategory.Id);
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>().GetAsync(queryObject);
            var categoryDetailDto = _mapper.Map<CategoryDetailDto>(dalCategory);
            categoryDetailDto.Transactions = _mapper.Map<IEnumerable<TransactionListDto>>(transactions);
            return categoryDetailDto;
        }
    }
}