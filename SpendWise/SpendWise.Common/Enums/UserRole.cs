namespace SpendWise.Common.Enums
{
    /// <summary>
    /// Represents the various roles of users within the SpendWise application.
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Represents a standard user with basic access rights.
        /// </summary>
        User = 1,

        /// <summary>
        /// Represents a group founder who has additional privileges related to group management.
        /// </summary>
        GroupFounder = 2,

        /// <summary>
        /// Represents an admin user with elevated permissions to manage the application.
        /// </summary>
        Admin = 3,
    }
}
