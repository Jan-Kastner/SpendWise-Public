namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a list of group users.
    /// </summary>
    /// <typeparam name="TGroupUserDto">The type of the group user DTO.</typeparam>
    public interface IGroupUsersDto<TGroupUserDto> where TGroupUserDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the list of group users associated with the group.
        /// </summary>
        IEnumerable<TGroupUserDto> GroupUsers { get; set; }
    }
}