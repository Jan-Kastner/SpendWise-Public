using SpendWise.BLL.DTOs.Category;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.DAL.DTOs;
using SpendWise.DAL.UnitOfWork;
using AutoMapper;


namespace SpendWise.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDetailDto> AddCategoryAsync(CategoryCreateDto category)
        {
            var dalCategory = _mapper.Map<CategoryDto>(category);
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().InsertAsync(dalCategory);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CategoryDetailDto>(dalCategory);
        }

        public async Task<CategoryDetailDto> GetCategoryByIdAsync(Guid id)
        {
            var dalCategory = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetByIdAsync(id);
            return _mapper.Map<CategoryDetailDto>(dalCategory);
        }

        public async Task<IEnumerable<CategoryListDto>> GetAllCategoriesAsync()
        {
            var dalCategories = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetAsync();
            return _mapper.Map<IEnumerable<CategoryListDto>>(dalCategories);
        }

        public async Task<IEnumerable<CategoryListDto>> GetCategoriesByNameAsync(string name)
        {
            var queryObject = new CategoryQueryObject().WithName(name);
            var dalCategories = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetAsync(queryObject);
            return _mapper.Map<IEnumerable<CategoryListDto>>(dalCategories);
        }

        public async Task<IEnumerable<CategoryListDto>> GetCategoriesByDescriptionAsync(string description)
        {
            var queryObject = new CategoryQueryObject().WithDescription(description);
            var dalCategories = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetAsync(queryObject);
            return _mapper.Map<IEnumerable<CategoryListDto>>(dalCategories);
        }

        public async Task<IEnumerable<CategoryListDto>> GetCategoriesByColorAsync(string color)
        {
            var queryObject = new CategoryQueryObject().WithColor(color);
            var dalCategories = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetAsync(queryObject);
            return _mapper.Map<IEnumerable<CategoryListDto>>(dalCategories);
        }

        public async Task<IEnumerable<CategoryListDto>> GetCategoriesWithIconAsync()
        {
            var queryObject = new CategoryQueryObject().WithIcon();
            var dalCategories = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetAsync(queryObject);
            return _mapper.Map<IEnumerable<CategoryListDto>>(dalCategories);
        }

        public async Task<IEnumerable<CategoryListDto>> GetCategoriesWithoutIconAsync()
        {
            var queryObject = new CategoryQueryObject().WithoutIcon();
            var dalCategories = await _unitOfWork.Repository<CategoryEntity, CategoryDto>().GetAsync(queryObject);
            return _mapper.Map<IEnumerable<CategoryListDto>>(dalCategories);
        }

        public async Task UpdateCategoryAsync(CategoryUpdateDto category)
        {
            var dalCategory = _mapper.Map<CategoryDto>(category);
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().UpdateAsync(dalCategory);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            await _unitOfWork.Repository<CategoryEntity, CategoryDto>().DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}