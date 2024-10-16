using SpendWise.Common.Enums;
using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about a user.
    /// </summary>
    public record UserDetailDto : ISentInvitationsDto<InvitationListDto>, IReceivedInvitationsDto<InvitationListDto>, IGroupUsersDto<GroupUserListDto>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname of the user.
        /// </summary>
        public required string Surname { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the date of registration of the user.
        /// </summary>
        public required DateTime DateOfRegistration { get; set; }

        /// <summary>
        /// Gets or sets the photo of the user.
        /// </summary>
        public required byte[] Photo { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Gets or sets a value indicating whether the user's email is confirmed.
        /// </summary>
        public required bool IsEmailConfirmed { get; set; } = false;

        /// <summary>
        /// Gets or sets the preferred theme of the user.
        /// </summary>
        public required Theme PreferredTheme { get; set; } = Theme.SystemDefault;

        /// <summary>
        /// Gets or sets the list of invitations sent by the user.
        /// </summary>
        public IEnumerable<InvitationListDto> SentInvitations { get; set; } = new List<InvitationListDto>();

        /// <summary>
        /// Gets or sets the list of invitations received by the user.
        /// </summary>
        public IEnumerable<InvitationListDto> ReceivedInvitations { get; set; } = new List<InvitationListDto>();

        /// <summary>
        /// Gets or sets the list of group users associated with the user.
        /// </summary>
        public IEnumerable<GroupUserListDto> GroupUsers { get; set; } = new List<GroupUserListDto>();
    }
}