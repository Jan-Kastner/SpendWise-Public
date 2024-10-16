namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a group user.
    /// </summary>
    /// <typeparam name="TGroupUserDto">The type of the group user DTO.</typeparam>
    public interface IGroupUserDto<TGroupUserDto> where TGroupUserDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the group user associated with the entity.
        /// </summary>
        TGroupUserDto GroupUser { get; set; }
    }
}