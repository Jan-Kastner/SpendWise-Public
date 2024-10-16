namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a group.
    /// </summary>
    /// <typeparam name="TGroupDto">The type of the group DTO.</typeparam>
    public interface IGroupDto<TGroupDto> where TGroupDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the group associated with the entity.
        /// </summary>
        TGroupDto Group { get; set; }
    }
}