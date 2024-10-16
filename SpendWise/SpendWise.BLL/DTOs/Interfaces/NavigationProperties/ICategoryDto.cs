namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a category.
    /// </summary>
    /// <typeparam name="TCategoryDto">The type of the category DTO.</typeparam>
    public interface ICategoryDto<TCategoryDto> where TCategoryDto : IQueryableDto
    {
        /// <summary>
        /// Gets the category associated with the entity.
        /// </summary>
        Guid? CategoryId { get; set; }
        TCategoryDto? Category { get; set; }
    }
}
