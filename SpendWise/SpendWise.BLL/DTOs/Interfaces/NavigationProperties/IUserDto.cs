namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a user.
    /// </summary>
    /// <typeparam name="TUserDto">The type of the user DTO.</typeparam>
    public interface IUserDto<TUserDto> where TUserDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the user associated with the entity.
        /// </summary>
        TUserDto User { get; set; }
    }
}