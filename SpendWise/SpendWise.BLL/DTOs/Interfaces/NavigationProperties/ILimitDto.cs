namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a limit.
    /// </summary>
    /// <typeparam name="TLimitDto">The type of the limit DTO.</typeparam>
    public interface ILimitDto<TLimitDto> where TLimitDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the limit associated with the entity.
        /// </summary>
        TLimitDto? Limit { get; set; }
    }
}