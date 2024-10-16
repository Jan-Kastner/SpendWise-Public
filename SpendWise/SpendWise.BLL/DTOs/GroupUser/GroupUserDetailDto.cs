using SpendWise.Common.Enums;
using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about a group user.
    /// </summary>
    public record GroupUserDetailDto : IQueryableDto, IUserDto<UserListDto>, IGroupDto<GroupListDto>, ITransactionGroupUsersDto<TransactionGroupUserListDto>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group user.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the role of the user within the group.
        /// </summary>
        public required UserRole Role { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the group.
        /// </summary>
        public required UserListDto User { get; set; }

        /// <summary>
        /// Gets or sets the group associated with the user.
        /// </summary>
        public required GroupListDto Group { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the limit associated with the user, if any.
        /// </summary>
        public Guid? LimitId { get; set; }

        /// <summary>
        /// Gets or sets the limit associated with the user, if any.
        /// </summary>
        public LimitListDto? Limit { get; set; } = null;

        /// <summary>
        /// Gets or sets the list of transactions associated with the group user.
        /// </summary>
        public IEnumerable<TransactionGroupUserListDto> TransactionGroupUsers { get; set; } = new List<TransactionGroupUserListDto>();
    }
}