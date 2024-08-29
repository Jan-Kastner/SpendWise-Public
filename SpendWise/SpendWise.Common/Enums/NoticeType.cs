namespace SpendWise.Common.Enums
{
    /// <summary>
    /// Represents the different types of notifications that can be sent to users.
    /// </summary>
    public enum NoticeType
    {
        /// <summary>
        /// Notification sent via email.
        /// </summary>
        Email = 1,

        /// <summary>
        /// Notification sent via SMS (text message).
        /// </summary>
        SMS = 2,

        /// <summary>
        /// Push notification sent to the user's device.
        /// </summary>
        PushNotification = 3,

        /// <summary>
        /// Notification displayed within the application.
        /// </summary>
        InApp = 4,
    }
}
