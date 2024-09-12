namespace SpendWise.Common.Enums
{
    /// <summary>
    /// Represents the various roles of users within the SpendWise application.
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Role with full group management permissions, including adding/removing members, dissolving the group, and assigning roles to other members.
        /// </summary>
        GroupFounder = 1,

        /// <summary>
        /// Role with permissions to add/remove members and assign roles to other members, but without the ability to dissolve the group.
        /// </summary>
        GroupManager = 2,

        /// <summary>
        /// Role with permissions to add/remove members, but cannot assign roles or dissolve the group.
        /// </summary>
        GroupCoordinator = 3,

        /// <summary>
        /// Role without any permissions to manage members or assign roles.
        /// </summary>
        GroupParticipant = 4,
    }
}

