namespace SpendWise.BLL.Commands
{
    /// <summary>
    /// Represents a command to delete an entity by its identifier.
    /// </summary>
    public class DeleteCommand
    {
        /// <summary>
        /// Gets the identifier of the entity to be deleted.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCommand"/> class.
        /// </summary>
        /// <param name="id">The identifier of the entity to be deleted.</param>
        public DeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}