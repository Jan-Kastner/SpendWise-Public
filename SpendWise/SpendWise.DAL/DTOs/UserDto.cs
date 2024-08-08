namespace SpendWise.DAL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for an user.
    /// </summary>
    public record UserDto : IDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname of the user.
        /// </summary>
        public required string Surname { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the password for the user.
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user registered.
        /// </summary>
        public required DateTime Date_of_registration { get; set; }

        /// <summary>
        /// Gets or sets the photo of the user. Can be null.
        /// </summary>
        public byte[]? Photo { get; set; }
    }
}
